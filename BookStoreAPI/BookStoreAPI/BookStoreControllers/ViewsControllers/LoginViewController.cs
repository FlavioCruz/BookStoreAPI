using BookStoreAPI.BookStoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAPI.BookStoreControllers.ViewsControllers
{
    [UserValidation]
    public class LoginViewController : Controller
    {

        private UsuarioBusiness crud = UsuarioBusiness.instance;

        
        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> ValidateLogin(string usuario, string senha)
        {
            usuario = usuario == null ? "" : usuario;
            senha = senha == null ? "" : senha;
            var login = await crud.ListById(Querys.SELECT_LOGIN, usuario, senha);
            if(login != null)
            {
                CONSTANTES.currentUser = login;
                return View("~/Views/AssuntosView/Index.cshtml");
            }
            return View("Login");
        }
    }
}