using FarmaciaCRUD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Services
{
    public class FormaService
    {
        public List<Forma> ListaFormas()
        {
            // ruta para el archivo
            var dataFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/FormaFarmaceutica.txt");

            string[] lines = File.ReadAllLines(dataFile);

            var listado = new List<Forma>();

            foreach (string line in lines)
            {
                var lineArray = line.Split('|');

                // objeto para usuario encontrado
                var forma = new Forma();

                if (lineArray[0] != "IIDFORMAFARMACEUTICA")
                {
                    forma.IdFormaFarmaceutica = int.Parse(lineArray[0]);
                    forma.Nombre = lineArray[1];
                    forma.BHabilitado = int.Parse(lineArray[2]);

                    listado.Add(forma);
                }
            }
            return listado;
        }
    }
}