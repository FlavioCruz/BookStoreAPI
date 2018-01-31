using BookStoreAPI.BookStoreDataAccess.Interfaces;
using BookStoreAPI.BookStoreModels.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreAPI.BookStoreDataAccess.Entities
{
    public class DBDataAccess : IDBDataAccess
    {
        private BookStoreEntities db = new BookStoreEntities();

        public async Task<List<T>> ListAll<T>(string query, params object[] args)
        {
            List<T> result = await db.Database.SqlQuery<T>(query).ToListAsync();
            return result;
        }

        public async Task<T> ListById<T>(string query, params object[] args)
        {
            var result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }

        public async Task<T> InsertAndGetObj<T>(string query, params object[] args)
        {
            T result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }

        public async Task<T> Update<T>(string query, params object[] args)
        {
            T result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }

        public async Task<T> Delete<T>(string query, params object[] args)
        {
            T result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }
    }
}