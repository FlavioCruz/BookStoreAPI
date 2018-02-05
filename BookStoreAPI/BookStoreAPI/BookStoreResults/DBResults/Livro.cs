using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Results.DBResults
{
    public class Livro : DBResult
    {
        public string TITULO { get; set; }
        public List<Autor> AUTORES { get; set; }
        public Editora EDITORA { get; set; }
    }
}