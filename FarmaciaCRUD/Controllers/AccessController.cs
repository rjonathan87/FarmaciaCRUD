using FarmaciaCRUD.Models;
using FarmaciaCRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaCRUD.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            ViewBag.Title = "CRUD Farmacia";
            return View();
        }

        public ActionResult Login(string _user, string _password)
        {
            /* Consultar el usuario y contraseña a la ruta designada */
            LoginService ls = new LoginService();
            Usuario loginRequest = new Usuario();
            loginRequest.User = _user;
            loginRequest.Password = _password;

            var userResponse = ls.Login(loginRequest);

            if (userResponse == null)
            {
                TempData["error"] = "Datos incorrectos!!!";
                return Redirect("/Access/Index");
            }
            else
            {
                Session["IdUsuario"] = userResponse.IdUsuario;
                Session["Nombre"] = userResponse.Nombre;
                Session["User"] = userResponse.User;

                return Redirect("/Home/Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return Redirect("/Access/Index");
        }
    }
}