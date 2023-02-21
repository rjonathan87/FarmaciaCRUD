using FarmaciaCRUD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Services
{
    // ruta para el archivo

    public class MedicamentosService
    {
        protected string dataFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Medicamentos.txt");

        public void NuevoMedicamento(Medicamento medicamento)
        {
            // buscar el id max de la lista
            var lines = File.ReadAllLines(dataFile);
            var lista = ListaMedicamentos();

            List<int> Ids = new List<int>();
            var index = 0;

            // array con todos los IDS
            foreach (string line in lines)
            {
                var lineArray = line.Split('|');

                if (lineArray[0] != "IIDMEDICAMENTO")
                {
                    Ids.Add( int.Parse(lineArray[0]));
                }

                index++;
            }

            var IdNuevo = Ids.Max() + 1;
            medicamento.IdMedicamento = IdNuevo;
            var nuevaLinea = "";
            nuevaLinea = medicamento.IdMedicamento + "|" + medicamento.Nombre + "|" + medicamento.Concentracion + "|" + medicamento.IdFormaFarmaceutica + "|" + medicamento.Precio + "|" + medicamento.Stock + "|" + medicamento.Presentacion + "|" + medicamento.BHabilitado;

            // se escriben los datos en el archivo
            StreamWriter sw = new StreamWriter(dataFile, true);
            sw.WriteLine(nuevaLinea);

            sw.Close();
        }

        public List<Medicamento> ListaMedicamentos()
        {
            
            var lines = File.ReadAllLines(dataFile);

            var listado = new List<Medicamento>();

            foreach (string line in lines)
            {
                if(line != "")
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
            }
            return listado;
        }
        public Medicamento BuscarMedicamento(string IdMedicamento)
        {
            string[] lines = File.ReadAllLines(dataFile);

            var medicamento = new Medicamento();
            foreach (string line in lines)
            {
                var lineArray = line.Split('|');

                // objeto para usuario encontrado
                if(lineArray[0] == IdMedicamento)
                {
                    medicamento.IdMedicamento = int.Parse(lineArray[0]);
                    medicamento.Nombre = lineArray[1];
                    medicamento.Concentracion = lineArray[2];
                    medicamento.IdFormaFarmaceutica = int.Parse(lineArray[3]);
                    medicamento.Precio = float.Parse(lineArray[4]);
                    medicamento.Stock = int.Parse(lineArray[5]);
                    medicamento.Presentacion = lineArray[6];
                    medicamento.BHabilitado = int.Parse(lineArray[7]);

                    return medicamento;
                }
            }
            return null;
        }
        public void GuardarMedicamento(Medicamento medicamento, int IdMedicamento)
        {
            string[] lines = File.ReadAllLines(dataFile);
            int index = 0;

            foreach (string line in lines)
            {
                var linea = line;
                var lineArray = line.Split('|');

                // objeto para medicamento encontrado
                if (lineArray[0] != "IIDMEDICAMENTO")
                {
                    if (int.Parse(lineArray[0]) == IdMedicamento)
                    {
                        // se encuentra la línea que se reemplaza
                        linea = medicamento.IdMedicamento + "|" +
                        medicamento.Nombre + "|" +
                        medicamento.Concentracion + "|" +
                        medicamento.IdFormaFarmaceutica + "|" +
                        medicamento.Precio + "|" +
                        medicamento.Stock + "|" +
                        medicamento.Presentacion + "|" +
                        medicamento.BHabilitado;
                        lines[index] = linea;
                    }
                    else
                    {
                        lines[index] = line;
                    }
                }

                index++;
            }

            // se escriben los datos en el archivo
            using (StreamWriter outputFile = new StreamWriter(dataFile))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }
        public void EliminarMedicamento(int IdMedicamento)
        {
            string[] lines = File.ReadAllLines(dataFile);
            int index = 0;

            foreach (string line in lines)
            {
                if(index > 0)
                {
                    var lineArray = line.Split('|');

                    // objeto para medicamento encontrado
                    if (lineArray[0] != "")
                    {
                        if (int.Parse(lineArray[0]) == IdMedicamento)
                        {
                            if (int.Parse(lineArray[0]) != IdMedicamento)
                            {
                                lines[index] = line;
                            }
                            else {
                                lines[index] = "";
                            }
                        }
                    }
                }
                index++;
            }
            // se escriben los datos en el archivo
            using (StreamWriter outputFile = new StreamWriter(dataFile))
            {
                foreach (string line in lines)
                {
                    if(line != "")
                        outputFile.WriteLine(line);
                }
            }
        }
    }
}