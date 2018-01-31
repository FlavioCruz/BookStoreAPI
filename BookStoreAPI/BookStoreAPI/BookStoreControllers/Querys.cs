using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreControllers
{
    public static class Querys
    {
        #region Querys de editora
        public static readonly string SELECT_EDITORAS = "SELECT ID_EDITORA AS ID, NOME_EDITORA AS NOME " +
                                                        "FROM editora";

        public static readonly string SELECT_EDITORA = "SELECT ID_EDITORA AS ID, NOME_EDITORA AS NOME "+
                                                       "FROM editora " + 
                                                       "WHERE ID_EDITORA = {0}";

        public static readonly string UPDATE_EDITORA = "UPDATE editora " + 
                                                       "SET NOME_EDITORA = {0} " + 
                                                       "WHERE ID_EDITORA = {1} ";

        public static readonly string INSERT_EDITORA = "INSERT INTO editora " + 
                                                       "VALUES({0})";

        public static readonly string DELETE_EDITORA = "DELETE " + 
                                                       "FROM editora " + 
                                                       "WHERE ID_EDITORA = {0}";

        #endregion

        #region Querys de autor
        public static readonly string SELECT_AUTORES = "SELECT ID_AUTOR AS ID, NOME_AUTOR AS NOME" + 
                                                       "FROM autor";

        public static readonly string SELECT_AUTOR = "SELECT ID_AUTOR AS ID, NOME_AUTOR AS NOME " + 
                                                     "FROM autor WHERE ID_AUTOR = {0}";

        public static readonly string UPDATE_AUTOR = "UPDATE autor" + 
                                                     "SET NOME_AUTOR = {0}" + 
                                                     "WHERE ID_AUTOR = {1}";

        public static readonly string INSERT_AUTOR = "INSERT INTO autor" +
                                                     "VALUES({0})";

        public static readonly string DELETE_AUTOR = "DELETE" +
                                                     "FROM autor" +
                                                     "WHERE ID_AUTOR = {0}";

        #endregion

        #region Querys de assunto
        public static readonly string SELECT_ASSUNTOS = "SELECT ID_ASSUNTO AS ID, NOME_ASSUNTO AS NOME" +
                                                        "FROM assunto";

        public static readonly string SELECT_ASSUNTO = "SELECT ID_ASSUNTO AS ID, NOME_ASSUNTO AS NOME" +
                                                       "FROM assunto" +
                                                       "WHERE ID_ASSUNTO = {0}";

        public static readonly string UPDATE_ASSUNTO = "UPDATE assunto" +
                                                       "SET NOME_ASSUNTO = {0}" +
                                                       "WHERE ID_ASSUNTO = {1}";

        public static readonly string INSERT_ASSUNTO = "INSERT INTO assunto" +
                                                       "VALUES({0})";

        public static readonly string DELETE_ASSUNTO = "DELETE" +
                                                       "FROM assunto" +
                                                       "WHERE ID_ASSUNTO = {0}";

        #endregion

        #region Querys de livro
        public static readonly string SELECT_LIVROS = "SELECT ID_LIVRO AS ID, TITULO_LIVRO AS TITULO, PRECO_LIVRO AS PRECO, ID_EDITORA_LIVRO AS ID_EDITORA, NOME_EDITORA, ID_ASSUNTO_LIVRO AS ID_ASSUNTO, TITULO_ASSUNTO " +
                                                      "FROM livro as L, assunto as A, editora as E" +
                                                      "WHERE L.ID_ASSUNTO_LIVRO = A.ID_ASSUNTO AND L.ID_EDITORA_LIVRO = E.ID_EDITORA";

        public static readonly string SELECT_LIVRO = "SELECT ID_LIVRO AS ID, TITULO_LIVRO AS TITULO, PRECO_LIVRO AS PRECO, ID_EDITORA_LIVRO AS ID_EDITORA, NOME_EDITORA, ID_ASSUNTO_LIVRO AS ID_ASSUNTO, TITULO_ASSUNTO " +
                                                     "FROM livro as L, assunto as A, editora as E" +
                                                     "WHERE L.ID_ASSUNTO_LIVRO = A.ID_ASSUNTO AND L.ID_EDITORA_LIVRO = E.ID_EDITORA AND L.ID_LIVRO = {0}";

        public static readonly string UPDATE_LIVRO = "";

        public static readonly string INSERT_LIVRO = "";

        public static readonly string DELETE_LIVRO = "";
        #endregion
    }
}