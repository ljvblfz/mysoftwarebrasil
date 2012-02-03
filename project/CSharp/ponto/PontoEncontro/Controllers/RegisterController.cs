using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Models;
using PontoEncontro.Domain;
using PontoEncontro.Infrastructure.MVC;

namespace PontoEncontro.Controllers
{
    public class RegisterController : BaseController
    {
        //
        // GET: /Register/

        public ActionResult Index()
        {
            return RedirectToAction("Member");
        }

        //
        // GET: /Register/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Register/Create

        public ActionResult Member()
        {
            return View();
        } 

        //
        // POST: /Register/Create

        [HttpPost]
        public ActionResult Member(RegisterModel modelView, Membro model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Person");
            }
            return View(modelView);
        }

        public ActionResult Person()
        {
            return View();
        }

        //
        // POST: /Register/Create

        [HttpPost]
        public ActionResult Person(FormCollection collection)
        {
            return RedirectToAction("Index");
        }

    }
}
