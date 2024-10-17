using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AccesoADatos;
using ServicioJuegoPassword.Validadores;
using FluentValidation.Results;
using ServicioJuegoPassword.Interfaces;
using System.ServiceModel;

namespace ServicioJuegoPassword.Servicios
{
    
    public partial class ServicioPassword:IServicioGestionAcceso
    {
        private GestionAcceso _gestionAcceso = new GestionAcceso();
        private GestionPerfil _gestionPerfil = new GestionPerfil();

        public void RegistrarNuevoJugador(Acceso acceso, Perfil perfil, Jugador jugador)
        {
            if (ValidarNuevoRegistro(acceso, perfil, jugador)) {
                if (_gestionAcceso.ValidarPresenciaCorreo(acceso.correo) == 0)
                {
                    if (ValidarNombreUsuario(perfil.nombreUsuario))
                    {
                        string contraseniaEncriptada = EncriptarContrasenia(acceso.contrasenia);
                        acceso.contrasenia = contraseniaEncriptada;
                        _gestionAcceso.RegistrarAcceso(acceso,jugador,perfil);
                    }
                }
            }
        }

        public int ValidarInicioDeSesion(Acceso acceso)
        {
            int validacion = 0;
            if (_gestionAcceso.ValidarPresenciaCorreo(acceso.correo) > 0)
            {
                string contraseniaEncriptada = _gestionAcceso.RetornarContraseniaPorCorreo(acceso.correo);
                if (contraseniaEncriptada == EncriptarContrasenia(acceso.contrasenia))
                {
                    validacion = 1;
                }
            }
            return validacion;
        }

        public bool ValidarNuevoRegistro(Acceso acceso, Perfil perfil, Jugador jugador)
        {
            bool validacion = false;
            ValidacionAcceso validacionAcceso = new ValidacionAcceso();
            ValidacionJugador validacionJugador = new ValidacionJugador();
            ValidacionPerfil validacionPerfil = new ValidacionPerfil();
            ValidationResult resultadoAcceso = validacionAcceso.Validate(acceso);
            ValidationResult resultadoJugador = validacionJugador.Validate(jugador);
            ValidationResult resultadoPerfil = validacionPerfil.Validate(perfil);
            if (resultadoAcceso.IsValid && resultadoJugador.IsValid && resultadoPerfil.IsValid)
            {
                validacion = true;
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

        public bool ValidarNombreUsuario(string nombreUsuario)
        {
            bool validacion = false;
            if (_gestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario) == 0)
            {
                validacion = true;
            }
            return validacion;
        }

    }
}
