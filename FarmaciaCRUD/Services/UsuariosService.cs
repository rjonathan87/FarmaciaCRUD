using FarmaciaCRUD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FarmaciaCRUD.Services
{
    public class UsuariosService
    {
        public List<Usuario> ListaUsuarios()
        {
            // ruta para el archivo
            var dataFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Usuarios.txt");

            string[] lines = File.ReadAllLines(dataFile);

            var listado = new List<Usuario>();

            foreach (string line in lines)
            {
                var lineArray = line.Split('|');

                // objeto para usuario encontrado
                var usuario = new Usuario();

                if (lineArray[0] != "idusuario")
                {
                    usuario.IdUsuario= int.Parse(lineArray[0]);
                    usuario.Nombre = lineArray[1];
                    usuario.FechaCreacion = lineArray[2];
                    usuario.User = lineArray[3];
                    usuario.Password = lineArray[4];
                    usuario.IdPerfil = int.Parse(lineArray[5]);
                    usuario.Estatus = int.Parse(lineArray[6]);
                    
                    listado.Add(usuario);
                }
            }
            return listado;
        }
    }
}