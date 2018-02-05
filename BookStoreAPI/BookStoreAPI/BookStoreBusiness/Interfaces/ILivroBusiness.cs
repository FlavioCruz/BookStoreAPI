using BookStoreAPI.Results.DBResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.BookStoreBusiness.Interfaces
{
    interface ILivroBusinesss : IDBBusiness<Livro>
    {
        Task<List<Livro>> ListLivroByParam(string query, params object[] args);
    }
}