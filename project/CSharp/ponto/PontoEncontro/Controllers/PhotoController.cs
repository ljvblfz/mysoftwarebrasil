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
            return RedirectToAction("Details");
        }

        //
        // GET: /Foto/Details

        public ActionResult Details()
        {
            return View(PhotoAdapter.List());
        }

        //
        // GET: /Photo/Gallery

        public ActionResult Gallery()
        {
            return View(PhotoAdapter.List());
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
        // GET: /Foto/Delete/5
 
        public ActionResult Delete(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                if (PhotoAdapter.DeleteFoto(id))
                    AddMessage("Foto excluida");
            }
            return RedirectToAction("Details");
        }

    }
}
