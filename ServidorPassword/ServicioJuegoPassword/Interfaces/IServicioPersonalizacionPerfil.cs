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
        int EditarDescripcionPorIdPerfil(int idPerfil,string descripcion);

        [OperationContract]
        int EditarNombreUsuarioPorIdPerfil(int idPerfil, string nombreUsuario);

        [OperationContract]
        int EditarRutaImagenPorIdPerfil(int idPerfil, string rutaImagen);

        [OperationContract]
        int EditarContraseniaPorIdAcceso(int idAcceso,string contrasenia);        
    }
}
