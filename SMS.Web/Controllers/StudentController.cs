using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Common;
using SMS.Services;
using SMS.Web.Models;
using SMS.Services.StudentManagement;
using SMS.Web.Models.Student;
using Youmay.Exceptions;
using Youmay.Web;
using SMS.Services.Enum;
using Youmay.Paging;
using Youmay.Enums;
using SMS.Services.Common;

namespace SMS.Web.Controllers
{
    public class StudentController : ManagementController
    {
        private Repository repository;
        private ProcessorManager manager;

        public StudentController(Repository repository, ProcessorManager manager)
        {
            this.repository = repository;
            this.manager = manager;
        }


        public ActionResult Index(IndexForm form)
        {
            if (ModelState.IsValid)
            {
                form.SortConditions = new[]{new SortCondition<StudentSortType>()
                                        {
                                            SortType=StudentSortType.Status,
                                            SortDirection=SortDirection.Ascending
                                        },
                                        new SortCondition<StudentSortType>
                                        {
                                            SortType=StudentSortType.CreationDateTime,
                                            SortDirection = SortDirection.Descending
                                        }};

                var users = manager.Create<ListStudentProcessor>().Execute(ConvertTo<ListStudentParameters>(form));

                return View(new IndexViewModel(users, form)
                {
                    IsSearch = true,
                });
            }
            return View(
               new IndexViewModel(
               Empty<StudentListView>.Pagination, form)
               {
                   IsSearch = true,
               });
        }

        public ActionResult Create()
        {
            return View(new CreateViewModel()
            {
                Genders = I18NUtils.SelectList(typeof(Gender)),
                Classes = repository.ListClass().ToSelectList()
            });
        }

        [HttpPost]
        public ActionResult Create(CreateForm form, bool? isContinue)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var processor = manager.Create<AddStudentProcessor>();
                    processor.Execute(ConvertTo<StudentAddView>(form));

                    TempSuccessMessage("学生添加成功");
                    if (isContinue.HasValue)
                        return RedirectToAction("Create");
                    return RedirectToAction("Index");
                }
                catch (RepeatException e)
                {
                    ViewErrorMessage(e.Message);
                }
            }
            return Create();
        }

        public ActionResult Edit(int? id)
        {
            return View();
        }

        public ActionResult Edit(EditForm form)
        {
            return View();
        }

    }
}
