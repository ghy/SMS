using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Youmay.Web.Unity;
using Youmay.Web;
using Youmay;
using System.IO;
using log4net.Config;
using Youmay.Web.ModelBinders;
using Youmay.Web.ResourceMapper;
using Microsoft.Practices.Unity;
using Resources;
using NHibernate.Cfg;
using NHibernate;
using System.Reflection;
using Youmay.Web.Nhibernate;
using Youmay.Web.Authentication;
using SMS.Services.Mapping;
using SMS.Services;

namespace SMS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : UnityMvcApplication
    {
        protected override void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
                 , new[] { "SMS.Web.Controllers" }
            );
        }

        protected override void RegisterNHConfig(IUnityContainer container)
        {
            //注册NHibernate 配置对象
            var nhConfig = new Configuration().Configure();
            container.RegisterInstance<Configuration>(nhConfig);
            container.RegisterInstance<IUnityContainer>(container);

            //配置NHibernate 映射
            var mappingFactory = new MappingFactory();
            var mapping = mappingFactory.CreateMapping();

            nhConfig.AddDeserializedMapping(mapping, null);

            var sessionFactory = nhConfig.BuildSessionFactory();
            container.RegisterInstance<ISessionFactory>(sessionFactory);

            //注册ISession注入工厂
            container.RegisterType<ISession>(
                 new PerRequestLifetimeManager(),
                           new InjectionFactory((c) =>
                              c.Resolve<ISessionFactory>().OpenSession()));

            container.RegisterInstance(new AppContext());
            container.RegisterType<QueryContext>();
            container.RegisterType<ExecuteContext>();
            container.RegisterType<OperatorInfo>(new PerRequestLifetimeManager(),
                new InjectionFactory((c) =>
                {
                    var user = HttpContext.Current.User.Identity;
                    if (user == null || !user.IsAuthenticated)
                    {
                        return null;
                    }

                    return new OperatorInfo { OperatorId = int.Parse(user.Name) };
                }));

            container.RegisterType(typeof(Repository));
        }

        //注册Services
        protected override void RegisterServices(IUnityContainer container)
        {
            //如果需要区分多个环境变量，则用反射查找并创建XXXEnvironment类。
            // container.RegisterInstance<IAppEnvironment>(new AppEnvironment());

            container.RegisterInstance<IFormsAuthentication>(new FormsAuthenticationService());

            var processorTypes = Assembly.Load("SMS.Services").GetTypes()
                                     .Where(t => t.Name.EndsWith("Processor") && t.GetMethod("Execute") != null);

            foreach (var processorType in processorTypes)
            {
                container.RegisterType(processorType);
            }

        }

        protected override void Config()
        {
            ModelBinders.Binders[typeof(IList<IFileStreamView>)] = new FileStreamListModelBinder();

            //枚举资源文件
            MvcEnvironment.EnumResourceManager = EnumResource.ResourceManager;

            DefaultModelBinder.ResourceClassKey = MvcEnvironment.MvcValidationResourceClassKey;

            ModelMetadataProviders.Current = new MvcMetadataProvider(PropertyResource.ResourceManager);

            //log4Net        
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Server.MapPath("log4net.xml")));

            //获取资源
            RegisterResourceRule(RuleTable.Rules);
        }

        private static void RegisterResourceRule(RuleCollection rules)
        {
            //rules.MapTypeRule(
            //    typeof(DimensionAddView),
            //    "Dimension",
            //    AdminResources.ResourceManager);
            rules.MapRule(
                "SMS.Web.Models",
                ResourceKeyHelper.FindFunctionAfterStringModels,
                PropertyResource.ResourceManager);
        }
    }
}