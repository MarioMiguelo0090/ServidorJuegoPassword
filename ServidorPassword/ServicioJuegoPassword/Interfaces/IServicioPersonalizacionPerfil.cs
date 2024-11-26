using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract]
    public interface IServicioPersonalizacionPerfil
    {
        [OperationContract]
        int EditarCorreoPorIdAcceso(int idAcceso,string correo);

        [OperationContract]
        int EditarDescripcionPorIdJugador(int idJugador,string descripcion);

        [OperationContract]
        int EditarNombreUsuarioPorIdJugador(int idJugador, string nombreUsuario);

        [OperationContract]
        int EditarRutaImagenPorIdJugador(int idJugador, string rutaImagen);

        [OperationContract]
        int EditarContraseniaPorIdAcceso(int idAcceso,string contrasenia);

        [OperationContract]
        int RecuperarIdAccesoPorCorreo(string correo);
    }
}
