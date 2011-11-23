using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.IO;
using System.Reflection;
using SMS.Services.Mapping;

namespace SMS.Services.Test
{
    public class HibernateUtils
    {
        private static readonly ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        static HibernateUtils()
        {
            try
            {
                _configuration = new Configuration();
                var mapping = new MappingFactory().CreateMapping();
                _configuration.AddDeserializedMapping(mapping, null);
                var a = _configuration.Configure();
                _sessionFactory = a.BuildSessionFactory();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Configuration Configuration
        {
            get { return _configuration; }
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }
    }
}
