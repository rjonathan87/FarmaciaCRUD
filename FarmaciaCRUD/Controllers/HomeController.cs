using FarmaciaCRUD.Models;
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
        public ActionResult Agregar()
        {
            // lista formas
            var lista = new FormaService();
            var listaFormas = lista.ListaFormas();
            ViewBag.listaFormas = listaFormas;

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(
                string Nombre,
                string Concentracion,
                int IdFormaFarmaceutica,
                float Precio,
                int Stock,
                string Presentacion,
                int BHabilitado
            )
        {
            var nuevoMedicamento = new Medicamento();
            nuevoMedicamento.Nombre = Nombre;
            nuevoMedicamento.Concentracion = Concentracion;
            nuevoMedicamento.IdFormaFarmaceutica = IdFormaFarmaceutica;
            nuevoMedicamento.Precio = Precio;
            nuevoMedicamento.Stock = Stock;
            nuevoMedicamento.Presentacion = Presentacion;
            nuevoMedicamento.BHabilitado = BHabilitado;

            var medicamento = new MedicamentosService();
            medicamento.NuevoMedicamento(nuevoMedicamento);

            return Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult Guardar(
            int IdMedicamento,
            string Nombre,
            string Concentracion,
            int IdFormaFarmaceutica,
            float Precio,
            int Stock,
            string Presentacion,
            int BHabilitado
        )
        {
            Medicamento medicamentoPOST = new Medicamento();
            medicamentoPOST.IdMedicamento = IdMedicamento;
            medicamentoPOST.Nombre = Nombre;
            medicamentoPOST.Concentracion = Concentracion;
            medicamentoPOST.IdFormaFarmaceutica = IdFormaFarmaceutica;
            medicamentoPOST.Precio = Precio;
            medicamentoPOST.Stock = Stock;
            medicamentoPOST.Presentacion = Presentacion;
            medicamentoPOST.BHabilitado = BHabilitado;

            // recuperar la línea que coincide con el id del registro enviado
            var servicioMedicamentos = new MedicamentosService();
            servicioMedicamentos.GuardarMedicamento(medicamentoPOST, IdMedicamento);


            return Redirect("/Home/Index");
        }
        public ActionResult Eliminar(int IdMedicamento)
        {
            // recuperar la línea que coincide con el id del registro enviado
            var servicioMedicamentos = new MedicamentosService();
            servicioMedicamentos.EliminarMedicamento(IdMedicamento);


            return Redirect("/Home/Index");
        }
    }
}