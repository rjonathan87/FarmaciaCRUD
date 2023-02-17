using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Models
{
    public class Medicamento
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string Concentracion { get; set; }
        public int IdFormaFarmaceutica { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public string Presentacion { get; set; }
        public int BHabilitado { get; set; }
    }
}