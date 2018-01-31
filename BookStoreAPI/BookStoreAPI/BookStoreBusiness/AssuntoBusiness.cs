using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreBusiness
{
    public class AssuntoBusiness : DBBusiness<Assunto>
    {
        private static AssuntoBusiness _instance;

        private AssuntoBusiness() { }

        public static AssuntoBusiness instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AssuntoBusiness();
                }
                return _instance;
            }
        }
    }
}