using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Models.Class;
using SMS.Services;
using SMS.Web.Models;
using SMS.Services.Common;
using Youmay.Web;
using SMS.Web.Common;
using Youmay.Exceptions;
using SMS.Services.ClassManagement;
using SMS.Services.Enum;
using Youmay.Paging;
using Youmay.Enums;

namespace SMS.Web.Controllers
{
    public class ClassController : ManagementController
    {
        private Repository repository;
        private ProcessorManager manager;

        public ClassController(Repository repository, ProcessorManager manager)
        {
            this.repository = repository;
            this.manager = manager;
        }

        public ActionResult Index(IndexForm form)
        {
            if (ModelState.IsValid)
            {
                form.SortConditions = new[]{
                                        new SortCondition<ClassSortType>
                                        {
                                            SortType=ClassSortType.CreateDateTime,
                                            SortDirection = SortDirection.Descending
                                        }};

                var cls = manager.Create<ListClassProcessor>().Execute(ConvertTo<ListClassParameters>(form));

                return View(new IndexViewModel(cls, form));
            }
            return View(
               new IndexViewModel(
               Empty<ClassListView>.Pagination, form));
        }

        public ActionResult Create()
        {
            return View(new CreateViewModel()
            {
                Teachers = repository.ListTeacher().ToSelectList()
            });
        }

        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var processor = manager.Create<AddClassProcessor>();
                    processor.Execute(ConvertTo<ClassAddView>(form));

                    TempSuccessMessage("班级添加成功");
                    //if (isContinue.HasValue)
                    //    return RedirectToAction("Add");
                    return RedirectToAction("Index");
                }
                catch (RepeatException e)
                {
                    ViewErrorMessage(e.Message);
                }
            }

            return Create();
        }



    }
}
