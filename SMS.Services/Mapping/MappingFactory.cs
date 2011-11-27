using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg.MappingSchema;
using ConfOrm;
using ConfOrm.Patterns;
using SMS.Services.Entities;
using System.Reflection;
using ConfOrm.NH;
using ConfOrm.Shop.CoolNaming;

namespace SMS.Services.Mapping
{
    public class MappingFactory
    {
        public HbmMapping CreateMapping()
        {
            var orm = new ObjectRelationalMapper();

            //主键生成策略
            orm.Patterns.PoidStrategies.Add(new NativePoidPattern());

            orm.TablePerClass(new[] 
                {   
                    typeof(AccountInfo),
                    typeof(Attendance),
                    typeof(Lesson),
                    typeof(Class),
                    typeof(Course)
                });

            orm.ManyToMany<Student, Class>();
            orm.ManyToOne<Lesson, Class>();
            orm.ManyToOne<Class, Teacher>();
            orm.ManyToOne<Lesson, Teacher>();

            //orm.Poid<Role>(o => o.Type);
            var mapper = new Mapper(orm, new CoolPatternsAppliersHolder(orm));

            //属性约束映射
            commonPropertyMapper(ref mapper);
            entityPropertyMapper(ref mapper);
            var a = Assembly.GetAssembly(typeof(AccountInfo));
            var hc = mapper.CompileMappingFor(a.GetTypes());

            return hc;
        }

        /// <summary>
        /// 公共属性约束映射
        /// </summary>
        /// <param name="mapper"></param>
        private void commonPropertyMapper(ref Mapper mapper)
        {
            //DBType mapping
            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(bool),
                (pm) => { pm.Column(cm => cm.SqlType("bit")); });

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(bool?),
                (pm) => { pm.Column(cm => cm.SqlType("bit")); });

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Email")
                , pm => { pm.Length(200); });

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Fax")
                , pm => pm.Length(50));

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Remark")
                , pm => pm.Length(2000));

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Description")
                , pm => pm.Length(2000));

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Title")
                , pm => { pm.Length(200); pm.NotNullable(true); });

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Content")
                , pm => pm.Length(20000));

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Equals("Name", StringComparison.CurrentCultureIgnoreCase)
                , pm => { pm.Length(100); pm.NotNullable(true); });

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Account")
                , pm => { pm.Length(20); pm.NotNullable(true); });

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(string) &&
               mi.Name.Contains("Password")
               , pm => { pm.Length(56); pm.NotNullable(true); });

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(DateTime) &&
               mi.Name.Contains("CreationDate")
               , pm => pm.NotNullable(true));

            mapper.AddPropertyPattern(mi =>
               mi.Name.Equals("Status", StringComparison.CurrentCultureIgnoreCase)
               , pm => pm.NotNullable(true));

            //mapper.AddPropertyPattern(mi =>
            //   mi.Name.Contains("Type")
            //   , pm => pm.NotNullable(true));

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.ToLower().Contains("PhoneNo".ToLower())
                , pm => { pm.Length(50); pm.NotNullable(false); });

            mapper.AddPropertyPattern(mi =>
                mi.GetPropertyOrFieldType() == typeof(string) &&
                mi.Name.Contains("Address")
                , pm => pm.Length(200));

            mapper.AddPropertyPattern(mi =>
               mi.Name.Contains("Gender")
               , pm => pm.NotNullable(true));

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(DateTime) &&
               mi.Name.Equals("StartDate", StringComparison.CurrentCultureIgnoreCase)
               , pm => pm.NotNullable(true));

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(DateTime) &&
               mi.Name.Equals("EndDate", StringComparison.CurrentCultureIgnoreCase)
               , pm => pm.NotNullable(true));

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(string) &&
               mi.Name.Contains("FileName")
               , pm => { pm.Length(100); pm.NotNullable(true); });

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(long) &&
               mi.Name.Contains("FileSize")
               , pm => { pm.NotNullable(true); });

            mapper.AddPropertyPattern(mi =>
               mi.GetPropertyOrFieldType() == typeof(string) &&
               mi.Name.Contains("ContentType")
               , pm => { pm.Length(100); pm.NotNullable(true); });
        }

        /// <summary>
        /// 实体属性约束映射
        /// </summary>
        /// <param name="mapper"></param>
        private void entityPropertyMapper(ref Mapper mapper)
        {


        }

    }
}
