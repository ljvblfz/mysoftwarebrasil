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
using Telerik.Web.Mvc;

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

        [GridAction]
        public ActionResult Search(GridCommand command)
        {
            var memberModel = new MemberModel();

            TempData["Idestado"] = 0;
            TempData["Idcidade"] = 0;
            TempData["loginMembro"] = 0;
            TempData["LastAccessed"] = 0;
            TempData["LastUpdate"] = 0;

            memberModel.Idestado = AddressAdapter.GetListState();
            memberModel.Age = MemberAdapter.GetAge();
            memberModel.Membros = MemberAdapter.List(command);
            return View(memberModel);
        }

        [GridAction]
        public ActionResult List(GridCommand command)
        {
            var memberModel = MemberAdapter.List(command);
            return View(memberModel);
        }

        [HttpPost]
        public ActionResult Search(GridCommand command,MemberModel model, FormCollection form
         , int? idestado)
        {
            TempData["Idestado"] = idestado ?? 0;
            TempData["Idcidade"] = model.Idcidade;
            TempData["loginMembro"] = model.loginMembro;
            TempData["LastAccessed"] = model.LastAccessed;
            TempData["LastUpdate"] = model.LastUpdate;

            var memberModel = new MemberModel();
            memberModel.Idestado = AddressAdapter.GetListState();
            memberModel.Age = MemberAdapter.GetAge();
            memberModel.Membros = MemberAdapter.List(command);
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
