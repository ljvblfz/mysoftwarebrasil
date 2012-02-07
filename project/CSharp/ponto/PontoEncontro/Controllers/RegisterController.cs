using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Models;
using PontoEncontro.Domain;
using PontoEncontro.Infrastructure.MVC;
using PontoEncontro.Infrastructure.MVC.Security;
using PontoEncontro.Application;
using Lms.API.Infrastructure.MVC.Extensions;
using System.Web.Script.Serialization;
using PontoEncontro.Infrastructure;
using PontoEncontro.Adapter;

namespace PontoEncontro.Controllers
{
    public class RegisterController : BaseController
    {
        //
        // GET: /Register/
        [Anonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Member");
        }

        //
        // GET: /Register/Member
        [Anonymous]
        public ActionResult Member()
        {
            return View();
        }

        //
        // POST: /Register/Member

        [HttpPost]
        [Anonymous]
        public ActionResult Member(RegisterModel modelView, Membro model)
        {
            if (ModelState.IsValid)
            {
                SecurityAdapter.RegisterMember(model);
                ViewBag.Message = new List<string>() { "Prossiga com o registro"};
                return RedirectToAction("Person");
            }
            return View(modelView);
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
                ModelState.AddModelError("", "Conta criada com sucesso.");
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
