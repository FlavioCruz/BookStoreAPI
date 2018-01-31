using BookStoreAPI.BookStoreBusiness.Interfaces;
using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

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

        public Task<List<Autor>> ListAutorByEditora(string query, params object[] args)
        {
            return ListAll(query, args);
        }
    }
}