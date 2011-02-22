using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewHelper;

namespace Mvc_Teste.Controllers
{
    
    public class ContatoController : Controller
    {
        /// <summary>
        ///  Objeto da pesquisa
        /// </summary>
        public static Find<Contato> pesquisa;

        public void PesquisaContato()
        {
            Dictionary<string, Dictionary<string, object>> filtros = new Dictionary<string, Dictionary<string, object>>();
            Dictionary<string, object> filtro = new Dictionary<string, object>();
            filtro.Add("tipo_campo", "text");
            filtro.Add("tipo_dado", "numerico");
            filtro.Add("descricao", "Codigo");
            filtros.Add("Id", filtro);

            Dictionary<string, Dictionary<string, object>> campos = new Dictionary<string, Dictionary<string, object>>();
            Dictionary<string, object> campo = new Dictionary<string, object>();
            campo.Add("name", "Codigo");
            campos.Add("Id", campo);

            pesquisa = new Find<Contato>();
            Contato[] arrayContato = Contato.FindAll();

            pesquisa.Set(new List<Contato>(arrayContato), filtros, campos, null);
        }

        //
        // POST: /Contato/Create

        [HttpPost]
        public ActionResult Pesquisa(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Contato contato = DbTable<Contato>.getCamposUteis(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Contato/

        public ActionResult Pesquisa()
        {
            PesquisaContato();
            ViewData["pesquisa"] = pesquisa.filter + pesquisa.field;
            return View();
        }

        //
        // GET: /Contato/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Contato/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Contato/Create

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
        
        //
        // GET: /Contato/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Contato/Edit/5

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
        // GET: /Contato/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Contato/Delete/5

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
