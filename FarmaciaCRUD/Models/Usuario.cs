using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacion { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int IdPerfil { get; set; }
        public int Estatus { get; set; }
    }
}