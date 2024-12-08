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
        GestionAcceso _gestionAcceso = new GestionAcceso();        
        
        public int RegistrarNuevoJugador(Acceso acceso, Jugador jugador)
        {                                                  
            return _gestionAcceso.RegistrarAcceso(acceso, jugador);
        }

        public int ValidarInicioDeSesion(Acceso acceso)
        {
            int validacion = 0;                        
            string contraseniaEncriptada = _gestionAcceso.RetornarContraseniaPorCorreo(acceso.correo);
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
            return _gestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);            
        }

        public int ValidarPresenciaDeCorreo(string correo) 
        {
            return _gestionAcceso.ValidarPresenciaCorreo(correo);            
        }

        public Cuenta RecuperarCuentaPorCorreo(string correo) 
        {            
            return _gestionAcceso.ObtenerCuentaPorCorreo(correo);
        }

        public Cuenta RecuperarCuentaPorIdJugador(int idJugador)
        {
            return _gestionAcceso.RecuperarCuentaPorIdJugador(idJugador);
        }

        public int ValidarPresenciaCuenta(string nombreUsuario, string correo)
        {
            return _gestionAcceso.VerificarRegistroCuenta(nombreUsuario, correo);
        }
    }
}
