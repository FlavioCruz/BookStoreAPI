using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStoreAPI.BookStoreModels.DBModels;
using BookStoreAPI.BookStoreBusiness;
using BookStoreAPI.Results.DBResults;

namespace BookStoreAPI.BookStoreControllers.ViewsControllers
{
    //[UserValidation]
    public class AssuntosViewController : Controller
    {
        private AssuntoBusiness crud = AssuntoBusiness.instance;

        // GET: AssuntosView
        public async Task<ActionResult> Index()
        {
            ViewData["Lista"] = await crud.ListAll(Querys.SELECT_ASSUNTOS);
            return View();
        }

        // GET: AssuntosView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assunto assunto = await crud.ListById(Querys.SELECT_ASSUNTO, id);
            ViewData["assunto"] = assunto;
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // GET: AssuntosView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssuntosView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ASSUNTO,TITULO_ASSUNTO")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                await crud.Insert(Querys.INSERT_ASSUNTO, assunto.NOME);
                return RedirectToAction("Index");
            }

            return View(assunto);
        }

        // GET: AssuntosView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assunto assunto = await crud.ListById(Querys.SELECT_ASSUNTO, id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // POST: AssuntosView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID, NOME")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                await crud.Update(Querys.UPDATE_ASSUNTO, assunto.NOME, assunto.ID);
                return RedirectToAction("Index");
            }
            return View(assunto);
        }

        // GET: AssuntosView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assunto assunto = await crud.ListById(Querys.SELECT_ASSUNTO, id);
            if (assunto == null)
            {
                return HttpNotFound();
            }
            return View(assunto);
        }

        // POST: AssuntosView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Assunto assunto = await crud.ListById(Querys.SELECT_ASSUNTO, id);
            await crud.Delete(Querys.DELETE_ASSUNTO, id);
            return RedirectToAction("Index");
        }
    }
}
