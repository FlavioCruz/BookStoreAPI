using BookStoreAPI.BookStoreBusiness.Entities;
using BookStoreAPI.BookStoreBusiness.Interfaces;
using BookStoreAPI.BookStoreControllers;
using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreAPI.BookStoreBusiness
{
    public class EditoraBusiness : DBBusiness<Editora>, IEditoraBusiness
    {
        private static EditoraBusiness _instance;

        private EditoraBusiness() { }

        public static EditoraBusiness instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EditoraBusiness();
                }
                return _instance;
            }
        }

        public override async Task<Editora> ListById(string query, params object[] args)
        {
            Editora result = await base.ListById(query, args);
            result.AUTORES = await AutorBusiness.instance.ListAutorByParam(Querys.SELECT_AUTOR_BY_EDITORA, result.ID);
            return result;
        }

        public async Task<List<Editora>> ListEditoraByParam(string query, params object[] args)
        {
            return await ListAll(query, args);
        }
    }
}