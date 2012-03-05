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
using PontoEncontro.Infrastructure.MVC.Security;

namespace PontoEncontro.Controllers
{
    public class MemberController : BaseController
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Member/Create
        [Anonymous]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Member/Create

        [HttpPost]
        [Anonymous]
        public ActionResult Create(RegisterModel modelView, Membro model)
        {
            if (ModelState.IsValid)
            {
                SecurityAdapter.RegisterMember(model);
                return RedirectToAction("Person", "Register");
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

        public ActionResult Search()
        {
            var memberModel = new MemberModel();
            memberModel.Idestado = AddressAdapter.GetListState();
            memberModel.Age = MemberAdapter.GetAge();
            return View(memberModel);
        }

        [HttpPost]
        public ActionResult Search(MemberModel model, FormCollection form)
        {
            var memberModel = new MemberModel();
            memberModel.Idestado = AddressAdapter.GetListState();
            memberModel.Age = MemberAdapter.GetAge();
            memberModel.Membros = MemberAdapter.ListMember(form);
            return View(memberModel);
        }

        [Anonymous]
        public ActionResult Details(string id)
        {
            return View();
        }
    }
}
