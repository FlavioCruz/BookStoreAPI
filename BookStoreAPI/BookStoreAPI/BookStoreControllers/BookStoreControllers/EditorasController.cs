
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
    public class EditorasController : ApiController
    {

        // CRUD de editora criado

        EditoraBusiness crud = EditoraBusiness.instance;

        [HttpGet]
        [Route("api/ListEditoras")]
        [ResponseType(typeof(List<Editora>))]
        public async Task<IHttpActionResult> ListEditoras(int i = 0)
        {
            var result = await crud.ListAll(Querys.SELECT_EDITORAS);
            return Ok(result);
        }


        [HttpGet]
        [Route("api/ListEditora/{id}")]
        [ResponseType(typeof(Editora))]
        public async Task<IHttpActionResult> ListEditora(int id)
         {
            var result = await crud.ListById(Querys.SELECT_EDITORA, id);
            return Ok(result);
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
                await crud.Update(Querys.UPDATE_EDITORA, nome, id);
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
                var result = await crud.Insert(Querys.INSERT_EDITORA, nome);
                return Ok(result);
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
                await crud.Delete(Querys.DELETE_EDITORA, id);
                return Ok(1);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}