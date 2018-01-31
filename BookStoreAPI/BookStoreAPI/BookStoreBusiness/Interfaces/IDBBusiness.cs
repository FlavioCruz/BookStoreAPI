using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.BookStoreBusiness.Interfaces
{
    interface IDBBusiness<T>
    {
        Task<List<T>> ListAll(string query, params object[] args);

        Task<T> ListById(string query, params object[] args);

        Task<T> InsertAndGetObj(string query, params object[] args);

        Task<T> Update(string query, params object[] args);

        Task<T> Delete(string query, params object[] args);
    }
}
