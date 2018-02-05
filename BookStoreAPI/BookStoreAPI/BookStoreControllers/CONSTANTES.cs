using BookStoreAPI.BookStoreResults.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreControllers
{
    public class CONSTANTES
    {
        public static Usuario currentUser { get; set; }
        public static bool alreadyValidated { get; set; }
    }
}