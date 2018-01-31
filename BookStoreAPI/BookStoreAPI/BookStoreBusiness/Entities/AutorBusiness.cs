using BookStoreAPI.BookStoreBusiness.Interfaces;
using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using BookStoreAPI.BookStoreControllers;

namespace BookStoreAPI.BookStoreBusiness.Entities
{
    public class AutorBusiness : DBBusiness<Autor>, IAutorBusiness
    {
        private static AutorBusiness _instance;

        private AutorBusiness() { }

        public static AutorBusiness instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AutorBusiness();
                }
                return _instance;
            }
        }

        public override async Task<List<Autor>> ListAll(string query, params object[] args)
        {
            List<Autor> result = await base.ListAll(query, args);
            foreach(var r in result)
            {
                r.EDITORAS = await EditoraBusiness.instance.ListEditoraByAutor(Querys.SELECT_EDITORA_BY_AUTOR, r.ID);
            }
            return result;
        }

        public override async Task<Autor> ListById(string query, params object[] args)
        {
            Autor result = await base.ListById(query, args);
            result.EDITORAS = await EditoraBusiness.instance.ListEditoraByAutor(Querys.SELECT_EDITORA_BY_AUTOR, result.ID);
            return result;
        }

        public Task<List<Autor>> ListAutorByEditora(string query, params object[] args)
        {
            return ListAll(query, args);
        }
    }
}