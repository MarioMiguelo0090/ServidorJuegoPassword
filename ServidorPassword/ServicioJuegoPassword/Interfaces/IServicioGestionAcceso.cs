using AccesoADatos;
using AccesoADatos.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract]
    public interface IServicioGestionAcceso
    {
        [OperationContract]  
        int RegistrarNuevoJugador(Acceso acceso, Perfil perfil, Jugador jugador);

        [OperationContract]
        int ValidarInicioDeSesion(Acceso acceso);
                
        [OperationContract]
        string EncriptarContrasenia(string contrasenia);

        [OperationContract]
        int ValidarNombreUsuario(string nombreUsuario);

        [OperationContract]
        Cuenta RecuperarCuentaPorCorreo(string correo);

        [OperationContract]
        int ValidarPresenciaDeCorreo(string correo);        
    }
}
