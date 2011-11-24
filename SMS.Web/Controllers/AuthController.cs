using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youmay.Web;
using SMS.Web.Models;
using Youmay.Web.Authentication;
using SMS.Services;
using SMS.Web.Models.Auth;
using SMS.Services.Auth;
using SMS.Services.Enum;

namespace SMS.Web.Controllers
{
    public class AuthController : BaseController
    {
        private ProcessorManager manager;
        private IFormsAuthentication formsAuth;
        private Repository repository;

        public AuthController(ProcessorManager manager,
            IFormsAuthentication formsAuth, Repository repository)
        {
            this.manager = manager;
            this.formsAuth = formsAuth;
            this.repository = repository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = manager.Create<LoginProcessor>().Execute(new UserLoginView
                    {
                        Account = form.Account,
                        Password = form.Password,
                    });

                    formsAuth.SignIn(userId.ToString(), false);

                    return RedirectToAction("Index", "home");
                }
                catch (LoginException le)
                {
                    switch (le.LoginFailType)
                    {
                        case LoginFailType.AccountOrPasswordWrong:
                            ViewErrorMessage("帐号或密码错误");
                            break;
                        case LoginFailType.UserIsDisabled:
                            ViewErrorMessage("用户已禁用");
                            break;
                    }
                }
            }
            return AjaxJson();
        }

        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
                formsAuth.SignOut();
            return RedirectToAction("Login");
        }

    }
}
