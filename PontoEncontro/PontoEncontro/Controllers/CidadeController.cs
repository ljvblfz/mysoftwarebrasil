using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Models;

namespace PontoEncontro.Controllers
{
    public class CidadeController : Controller
    {
        //
        // GET: /Cidade/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List(int estadoId)
        {
            IList<Cidade> listCidade = new List<Cidade>();
            listCidade.Add(new Cidade());
            //listCidade = CorePontoEncontro.Repository.CidadeRepository.ListAll();
            return PartialView(listCidade);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
