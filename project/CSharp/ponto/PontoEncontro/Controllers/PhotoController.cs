using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.MVC;
using PontoEncontro.Models;
using PontoEncontro.Adapter;

namespace PontoEncontro.Controllers
{
    public class PhotoController : BaseController
    {
        //
        // GET: /Foto/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Foto/Details

        public ActionResult Details()
        {
            return View(PhotoAdapter.List());
        }

        //
        // POST: /Foto/Details

        [HttpPost]
        public JsonResult Details(FormCollection collection)
        {
            return Json(PhotoAdapter.List());
        }

        //
        // GET: /Foto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Foto/Create

        [HttpPost]
        public ActionResult Create(PhotoModel modelView)
        {
            if (ModelState.IsValid)
            {
                if (PhotoAdapter.CreateFoto(modelView))
                    AddMessage("Foto adicionada");
                return View();    
            }
            return View(modelView);
        }
        
        //
        // GET: /Foto/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Foto/Edit/5

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

        //
        // GET: /Foto/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Foto/Delete/5

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
