using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Axis.Models;
using Axis.Domain;
using Axis.Adapter;
using Axis.Infrastructure.MVC;
using Axis.Infrastructure;
using Axis.Infrastructure.MVC.Security;

namespace Axis.Controllers
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
            var membro = SecurityAdapter.GetMember();
            return View(membro, typeof(PanelControlModel));
        }

        //
        // POST: /Member/Edit/5

        [HttpPost]
        public ActionResult Edit(RegisterModel modelView, Membro model,Perfil perfil)
        {
            if (!String.IsNullOrEmpty(model.loginMembro))
            {
                SecurityAdapter.UpdateMember(model);
                PerfilAdapter.UpdatePerfil(perfil);
                AddMessage("Membro atualizado com sucesso.");
                return RedirectToAction("Index","Member");
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
        public ActionResult Details(string login)
        {
            var result = MemberAdapter.Get(login);
            return View(result);
        }
    }
}
