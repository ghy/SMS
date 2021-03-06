﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Tool.hbm2ddl;
using SMS.Services.Entities;
using SMS.Services.Enum;

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
                        Role = Enum.Role.Teacher,
                        Name = "管理员",
                        CreationDateTime = DateTime.Now,
                        Gender = Enum.Gender.Male
                    };
                    _session.Save(adm);

                    var t1 = new Teacher()
                    {
                        Account = "115026672",
                        Password = "8888",
                        Status = Enum.UserStatus.Enable,
                        Name = "LK-楽瞳",
                        Role = Role.Teacher,
                        CreationDateTime = DateTime.Now,
                        Gender = Gender.Male
                    };
                    _session.Save(t1);

                    var cls1 = new Class()
                    {

                        CreationDateTime = DateTime.Now,
                        Creator = adm,
                        Name = "标日初级3班",
                        Teacher = t1
                    };
                    _session.Save(cls1);

                    #region 学生
                    var students = new[] { 
                        new []{"1","LK-当   初","383953572","0"},
                        new []{"2","LK-仙   桃","124757433","0"},
                        new []{"3","LK-Smile","1339978253","1"},
                        new []{"4","LK-额   旭","391332035","0"},
                        new []{"5","LK-告诉我","308344711","1"},
                        new []{"6","LK-乐   园","860828579","1"},
                    };

                    #region MyRegion
                    foreach (var student in students)
                    {
                        var no = student[0];
                        var name = student[1];
                        var account = student[2];
                        var gender = Convert.ToInt32(student[3]);
                        _session.Save(new Student()
                        {
                            No = Convert.ToInt32(no),
                            Name = name,
                            Account = account,
                            Gender = (Gender)gender,
                            Password = "3880",
                            Role = Role.Student,
                            CreationDateTime = DateTime.Now,
                            Class = cls1,
                            Creator = adm,
                            Email = account + "@qq.com",
                            Status = UserStatus.Enable
                        });
                    }
                    #endregion


                    #endregion


                    #region Course
                    DateTime date = new DateTime(2011, 11, 25);
                    int i = 0;
                    while (i < 23)
                    {

                        #region c1

                        if (date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            date = date.AddDays(1);
                        }

                        var c1 = new Course()
                        {
                            Name = String.Format("单词，语法（第{0}课）", ++i),
                            SchoolBook = SchoolBook.StandardJapaneseFirst
                        };

                        _session.Save(c1);

                        var lesson1 = new Lesson()
                        {

                            Class = cls1,
                            CreationDateTime = DateTime.Now,
                            Teacher = cls1.Teacher,
                            LessonType = LessonType.Evening,
                            Creator = adm,
                            Course = c1,
                            TakeClassDate = date,
                            Name = c1.Name,

                        };
                        date = date.AddDays(1);
                        _session.Save(lesson1);
                        #endregion

                        #region c2
                        if (date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            date = date.AddDays(1);
                        }

                        var c2 = new Course()
                        {
                            Name = "复习，会话",
                            SchoolBook = SchoolBook.StandardJapaneseFirst
                        };
                        _session.Save(c2);


                        var lesson2 = new Lesson()
                        {

                            Class = cls1,
                            CreationDateTime = DateTime.Now,
                            Teacher = cls1.Teacher,
                            LessonType = LessonType.Evening,
                            Creator = adm,
                            Course = c2,
                            Name = c2.Name,
                            TakeClassDate = date

                        };
                        date = date.AddDays(1);
                        _session.Save(lesson2);
                        #endregion


                        #region c3
                        if (date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            date = date.AddDays(1);
                        }

                        var c3 = new Course()
                        {
                            Name = String.Format("单词，语法（第{0}课）", ++i),
                            SchoolBook = SchoolBook.StandardJapaneseFirst
                        };
                        _session.Save(c3);

                        var lesson3 = new Lesson()
                        {

                            Class = cls1,
                            CreationDateTime = DateTime.Now,
                            Teacher = cls1.Teacher,
                            LessonType = LessonType.Evening,
                            Creator = adm,
                            Course = c3,
                            Name = c3.Name,
                            TakeClassDate = date

                        };
                        date = date.AddDays(1);
                        _session.Save(lesson3);

                        #endregion


                        #region c4
                        if (date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            date = date.AddDays(1);
                        }

                        var c4 = new Course()
                        {
                            Name = "复习，会话",
                            SchoolBook = SchoolBook.StandardJapaneseFirst
                        };
                        _session.Save(c4);

                        var lesson4 = new Lesson()
                        {

                            Class = cls1,
                            CreationDateTime = DateTime.Now,
                            Teacher = cls1.Teacher,
                            LessonType = LessonType.Evening,
                            Creator = adm,
                            Course = c4,
                            Name = c4.Name,
                            TakeClassDate = date

                        };
                        date = date.AddDays(1);
                        _session.Save(lesson4);

                        #endregion


                        #region c5

                        if (date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            date = date.AddDays(1);
                        }
                        var c5 = new Course()
                        {
                            Name = "课后练习1，练习2",
                            SchoolBook = SchoolBook.StandardJapaneseFirst
                        };
                        _session.Save(c5);

                        var lesson5 = new Lesson()
                        {

                            Class = cls1,
                            CreationDateTime = DateTime.Now,
                            Teacher = cls1.Teacher,
                            LessonType = LessonType.Evening,
                            Creator = adm,
                            Course = c5,
                            Name = c5.Name,
                            TakeClassDate = date

                        };
                        date = date.AddDays(1);
                        _session.Save(lesson5);

                        #endregion


                        #region c6
                        if (date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            date = date.AddDays(1);
                        }

                        var c6 = new Course()
                        {
                            Name = "同步练习册讲解（包含听力）",
                            SchoolBook = SchoolBook.StandardJapaneseFirst
                        };
                        _session.Save(c6);

                        var lesson6 = new Lesson()
                        {

                            Class = cls1,
                            CreationDateTime = DateTime.Now,
                            Teacher = cls1.Teacher,
                            LessonType = LessonType.Evening,
                            Creator = adm,
                            Course = c6,
                            Name = c6.Name,
                            TakeClassDate = date

                        };
                        date = date.AddDays(1);
                        _session.Save(lesson6);
                        #endregion
                    }


                    #endregion




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
