using FarmaciaCRUD.Models;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FarmaciaCRUD.Services
{
    public class LoginService
    {
        public Usuario Login(Usuario usuario)
        {
            using (var httpClient = new HttpClient())
            {
                // ruta para el archivo
                var dataFile = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Usuarios.txt");

                
                string[] lines = File.ReadAllLines(dataFile);

                foreach (string line in lines)
                {
                    var lineArray = line.Split('|');
                    if(lineArray[3] == usuario.User && lineArray[4] == usuario.Password)
                    {
                        // objeto para usuario encontrado
                        Usuario usuarioEncontrado = new Usuario();

                        usuarioEncontrado.IdUsuario = int.Parse(lineArray[0]);
                        usuarioEncontrado.Nombre = lineArray[1];
                        usuarioEncontrado.FechaCreacion = lineArray[2];
                        usuarioEncontrado.User = lineArray[3];
                        usuarioEncontrado.Password = lineArray[4];
                        usuarioEncontrado.IdPerfil = int.Parse(lineArray[5]);
                        usuarioEncontrado.Estatus = int.Parse(lineArray[6]);

                        return usuarioEncontrado;
                    }
                    
                }

                return null;
            }
        }
    }
}