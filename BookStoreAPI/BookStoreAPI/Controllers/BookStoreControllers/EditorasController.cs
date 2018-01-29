
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookStoreAPI.Models.DBModels;
using BookStoreAPI.Results.DBResults;
using Newtonsoft.Json.Linq;

namespace BookStoreAPI.Controllers.BookStoreControllers
{
    public class EditorasController : ApiController
    {
        
        // CRUD de editora criado
        
        private BookStoreEntities db = new BookStoreEntities();

        [HttpGet]
        [Route("api/ListEditoras")]
        public async Task<IHttpActionResult> ListEditoras(int i = 0)
        {
            return Ok(
                await db.Database.SqlQuery<Editora>(Querys.SELECT_EDITORAS).ToListAsync()
            );
        }


        [HttpGet]
        [Route("api/ListEditora/{id}")]
        [ResponseType(typeof(editora))]
        public async Task<IHttpActionResult> ListEditora(int id)
        {
            return Ok(
                await db.Database.SqlQuery<Editora>(Querys.SELECT_EDITORA, id).ToListAsync()
            );
        }

        [HttpPost]
        [Route("api/EditEditora/{nome}")]
        public async Task<IHttpActionResult> EditEditora(HttpRequestMessage request)
        {
            try
            {
                var obj = await Request.Content.ReadAsAsync<JObject>();
                string nome = obj.GetValue("NOME").ToString();
                string id = obj.GetValue("ID").ToString();
                await db.Database.ExecuteSqlCommandAsync(Querys.UPDATE_EDITORA, nome, id);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        public async Task<IHttpActionResult> CreateEditora()
        {
            try
            {
                var obj = await Request.Content.ReadAsAsync<JObject>();
                string nome = obj.GetValue("NOME").ToString();
                await db.Database.ExecuteSqlCommandAsync(Querys.INSERT_EDITORA, nome);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }


        [HttpGet]
        [Route("api/DeleteEditora/{id}")]
        [ResponseType(typeof(editora))]
        public async Task<IHttpActionResult> DeleteEditora(int id)
        {
            try
            {
                await db.Database.ExecuteSqlCommandAsync(Querys.DELETE_EDITORA, id);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool editoraExists(int id)
        {
            return db.editora.Count(e => e.ID_EDITORA == id) > 0;
        }
    }
}