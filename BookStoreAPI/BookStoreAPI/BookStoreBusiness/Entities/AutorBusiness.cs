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

        public override async Task<Autor> ListById(string query, params object[] args)
        {
            Autor result = await base.ListById(query, args);
            result.EDITORAS = await EditoraBusiness.instance.ListEditoraByParam(Querys.SELECT_EDITORA_BY_AUTOR, result.ID);
            result.LIVROS = await LivroBusiness.instance.ListLivroByParam(Querys.SELECT_LIVRO_BY_AUTOR, result.ID);
            return result;
        }

        public Task<List<Autor>> ListAutorByParam(string query, params object[] args)
        {
            return ListAll(query, args);
        }
    }
}