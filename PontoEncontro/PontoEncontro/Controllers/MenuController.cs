using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Models;
using System.Web.Security;

namespace PontoEncontro.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            IList<Menu> result = CorePontoEncontro.Repository.MenuRepository.ListAll();

            return View(result);
        }

        public ActionResult Generation()
        {
            IList<Menu> result = CorePontoEncontro.Repository.MenuRepository.ListAll();
            if (Request.IsAuthenticated)
            {
                return View(result);
            }
            else
            {
                return View(result.Where(i => i.MenuId == 4 || i.MenuId == 5 || i.MenuId == 6));
            }

            return View();
        }

        //
        // GET: /Menu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Menu/Create
        public ActionResult Create()
        {
            var list = from d in CorePontoEncontro.Repository.MenuRepository.ListAll()
                                      orderby d.MenuIdPai descending
                                      select d;
            ViewData["Ratings"] = list.ToArray();
            return View();
        } 

        //
        // POST: /Menu/Create
        [HttpPost]
        public ActionResult Create(Infrastructure.Models.Menu collection)
        {
            CorePontoEncontro.Repository.MenuRepository.Insert(collection);
            return View(collection);
        }
        
        //
        // GET: /Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Menu/Edit/5
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
        // GET: /Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Menu/Delete/5
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
