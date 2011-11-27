using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Web.Common;
using SMS.Services;
using SMS.Web.Models;
using SMS.Web.Models.Lesson;
using SMS.Services.Enum;
using SMS.Services.LessonManagement;
using Youmay.Paging;
using Youmay.Enums;
using Youmay.Web;
using Youmay.Exceptions;
using SMS.Services.Common;

namespace SMS.Web.Controllers
{
    public class LessonController : ManagementController
    {
        private Repository repository;
        private ProcessorManager manager;

        public LessonController(Repository repository, ProcessorManager manager)
        {
            this.repository = repository;
            this.manager = manager;
        }


        public ActionResult Index(IndexForm form)
        {
            if (ModelState.IsValid)
            {
                form.SortConditions = new[]{
                                        new SortCondition<LessonSortType>
                                        {
                                            SortType=LessonSortType.CreateDateTime,
                                            SortDirection = SortDirection.Descending
                                        }};

                var users = manager.Create<ListLessonProcessor>().Execute(ConvertTo<ListLessonParameters>(form));

                return View(new IndexViewModel(users, form));
            }
            return View(
               new IndexViewModel(
               Empty<LessonListView>.Pagination, form));
        }

        public ActionResult Create()
        {
            return View(new CreateViewModel()
            {
                Classes = repository.ListClass().ToSelectList(),
                SchoolBooks = I18NUtils.SelectList(typeof(SchoolBook)),
                LessonTypes = I18NUtils.SelectList(typeof(LessonType)),

            });
        }

        [HttpPost]
        public ActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var processor = manager.Create<AddLessonProcessor>();
                    processor.Execute(ConvertTo<LessonAddView>(form));

                    TempSuccessMessage("学生添加成功");
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
