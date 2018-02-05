using BookStoreAPI.BookStoreBusiness.Interfaces;
using BookStoreAPI.BookStoreResults.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreBusiness.Entities
{
    public class UsuarioBusiness :DBBusiness<Usuario>, IUsuarioBusiness
    {
        private static UsuarioBusiness _instance;

        private UsuarioBusiness() { }

        public static UsuarioBusiness instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioBusiness();
                }
                return _instance;
            }
        }
    }
}