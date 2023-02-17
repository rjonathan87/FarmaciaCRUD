using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Models
{
    public class Forma
    {
        public int IdFormaFarmaceutica { get; set; }
        public string Nombre { get; set; }
        public int BHabilitado { get; set; }
    }
}