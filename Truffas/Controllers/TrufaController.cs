using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trufaria.Application;
using Trufaria.Domain;
using Trufaria.Infra.Data;

namespace Truffas.Controllers
{
    public class TrufaController : Controller
    {
        //
        private ITrufaService service = new TrufaService(new TrufaRepository());
        // GET: /Trufa/

        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        //
        // GET: /Trufa/Details/5

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trufa trufa = new Trufa();//db.Trufas.Find(id);
            trufa = service.Retrieve(id);
            if (trufa == null)
            {
                return HttpNotFound();
            }
            return View(trufa);
        }

        //
        // GET: /Trufa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trufa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataFabricacao,DataValidade,Quantidade, Tamanho, Valor")] Trufa trufa)
        {
            if (ModelState.IsValid)
            {
                service.Create(trufa);
                return RedirectToAction("Index");
            }

            return View(trufa);
        }

        //
        // GET: /Trufa/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Trufa trufa = service.Retrieve(i);
            if (trufa == null)
            {
                return HttpNotFound();
            }
            return View(trufa);
        }

        //
        // POST: /Trufa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataFabricacao,DataValidade,Quantidade, Tamanho, Valor")] Trufa trufa)
        {
            if (ModelState.IsValid)
            {
                service.Update(trufa);
                return RedirectToAction("Index");
            }
            return View(trufa);
        }

        //
        // GET: /Trufa/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Trufa trufa = service.Retrieve(i);
            if (trufa == null)
            {
                return HttpNotFound();
            }
            return View(trufa);
        }

        //
        // POST: /Trufa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
