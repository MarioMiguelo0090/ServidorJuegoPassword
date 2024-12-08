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
        GestionPerfil _gestionPerfil=new GestionPerfil();

        public int EditarCorreoPorIdAcceso(int idAcceso, string correo)
        {
            return _gestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
        }

        public int EditarDescripcionPorIdJugador(int idJugador, string descripcion)
        {
            return _gestionPerfil.GuadarDescripcionPorIdJugador(idJugador, descripcion);
        }

        public int EditarNombreUsuarioPorIdJugador(int idJugador, string nombreUsuario)
        {
            return _gestionPerfil.GuardarNombreUsuarioPorIdJugador(idJugador, nombreUsuario);
        }

        public int EditarRutaImagenPorIdJugador(int idJugador, string rutaImagen)
        {            
            return _gestionPerfil.GuadarRutaImagenPorIdJugador(idJugador, rutaImagen);
        }

        public int EditarContraseniaPorIdAcceso(int idAcceso, string contrasenia)
        {            
            return _gestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso, contrasenia);
        }

        public int RecuperarIdAccesoPorCorreo(string correo)
        {
            return _gestionPerfil.ObtenerIdAccesoPorCorreo(correo);
        }
    }
}
