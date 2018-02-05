using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Results.DBResults
{
    public class Autor : DBResult
    {
        public string NOME { get; set; }
        public List<Editora> EDITORAS { get; set; }
        public List<Livro> LIVROS { get; set; }
    }
}