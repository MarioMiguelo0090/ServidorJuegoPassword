using AccesoADatos;
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
        void RegistrarNuevoJugador(Acceso acceso, Perfil perfil, Jugador jugador);

        [OperationContract]
        int ValidarInicioDeSesion(Acceso acceso);

        [OperationContract]
        bool ValidarNuevoRegistro(Acceso acceso, Perfil perfil, Jugador jugador);

        [OperationContract]
        string EncriptarContrasenia(string contrasenia);

        [OperationContract]
        bool ValidarNombreUsuario(string nombreUsuario);
    }
}
