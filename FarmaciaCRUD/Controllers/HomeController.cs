using FarmaciaCRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmaciaCRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Lista de medicamentos disponibles";

            // traer la lista de medicamentos
            var lista = new MedicamentosService();
            var listaMedicamentos = lista.ListaMedicamentos();
            ViewBag.listaMedicamentos = listaMedicamentos;

            return View();
        }

        public ActionResult Formas()
        {
            var lista = new FormaService();
            var listaFormas = lista.ListaFormas();
            ViewBag.listaFormas = listaFormas;
            return View();
        }

        public ActionResult Users()
        {
            var lista = new UsuariosService();
            var listaUsuarios = lista.ListaUsuarios();
            ViewBag.listaUsuarios = listaUsuarios;
            return View();
        }

        public ActionResult Editar(string IdMedicamento)
        {
            // lista formas
            var lista = new FormaService();
            var listaFormas = lista.ListaFormas();
            ViewBag.listaFormas = listaFormas;

            // recuperar el Medicamento por su id para ponerlo en el formulario
            var servicioMedicamentos = new MedicamentosService();
            var medicamento = servicioMedicamentos.BuscarMedicamento(IdMedicamento);
            ViewBag.Medicamento = medicamento;

            return View();
        }
        public ActionResult Guardar()
        {

            return Redirect("/Home/Index");
        }
    }
}