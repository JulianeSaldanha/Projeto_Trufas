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
    public class SaborController : Controller
    {
        private ISaborService service = new SaborService(new SaborRepository());
        private ITrufaService trufaService = new TrufaService(new TrufaRepository());
        //
        // GET: /Sabor/

        public ActionResult Index()
        {
            return View(service.RetrieveAll());
        }

        //
        // GET: /Sabor/Details/5

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;
            Sabor sabor = service.Retrieve(i);
            sabor = service.Retrieve(id);
            if (sabor == null)
            {
                return HttpNotFound();
            }
            return View(sabor);
        }

        //
        // GET: /Sabor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sabor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameSabor,SaborId")] Sabor sabor)
        {
            if (ModelState.IsValid)
            {
                service.Create(sabor);
                return RedirectToAction("Index");
            }

            return View(sabor);
        }

        //
        // GET: /Sabor/Edit/5

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Sabor sabor = service.Retrieve(i);
            if (sabor == null)
            {
                return HttpNotFound();
            }

            //ViewData["TrufaId"] = GetTrufas();
            return View(sabor);
        }

        //
        // POST: /Sabor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameSabor,SaborId")] Sabor sabor)
        {
            if (ModelState.IsValid)
            {
                service.Update(sabor);
                return RedirectToAction("Index");
            }
            return View(sabor);
        }

        //
        // GET: /Sabor/Delete/5

        public ActionResult Delete(int id)
        {
             if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int i = (int)id;

            Sabor sabor = service.Retrieve(i);
            if (sabor == null)
            {
                return HttpNotFound();
            }
            return View(sabor);
        }


        //
        // POST: /Sabor/Delete/5

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
