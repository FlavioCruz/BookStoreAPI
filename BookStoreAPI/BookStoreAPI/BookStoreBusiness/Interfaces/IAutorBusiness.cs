using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.BookStoreBusiness.Interfaces
{
    interface IAutorBusiness : IDBBusiness<Autor>
    {
        Task<List<Autor>> ListAutorByEditora(string query, params object[] args);
    }
}
