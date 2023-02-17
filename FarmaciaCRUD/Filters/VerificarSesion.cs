using FarmaciaCRUD.Controllers;
using System;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaCRUD.Filters
{
    public class VerificarSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string Usuario;
            base.OnActionExecuting(filterContext);
            HttpContext context = HttpContext.Current;

            Usuario = (string)(context.Session["User"]);

            if (Usuario == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Access/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}