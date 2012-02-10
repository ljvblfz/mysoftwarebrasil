using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Models;
using PontoEncontro.Domain;
using PontoEncontro.Adapter;
using PontoEncontro.Infrastructure.MVC;
using PontoEncontro.Infrastructure;

namespace PontoEncontro.Controllers
{
    public class MemberController : BaseController
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        //
        // GET: /Member/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Member/Create

        [HttpPost]
        public ActionResult Create(RegisterModel modelView, Membro model)
        {
            if (ModelState.IsValid)
            {
                SecurityAdapter.RegisterMember(model);
                return RedirectToAction("Person");
            }
            return View(modelView);
        }
        
        //
        // GET: /Member/Edit/5
 
        public ActionResult Edit()
        {
            var membro = Aplication.GetUser<Membro>(typeof(Membro));
            return View(membro, typeof(RegisterModel));
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        public ActionResult Edit(RegisterModel modelView, Membro model)
        {
            if (ModelState.IsValid)
            {
                SecurityAdapter.UpdateMember(model);
                AddMessage("Membro atualizado com sucesso.");
                return RedirectToAction("Index","Home");
            }
            return View(modelView);
        }
    }
}
