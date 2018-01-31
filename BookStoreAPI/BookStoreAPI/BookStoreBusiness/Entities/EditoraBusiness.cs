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

        /// <summary>
        /// Lista todas as editoras com seus autores
        /// </summary>
        /// <param name="query">Query de busca das editoras</param>
        /// <param name="args">Lista de argumentos</param>
        /// <returns>Lista de editoras</returns>
        public override async Task<List<Editora>> ListAll(string query, params object[] args)
        {
            var result = await base.ListAll(query, args);
            foreach(var r in result)
            {
                r.AUTORES = await AutorBusiness.instance.ListAutorByEditora(Querys.SELECT_AUTOR_BY_EDITORA, r.ID);
            }
            return result;
        }

        public async Task<List<Editora>> ListEditoraByAutor(string query, params object[] args)
        {
            return await ListAll(query, args);
        }
    }
}