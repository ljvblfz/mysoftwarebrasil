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
                model.idRole = 2;
                Aplication.AddCookie(model, "Member");
                return RedirectToAction("Person");
            }
            return View(modelView);
        }

        //
        // GET: /Register/Person
        [Anonymous]
        public ActionResult Person()
        {
            var personModel = new PersonModel(AddressApplication.GetListState());
            return View(personModel);
        }

        //
        // POST: /Register/Person
        [HttpPost]
        [Anonymous]
        public ActionResult Person(PersonModel modelView, Pessoa model, FormCollection form)
        {
            if (true)
            {
                var idCidade = 1;
                var idestado = 1;
                int.TryParse(form["Idcidade"], out idCidade);
                int.TryParse(form["Idestado"], out idestado);

                var address = new Endereco()
                {
                    idCidade = idCidade
                };
                Aplication.AddCookie(address, "Address");
                Aplication.AddCookie(model, "Person");
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
                var address = Aplication.GetCookie(typeof(Endereco), "Address") as Endereco;
                var member = Aplication.GetCookie(typeof(Membro), "Member") as Membro;
                var person = Aplication.GetCookie(typeof(Pessoa), "Person") as Pessoa;

                var profile = new Perfil()
                {
                    idCabelo = int.Parse(form["idCabelo"]),
                    idEndereco = address.idEndereco,
                    idEstadoCivil = int.Parse(form["idEstadoCivil"]),
                    idEtinia = int.Parse(form["idEtinia"]),
                    idOlho = int.Parse(form["idOlho"]),
                    idSexo = int.Parse(form["idSexo"]),
                };

                new MembroRepository().Register(member, profile, address, person);
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
            var result = EnumerableExtensions.CreateSelectListItem<Cidade>(
                    AddressApplication.GetListCity(idEstado),
                    t => t.nameCidade,
                    v => v.idCidade);
            return Json(result);
        }

    }
}
