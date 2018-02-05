using BookStoreAPI.BookStoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BookStoreAPI.BookStoreControllers.BookStoreControllers
{
    public class AutoresController : ApiController
    {
        AutorBusiness crud = AutorBusiness.instance;
    }
}