using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AccesoADatos;
using FluentValidation.Results;
using ServicioJuegoPassword.Interfaces;
using System.ServiceModel;
using AccesoADatos.Auxiliares;

namespace ServicioJuegoPassword.Servicios
{    
    public partial class ServicioPassword:IServicioGestionAcceso
    {
        private GestionAcceso _gestionAcceso = new GestionAcceso();        
        
        public int RegistrarNuevoJugador(Acceso acceso, Jugador jugador)
        {            
            return _gestionAcceso.RegistrarAcceso(acceso,jugador);                                             
        }

        public int ValidarInicioDeSesion(Acceso acceso)
        {
            int validacion = 0;            
            GestionAcceso gestionAcceso = new GestionAcceso();
            string contraseniaEncriptada = gestionAcceso.RetornarContraseniaPorCorreo(acceso.correo);
            if (contraseniaEncriptada == acceso.contrasenia)
            {
                validacion = 1;
            }
            else if (contraseniaEncriptada == "excepcion") 
            {
                validacion = -1;
            }            
            return validacion;
        }                

        public int ValidarNombreUsuario(string nombreUsuario)
        {
            return GestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);            
        }

        public int ValidarPresenciaDeCorreo(string correo) 
        {
            return GestionAcceso.ValidarPresenciaCorreo(correo);            
        }

        public Cuenta RecuperarCuentaPorCorreo(string correo) 
        {
            Cuenta cuentaRecuperada=GestionAcceso.ObtenerCuentaPorCorreo(correo);
            return cuentaRecuperada;
        }

        public Cuenta RecuperarCuentaPorIdJugador(int idJugador)
        {
            return GestionAcceso.RecuperarCuentaPorIdJugador(idJugador);
        }
    }
}
