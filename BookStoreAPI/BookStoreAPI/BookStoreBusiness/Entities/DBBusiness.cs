using BookStoreAPI.BookStoreBusiness.Interfaces;
using BookStoreAPI.BookStoreDataAccess.Entities;
using BookStoreAPI.Results.DBResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreAPI.BookStoreBusiness
{
    public class DBBusiness<T> : IDBBusiness<T>
        where T : DBResult
    {
        protected DBDataAccess crudModel = DBDataAccess.instance;

        public virtual async Task<List<T>> ListAll(string query, params object[] args)
        {
            return await crudModel.ListAll<T>(query, args);
        }

        public virtual async Task<T> ListById(string query, params object[] args)
        {
            return await crudModel.ListById<T>(query, args);
        }

        public virtual async Task<int> Insert(string query, params object[] args)
        {
            return await crudModel.Insert(query, args);
        }

        public virtual async Task<T> Update(string query, params object[] args)
        {
            return await crudModel.Update<T>(query, args);
        }

        public virtual async Task<T> Delete(string query, params object[] args)
        {
            return await crudModel.Delete<T>(query, args);
        }
    }
}