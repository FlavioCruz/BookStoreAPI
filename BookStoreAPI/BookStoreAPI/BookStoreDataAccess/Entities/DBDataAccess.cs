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

        private static DBDataAccess _instance;

        protected DBDataAccess() { }

        public static DBDataAccess instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBDataAccess();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Lista todas as ocorrencias
        /// </summary>
        /// <typeparam name="T">Modelo de dados</typeparam>
        /// <param name="query">query a consulta ao banco</param>
        /// <param name="args">lista de argumentos da consulta</param>
        /// <returns>Lista de objetos</returns>
        public async Task<List<T>> ListAll<T>(string query, params object[] args)
        {
            List<T> result = await db.Database.SqlQuery<T>(query, args).ToListAsync();
            return result;
        }

        /// <summary>
        /// Busca objeto pelo ID
        /// </summary>
        /// <typeparam name="T">Modelo de dados</typeparam>
        /// <param name="query">query a consulta ao banco</param>
        /// <param name="args">lista de argumentos da consulta</param>
        /// <returns>Objeto</returns>
        public async Task<T> ListById<T>(string query, params object[] args)
        {
            var result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Insere o objeto no banco
        /// </summary>
        /// <typeparam name="T">Modelo de dados</typeparam>
        /// <param name="query">query a consulta ao banco</param>
        /// <param name="args">lista de argumentos da consulta</param>
        /// <returns>Objeto</returns>
        public async Task<T> InsertAndGetObj<T>(string query, params object[] args)
        {
            T result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Atualiza o objeto no banco
        /// </summary>
        /// <typeparam name="T">Modelo de dados</typeparam>
        /// <param name="query">query a consulta ao banco</param>
        /// <param name="args">lista de argumentos da consulta</param>
        /// <returns>Objeto</returns>
        public async Task<T> Update<T>(string query, params object[] args)
        {
            T result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Deleta o objeto do banco
        /// </summary>
        /// <typeparam name="T">Modelo de dados</typeparam>
        /// <param name="query">query a consulta ao banco</param>
        /// <param name="args">lista de argumentos da consulta</param>
        /// <returns>Objeto</returns>
        public async Task<T> Delete<T>(string query, params object[] args)
        {
            T result = await db.Database.SqlQuery<T>(query, args).SingleOrDefaultAsync();
            return result;
        }
    }
}