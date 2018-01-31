
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
using BookStoreAPI.BookStoreModels.DBModels;
using BookStoreAPI.Results.DBResults;
using Newtonsoft.Json.Linq;

namespace BookStoreAPI.BookStoreControllers
{
    public class AssuntosController : ApiController
    {
        
        // CRUD de assunto criado
        
        private BookStoreEntities db = new BookStoreEntities();

        [HttpGet]
        [Route("api/ListAssuntos")]
        public async Task<IHttpActionResult> ListAssuntos(int i = 0)
        {
            return Ok(
                await db.Database.SqlQuery<Assunto>(Querys.SELECT_ASSUNTOS).ToListAsync()
            );
        }


        [HttpGet]
        [Route("api/ListAssunto/{id}")]
        public async Task<IHttpActionResult> ListAssunto(int id)
        {
            return Ok(
                await db.Database.SqlQuery<Assunto>(Querys.SELECT_ASSUNTO, id).ToListAsync()
            );
        }

        [HttpPost]
        [Route("api/EditAssunto/{nome}")]
        public async Task<IHttpActionResult> EditAssunto(HttpRequestMessage request)
        {
            try
            {
                var obj = await Request.Content.ReadAsAsync<JObject>();
                string nome = obj.GetValue("NOME").ToString();
                string id = obj.GetValue("ID").ToString();
                await db.Database.ExecuteSqlCommandAsync(Querys.UPDATE_ASSUNTO, nome, id);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpPost]
        [Route("api/CreateAssunto/{nome}")]
        public async Task<IHttpActionResult> CreateAssunto()
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
        [Route("api/DeleteAssunto/{id}")]
        [ResponseType(typeof(editora))]
        public async Task<IHttpActionResult> DeleteAssunto(int id)
        {
            try
            {
                await db.Database.ExecuteSqlCommandAsync(Querys.DELETE_ASSUNTO, id);
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

        private bool assuntoExists(int id)
        {
            return db.assunto.Count(e => e.ID_ASSUNTO == id) > 0;
        }
    }
}