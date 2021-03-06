﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Results.DBResults
{
    public class Editora : DBResult
    {
        public string NOME { get; set; }
        public List<Autor> AUTORES { get; set; }
        public List<Livro> LIVROS { get; set; }
    }
}