using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Models;
using PontoEncontro.Models;

namespace PontoEncontro.Controllers
{ 
    public class PessoaController : Controller
    {
        private PontoEncontroContext db = new PontoEncontroContext();

        //
        // GET: /Pessoa/

        public ViewResult Index()
        {
            return View();
        }

        //
        // GET: /Pessoa/Details/5

        public ViewResult Details(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            return View(pessoa);
        }

        //
        // GET: /Pessoa/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pessoa/Create

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(pessoa);
        }
        
        //
        // GET: /Pessoa/Edit/5
 
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            return View(pessoa);
        }

        //
        // POST: /Pessoa/Edit/5

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        //
        // GET: /Pessoa/Delete/5
 
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            return View(pessoa);
        }

        //
        // POST: /Pessoa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}