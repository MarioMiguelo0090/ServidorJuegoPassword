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
        private GestionPerfil _gestionPerfil = new GestionPerfil();

        public int RegistrarNuevoJugador(Acceso acceso, Jugador jugador)
        {
            string contraseniaEncriptada = EncriptarContrasenia(acceso.contrasenia);
            acceso.contrasenia = contraseniaEncriptada;
            return _gestionAcceso.RegistrarAcceso(acceso,jugador);                                             
        }

        public int ValidarInicioDeSesion(Acceso acceso)
        {
            int validacion = 0;            
            string contraseniaEncriptada = _gestionAcceso.RetornarContraseniaPorCorreo(acceso.correo);
            if (contraseniaEncriptada == EncriptarContrasenia(acceso.contrasenia))
            {
                validacion = 1;
            }
            else if (contraseniaEncriptada == "excepcion") 
            {
                validacion = -1;
            }            
            return validacion;
        }
        
        public string EncriptarContrasenia(string contrasenia)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
            var constructorCadena = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                constructorCadena.Append(bytes[i].ToString("x2"));
            }
            return constructorCadena.ToString();
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
            Cuenta cuentaRecuperada=_gestionAcceso.ObtenerCuentaPorCorreo(correo);
            return cuentaRecuperada;
        }

        public Cuenta RecuperarCuentaPorIdJugador(int idJugador)
        {
            return _gestionAcceso.RecuperarCuentaPorIdJugador(idJugador);
        }
    }
}
