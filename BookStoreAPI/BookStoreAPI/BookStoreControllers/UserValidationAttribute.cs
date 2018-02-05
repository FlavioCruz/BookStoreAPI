using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStoreAPI.BookStoreControllers
{
    public class UserValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            if (CONSTANTES.currentUser != null)
            {
                var url = urlHelper.Action("../AssuntosView/Index");
                System.Web.HttpContext.Current.Response.Redirect(url);
            }else
            {
                if (!CONSTANTES.alreadyValidated)
                {
                    CONSTANTES.alreadyValidated = true;
                    var url = urlHelper.Action("../LoginView/Login");
                    System.Web.HttpContext.Current.Response.Redirect(url);
                }
                
            }
            

        }
    }
}