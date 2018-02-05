using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.BookStoreDataAccess.Interfaces
{
    public interface IDBDataAccess
    {
        Task<List<T>> ListAll<T>(string query, params object[] args);

        Task<T> ListById<T>(string query, params object[] args);

        Task<int> Insert(string query, params object[] args);

        Task<T> Update<T>(string query, params object[] args);

        Task<T> Delete<T>(string query, params object[] args);
    }
}
