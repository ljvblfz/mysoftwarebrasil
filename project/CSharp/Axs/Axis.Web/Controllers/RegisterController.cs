﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Axis.Models;
using Axis.Domain;
using Axis.Infrastructure.MVC;
using Axis.Infrastructure.MVC.Security;
using Axis.Application;
using Lms.API.Infrastructure.MVC.Extensions;
using System.Web.Script.Serialization;
using Axis.Infrastructure;
using Axis.Adapter;

namespace Axis.Controllers
{
    public class RegisterController : BaseController
    {
        //
        // GET: /Register/
        [Anonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Create", "Member");
        }

        //
        // GET: /Register/Person
        [Anonymous]
        public ActionResult Person()
        {
            var personModel = new PersonModel();
            personModel.Idestado = AddressAdapter.GetListState();
            return View(personModel);
        }

        //
        // POST: /Register/Person
        [HttpPost]
        [Anonymous]
        public ActionResult Person(PersonModel modelView, Pessoa model, FormCollection form)
        {
            if (ModelState.IsValidField("nomePessoa"))
            {
                SecurityAdapter.RegisterPerson(model, form);
                return RedirectToAction("Profile");
            }
            return View(modelView);
        }

        //
        // GET: /Register/Profile
        [Anonymous]
        public ActionResult Profile()
        {
            return View(new ProfileModel());
        }

        //
        // POST: /Register/Profile
        [HttpPost]
        [Anonymous]
        public ActionResult Profile(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                SecurityAdapter.RegisterProfile(form);
                SecurityAdapter.CompleteRecordUser();
                AddMessage("Cadastro concluido");
                return RedirectToAction("LogOn", "Account");
            }
            return View();
        }

        //
        // POST: /Register/GetCity
        [HttpPost]
        [Anonymous]
        public JsonResult GetCity(int idEstado)
        {
            var result = AddressAdapter.GetListCity(idEstado);
            return Json(result);
        }

    }
}
