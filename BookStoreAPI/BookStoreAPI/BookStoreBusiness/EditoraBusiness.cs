﻿using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreBusiness
{
    public class EditoraBusiness : DBBusiness<Editora>
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
    }
}