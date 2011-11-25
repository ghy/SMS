﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Tool.hbm2ddl;
using SMS.Services.Entities;

namespace SMS.Services.Test
{
    /// <summary>
    /// UnitTest1 的摘要说明3
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {

        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            var export = new SchemaExport(HibernateUtils.Configuration);
            export.Execute(true, true, false);
            DataInit();
        }


        [TestMethod]
        public void DataInit()
        {
            using (var _session = HibernateUtils.SessionFactory.OpenSession())
            {
                try
                {
                    _session.Transaction.Begin();
                    Administrator adm = new Administrator()
                    {
                        Account = "admin",
                        Password = "8888",
                        Status = Enum.UserStatus.Enable,
                        Name = "管理员",
                        CreationDateTime = DateTime.Now,
                        Role = Enum.Role.Admin,
                        Gender = Enum.Gender.Male
                    };


                    _session.Save(adm);


                    _session.Transaction.Commit();
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    _session.Transaction.Rollback();
                    throw e;

                }
            }
        }
    }
}
