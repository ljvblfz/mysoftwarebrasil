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
        // GET: /Register/Details/5
        [Anonymous]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Register/Create
        [Anonymous]
        public ActionResult Member()
        {
            return View();
        } 

        //
        // POST: /Register/Create

        [HttpPost]
        [Anonymous]
        public ActionResult Member(RegisterModel modelView, Membro model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Person");
            }
            return View(modelView);
        }

        [Anonymous]
        public ActionResult Person()
        {
            var personModel = new PersonModel(AddressApplication.GetListState());
            return View(personModel);
        }

        //
        // POST: /Register/Create
        [HttpPost]
        [Anonymous]
        public ActionResult Person(FormCollection collection)
        {
            return RedirectToAction("Index");
        }

        //
        // POST: /Register/GetCity
        [HttpPost]
        [Anonymous]
        public JsonResult GetCity(int? idEstado)
        {
            var result = EnumerableExtensions.CreateSelectListItem<Cidade>(
                    AddressApplication.GetListCity(),
                    t => t.Namecidade,
                    v => v.Idcidade);
            return Json(result);
        }

    }
}
