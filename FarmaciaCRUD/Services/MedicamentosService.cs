using FarmaciaCRUD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Services
{
    public class MedicamentosService
    {
        public List<Medicamento> ListaMedicamentos()
        {
            // ruta para el archivo
            var dataFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Medicamentos.txt");

            string[] lines = File.ReadAllLines(dataFile);

            var listado = new List<Medicamento>();

            foreach (string line in lines)
            {
                var lineArray = line.Split('|');

                // objeto para usuario encontrado
                var medicamento = new Medicamento();

                if(lineArray[0] != "IIDMEDICAMENTO")
                {
                    medicamento.IdMedicamento = int.Parse(lineArray[0]);
                    medicamento.Nombre = lineArray[1];
                    medicamento.Concentracion = lineArray[2];
                    medicamento.IdFormaFarmaceutica = int.Parse(lineArray[3]);
                    medicamento.Precio = float.Parse(lineArray[4]);
                    medicamento.Stock = int.Parse(lineArray[5]);
                    medicamento.Presentacion = lineArray[6];
                    medicamento.BHabilitado = int.Parse(lineArray[7]);

                    listado.Add(medicamento);
                }
            }
            return listado;
        }
    }
}