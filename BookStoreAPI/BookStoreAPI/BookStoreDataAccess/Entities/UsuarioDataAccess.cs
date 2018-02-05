using BookStoreAPI.BookStoreDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.BookStoreDataAccess.Entities
{
    // onde deve se implementar regras restritivas de banco
    public class UsuarioDataAccess : DBDataAccess, IUsuarioDataAccess
    {
    }
}