using BookStoreAPI.BookStoreDataAccess.Entities;
using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreAPI.BookStoreBusiness
{
    public class DBBusiness<T>
        where T : DBResult
    {
        protected DBDataAccess crudModel = new DBDataAccess();

        public async Task<List<T>> ListAll(string query, params object[] args)
        {
            return await crudModel.ListAll<T>(query, args);
        }

        public async Task<T> ListById(string query, params object[] args)
        {
            return await crudModel.ListById<T>(query, args);
        }

        public async Task<T> InsertAndGetObj(string query, params object[] args)
        {
            return await crudModel.InsertAndGetObj<T>(query, args);
        }

        public async Task<T> Update(string query, params object[] args)
        {
            return await crudModel.Update<T>(query, args);
        }

        public async Task<T> Delete(string query, params object[] args)
        {
            return await crudModel.Delete<T>(query, args);
        }
    }
}