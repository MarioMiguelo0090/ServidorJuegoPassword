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
        int RegistrarNuevoJugador(Acceso acceso, Jugador jugador);

        [OperationContract]
        int ValidarInicioDeSesion(Acceso acceso);        

        [OperationContract]
        int ValidarNombreUsuario(string nombreUsuario);

        [OperationContract]
        Cuenta RecuperarCuentaPorCorreo(string correo);

        [OperationContract]
        int ValidarPresenciaDeCorreo(string correo);

        [OperationContract]
        Cuenta RecuperarCuentaPorIdJugador(int idJugador);

        [OperationContract]
        int ValidarPresenciaCuenta(string nombreUsuario, string correo);
    }
}
