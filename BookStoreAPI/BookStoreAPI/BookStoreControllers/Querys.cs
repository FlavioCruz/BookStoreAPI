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

        public static readonly string SELECT_EDITORA_BY_AUTOR = "SELECT E.ID_EDITORA AS ID, E.NOME_EDITORA AS NOME " +
                                                                "FROM editora AS E, editora_autor as A " +
                                                                "WHERE A.ID_EDITORA = E.ID_EDITORA AND A.ID_AUTOR = {0}";

        #endregion

        #region Querys de autor
        public static readonly string SELECT_AUTORES = "SELECT ID_AUTOR AS ID, NOME_AUTOR AS NOME " + 
                                                       "FROM autor";

        public static readonly string SELECT_AUTOR = "SELECT ID_AUTOR AS ID, NOME_AUTOR AS NOME " + 
                                                     "FROM autor WHERE ID_AUTOR = {0}";

        public static readonly string UPDATE_AUTOR = "UPDATE autor " + 
                                                     "SET NOME_AUTOR = {0} " + 
                                                     "WHERE ID_AUTOR = {1}";

        public static readonly string INSERT_AUTOR = "INSERT INTO autor " +
                                                     "VALUES({0})";

        public static readonly string DELETE_AUTOR = "DELETE " +
                                                     "FROM autor " +
                                                     "WHERE ID_AUTOR = {0}";

        public static readonly string SELECT_AUTOR_BY_EDITORA = "SELECT A.ID_AUTOR AS ID, A.NOME_AUTOR AS NOME " +
                                                                "FROM autor AS A, editora_autor as E " +
                                                                "WHERE A.ID_AUTOR = E.ID_AUTOR AND E.ID_EDITORA = {0}";

        #endregion

        #region Querys de assunto
        public static readonly string SELECT_ASSUNTOS = "SELECT ID_ASSUNTO AS ID, TITULO_ASSUNTO AS NOME " +
                                                        "FROM assunto";

        public static readonly string SELECT_ASSUNTO = "SELECT ID_ASSUNTO AS ID, TITULO_ASSUNTO AS NOME " +
                                                       "FROM assunto " +
                                                       "WHERE ID_ASSUNTO = {0}";

        public static readonly string UPDATE_ASSUNTO = "UPDATE assunto " +
                                                       "SET TITULO_ASSUNTO = {0} " +
                                                       "WHERE ID_ASSUNTO = {1}";

        public static readonly string INSERT_ASSUNTO = "INSERT INTO assunto " +
                                                       "VALUES({0})";

        public static readonly string DELETE_ASSUNTO = "DELETE " +
                                                       "FROM assunto " +
                                                       "WHERE ID_ASSUNTO = {0}";

        #endregion

        #region Querys de livro
        public static readonly string SELECT_LIVROS = "SELECT ID_LIVRO AS ID, TITULO_LIVRO AS TITULO, PRECO_LIVRO AS PRECO, ID_EDITORA_LIVRO AS ID_EDITORA, NOME_EDITORA, ID_ASSUNTO_LIVRO AS ID_ASSUNTO, TITULO_ASSUNTO " +
                                                      "FROM livro as L, assunto as A, editora as E" +
                                                      "WHERE L.ID_ASSUNTO_LIVRO = A.ID_ASSUNTO AND L.ID_EDITORA_LIVRO = E.ID_EDITORA";

        public static readonly string SELECT_LIVRO = "SELECT ID_LIVRO AS ID, TITULO_LIVRO AS TITULO, PRECO_LIVRO AS PRECO, ID_EDITORA_LIVRO AS ID_EDITORA, NOME_EDITORA, ID_ASSUNTO_LIVRO AS ID_ASSUNTO, TITULO_ASSUNTO " +
                                                     "FROM livro as L, assunto as A, editora as E" +
                                                     "WHERE L.ID_ASSUNTO_LIVRO = A.ID_ASSUNTO AND L.ID_EDITORA_LIVRO = E.ID_EDITORA AND L.ID_LIVRO = {0}";

        public static readonly string UPDATE_LIVRO = "UPDATE livro " +
                                                     "SET TITULO_LIVRO = {0} " +
                                                     " WHERE ID_LIVRO = {1}";

        public static readonly string INSERT_LIVRO = "INSERT INTO livro " +
                                                     "VALUES({0}) ";

        public static readonly string DELETE_LIVRO = "SELECT ID_LIVRO AS ID, TITULO_LIVRO AS TITULO " +
                                                     "FROM livro AS L, livro_autor AS A " +
                                                     " WHERE A.ID_AUTOR = {0}";

        public static readonly string SELECT_LIVRO_BY_AUTOR = "SELECT L.ID_LIVRO AS ID, TITULO_LIVRO AS TITULO " +
                                                              "FROM livro AS L, livro_autor AS A " +
                                                              " WHERE L.ID_LIVRO = A.ID_LIVRO AND A.ID_AUTOR = {0}";

        public static readonly string SELECT_LIVRO_BY_EDITORA = "SELECT ID_LIVRO AS ID, TITULO_LIVRO AS TITULO " +
                                                                "FROM livro AS L " +
                                                                " WHERE L.ID_EDITORA = {0}";
        #endregion

        #region Querys de usuario
        public static readonly string SELECT_LOGINS = "SELECT NOME_USUARIO AS NOME, SOBRENOME_USUARIO AS SOBRENOME, LOGIN_USUARIO AS USUARIO, SENHA_USUARIO AS SENHA FROM usuario";
        public static readonly string SELECT_LOGIN = "SELECT NOME_USUARIO AS NOME, SOBRENOME_USUARIO AS SOBRENOME, LOGIN_USUARIO AS USUARIO, SENHA_USUARIO AS SENHA FROM usuario WHERE LOGIN_USUARIO = {0} AND SENHA_USUARIO = {1}";
        //public static readonly string SELECT_LOGINS = "";
        //public static readonly string SELECT_LOGINS = "";
        #endregion
    }
}