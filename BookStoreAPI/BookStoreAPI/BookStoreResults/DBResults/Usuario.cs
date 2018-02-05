using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreResults.DBResults
{
    public class Usuario : DBResult
    {
        public string NOME { get; set; }
        public string SOBRENOME { get; set; }
        public string USUARIO { get; set; }
        public string SENHA { get; set; }
    }
}