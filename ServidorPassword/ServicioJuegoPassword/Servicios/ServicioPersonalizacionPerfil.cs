using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioPersonalizacionPerfil
    {                        
        public int EditarCorreoPorIdAcceso(int idAcceso, string correo)
        {
            return GestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
        }

        public int EditarDescripcionPorIdJugador(int idJugador, string descripcion)
        {
            return GestionPerfil.GuadarDescripcionPorIdJugador(idJugador, descripcion);
        }

        public int EditarNombreUsuarioPorIdJugador(int idJugador, string nombreUsuario)
        {
            return GestionPerfil.GuardarNombreUsuarioPorIdJugador(idJugador, nombreUsuario);
        }

        public int EditarRutaImagenPorIdJugador(int idJugador, string rutaImagen)
        {            
            return GestionPerfil.GuadarRutaImagenPorIdJugador(idJugador, rutaImagen);
        }

        public int EditarContraseniaPorIdAcceso(int idAcceso, string contrasenia)
        {            
            return GestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso, contrasenia);
        }

        public int RecuperarIdAccesoPorCorreo(string correo)
        {
            return GestionPerfil.ObtenerIdAccesoPorCorreo(correo);
        }
    }
}
