
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
using BookStoreAPI.BookStoreBusiness;

namespace BookStoreAPI.BookStoreControllers
{
    public class AssuntosController : ApiController
    {
        
        // CRUD de assunto criado
        AssuntoBusiness crud = AssuntoBusiness.instance;

        [HttpGet]
        [Route("api/ListAssuntos")]
        public async Task<IHttpActionResult> ListAssuntos(int i = 0)
        {
            
            var result = await crud.ListAll(Querys.SELECT_ASSUNTOS);
            return Ok(result);
        }


        [HttpGet]
        [Route("api/ListAssunto/{id}")]
        public async Task<IHttpActionResult> ListAssunto(int id)
        { 
            var result = await crud.ListById(Querys.SELECT_ASSUNTO, id);
            return Ok(result);
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
                await crud.Update(Querys.UPDATE_ASSUNTO, nome, id);
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
                var result = await crud.InsertAndGetObj(Querys.INSERT_EDITORA, nome);
                return Ok(result.ID);
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
                await crud.Delete(Querys.DELETE_ASSUNTO, id);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}