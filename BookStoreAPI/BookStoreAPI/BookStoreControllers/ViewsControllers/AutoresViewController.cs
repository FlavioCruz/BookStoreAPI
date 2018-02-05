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
using BookStoreAPI.BookStoreBusiness.Entities;
using BookStoreAPI.Results.DBResults;

namespace BookStoreAPI.BookStoreControllers.ViewsControllers
{
    //[UserValidation]
    public class AutoresViewController : Controller
    {
        private AutorBusiness crud = AutorBusiness.instance;

        // GET: AutoresView
        public async Task<ActionResult> Index()
        {
            return View(await crud.ListAll(Querys.SELECT_AUTORES));
        }

        // GET: AutoresView/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = await crud.ListById(Querys.SELECT_AUTOR, id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // GET: AutoresView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoresView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID, NOME")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                await crud.Insert(Querys.INSERT_AUTOR, autor.NOME);
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        // GET: AutoresView/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = await crud.ListById(Querys.SELECT_AUTOR, id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: AutoresView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_AUTOR,NOME_AUTOR")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                await crud.Update(Querys.UPDATE_AUTOR, autor.NOME);
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: AutoresView/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = await crud.ListById(Querys.SELECT_AUTOR, id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: AutoresView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Autor autor = await crud.ListById(Querys.SELECT_AUTOR, id);
            await crud.Delete(Querys.DELETE_AUTOR, id);
            return RedirectToAction("Index");
        }
    }
}
