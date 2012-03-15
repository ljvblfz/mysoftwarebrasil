﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Axis.Models;
using Axis.Infrastructure.MVC.Security;
using Axis.Domain;
using Axis.Infrastructure;
using Axis.Infrastructure.MVC;

namespace Axis.Controllers
{
    public class AccountController : BaseController
    {

        //
        // GET: /Account/LogOn
        [Anonymous]
        public ActionResult LogOn()
        {
            return PartialView();
        }

        //
        // POST: /Account/LogOn
        [Anonymous]
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (new MembroRepository().Login(model.UserName,model.Password))
                {
                    var user = new MembroRepository().GetMemberLogin(model.UserName);
                    user.pessoa = null;
                    Aplication.CreateTicket(
                                            model.UserName, 
                                            model.RememberMe, 
                                            user, 
                                            DateTime.Now.AddDays(3)
                                            );

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff
        [Anonymous]
        public ActionResult LogOff()
        {
            Aplication.DestroyTicket();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
