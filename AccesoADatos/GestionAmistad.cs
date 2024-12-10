using AccesoADatos.Auxiliares;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class GestionAmistad
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int RegistrarNuevaSolicitudAmistad(Amistad nuevaAmistad)
        {
            int resultadoRegistroAmistad = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    Amistad amistad = new Amistad
                    {
                        idJugadorAmigo = nuevaAmistad.idJugadorAmigo,
                        fechaSolicitud = nuevaAmistad.fechaSolicitud,
                        FKidJugador = nuevaAmistad.FKidJugador,
                    };
                    contexto.Amistad.Add(amistad);
                    resultadoRegistroAmistad = contexto.SaveChanges();
                }
            }
            catch(DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoRegistroAmistad = Constantes.ValorError;
            }
            catch (DbEntityValidationException excepcionValidacion)
            {
                _bitacora.Warn(excepcionValidacion);
                resultadoRegistroAmistad = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoRegistroAmistad = Constantes.ValorError;
            }
            return resultadoRegistroAmistad;
        }

        public static int ConfirmarSolicitudAmistadPorIdAmistad(Amistad posibleAmistad)
        {
            int resultadoConfirmacion = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var amistad = contexto.Amistad.Find(posibleAmistad.idAmistad);
                    if (amistad != null)
                    {
                        amistad.respuesta = posibleAmistad.respuesta;
                        amistad.fechaRespuesta = posibleAmistad.fechaRespuesta;
                        resultadoConfirmacion = contexto.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoConfirmacion = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoConfirmacion = Constantes.ValorError;
            }
            return resultadoConfirmacion;
        }

        public static List<int> RecuperarSolicitudesAmistadPorIdJugador(int idJugador)
        {
            List<int> idJugadores = new List<int>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    idJugadores = contexto.Amistad
                        .Where(entidad => entidad.idJugadorAmigo == idJugador && entidad.respuesta == null)
                        .Select(entidad => entidad.FKidJugador)
                        .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                idJugadores.Insert(0, Constantes.ValorError); 
            }
            return idJugadores;
        }

        public static List<Jugador> RecuperarAmigosPorIdJugador(int idJugador)
        {
            List<Jugador> amigos = new List<Jugador>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {                    
                    var idsAmigos = contexto.Amistad
                        .Where(entidad =>
                            (entidad.FKidJugador == idJugador || entidad.idJugadorAmigo == idJugador) &&
                            entidad.respuesta == true)
                        .Select(entidad =>
                            entidad.FKidJugador == idJugador ? entidad.idJugadorAmigo : entidad.FKidJugador)
                        .Distinct()
                        .ToList();                    
                    amigos = contexto.Jugador
                        .Where(jugador => idsAmigos.Contains(jugador.idJugador))
                        .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                amigos.Insert(0, new Jugador { idJugador = Constantes.ValorError });
            }
            return amigos;
        }


        public static int ObtenerIdJugadorPorCorreo(string correo) 
        {
            int idJugador = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var acceso = contexto.Acceso.FirstOrDefault(entidad => entidad.correo == correo);
                    if (acceso != null)
                    {
                        var jugador = contexto.Jugador.FirstOrDefault(entidad => entidad.FKidAcceso == acceso.idAcceso);
                        if (jugador != null)
                        {
                            idJugador = jugador.idJugador;
                        }
                    }

                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                idJugador = Constantes.ValorError;
            }
            return idJugador;
        }

        public static List<string> RecuperarNombresDeUsuarioPorIdJugador(List<int> idJugadores) 
        {
            List<string> nombresUsuarios = new List<string>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    nombresUsuarios = contexto.Jugador
                    .Where(entidad => idJugadores.Contains(entidad.idJugador))
                    .Select(entidad => entidad.nombreUsuario)
                    .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                string nombreUsuario = Constantes.Excepcion;
                nombresUsuarios.Add(nombreUsuario);
            }
            return nombresUsuarios;
        }


        public static int ValidarExistenciaAmistadPorIdJugadores(int idJugadorRemitente, int idJugadorDestinatario) 
        {
            int validacionInexistenciaAmistad = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var amistad = contexto.Amistad.FirstOrDefault(entidad =>
                        (entidad.FKidJugador == idJugadorRemitente && entidad.idJugadorAmigo == idJugadorDestinatario) ||
                        (entidad.idJugadorAmigo == idJugadorRemitente && entidad.FKidJugador == idJugadorDestinatario));
                    if (amistad != null)
                    {
                        validacionInexistenciaAmistad = Constantes.ValorExitoso;
                    }
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                validacionInexistenciaAmistad = Constantes.ValorError;
            }        
            return validacionInexistenciaAmistad;
        }

        public static int ObtenerIdAmistadPorIdJugadores(int idJugadorUno, int idJugadorDos) 
        {
            int idAmistad = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades()) 
                {
                    var amistad = contexto.Amistad.FirstOrDefault(entidad =>
                        (entidad.FKidJugador == idJugadorUno && entidad.idJugadorAmigo == idJugadorDos));
                    if (amistad != null) 
                    {
                        idAmistad = amistad.idAmistad;
                    }
                }
            }
            catch (EntityException excepcionEntidad) 
            {
                _bitacora.Error(excepcionEntidad);
                idAmistad = Constantes.ValorError;
            }
            return idAmistad;
        }
    }
}
