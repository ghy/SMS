using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Microsoft.Practices.Unity;

namespace SMS.Web.Models
{
    public class ProcessorManager
    {
        private ISession session;
        private IUnityContainer container;

        public ProcessorManager(ISession session, IUnityContainer container)
        {
            this.session = session;
            this.container = container;
        }

        /// <summary>
        /// 创建Proccess对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// 将代码段包含在事务中执行。
        /// </summary>
        /// <param name="action"></param>
        public void Scope(Action<ProcessorManager> action)
        {
            Scope<object>(p =>
            {
                action(p);
                return null;
            });
        }

        /// <summary>
        /// 将代码段包含在事务中执行。
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public TResult Scope<TResult>(Func<ProcessorManager, TResult> func)
        {
            TResult result = default(TResult);

            using (var scope = session.BeginTransaction())
            {
                result = func(this);
                scope.Commit();
            }

            return result;
        }
    }
}