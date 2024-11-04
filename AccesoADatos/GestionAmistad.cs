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
            int resultadoRegistroAmistad = 0;
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
            catch (DbEntityValidationException excepcionValidacion)
            {
                _bitacora.Warn(excepcionValidacion);
                resultadoRegistroAmistad = -1;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Warn(excepcionEntidad);
                resultadoRegistroAmistad = -1;
            }
            return resultadoRegistroAmistad;
        }

        public int ConfirmarSolicitudAmistadPorIdAmistad(Amistad posibleAmistad)
        {
            int resultadoConfirmacion = 0;
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
                resultadoConfirmacion = -1;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoConfirmacion = -1;
            }
            return resultadoConfirmacion;
        }

        public List<Amistad> RecuperarSolicitudesAmistadPorIdJugador(int idJugador)
        {
            List<Amistad> amistades = new List<Amistad>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    amistades = contexto.Amistad.Where(jugador => jugador.FKidJugador == idJugador && jugador.respuesta == null)
                    .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                Amistad amistad = new Amistad
                {
                    idAmistad = -1
                };
                amistades.Insert(0, amistad);
            }
            return amistades;
        }

        public List<Amistad> RecuperarAmigosPorIdJugador(int idJugador)
        {
            List<Amistad> amistades = new List<Amistad>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    amistades = contexto.Amistad.Where(jugador => jugador.FKidJugador == idJugador && jugador.respuesta == true)
                    .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                Amistad amistad = new Amistad
                {
                    idAmistad = -1
                };
                amistades.Insert(0, amistad);
            }
            return amistades;
        }

        public int ObtenerIdJugadorPorCorreo(string correo) 
        {
            int idJugador = 0;
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
                idJugador = -1;
            }
            return idJugador;
        }

        public List<string> RecuperarJugadoresPorIdJugador(List<int> idJugadores) 
        {
            List<string> jugadores = new List<string>();
            try
            {
                using (var contexto = new PasswordEntidades()) 
                {
                    jugadores = contexto.Jugador
                               .Where(j => idJugadores.Contains(j.idJugador)) 
                               .Select(j => j.apellidos) 
                               .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                string jugador = "excepcion";
                jugadores.Add(jugador);
            }
            return jugadores;
        }

    }
}
