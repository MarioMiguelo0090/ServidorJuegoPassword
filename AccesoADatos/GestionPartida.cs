﻿using AccesoADatos.Auxiliares;
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
    public class GestionPartida
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int RegistrarNuevaPartidaPorIdJugador(int idJugador, Partida nuevaPartida)
        {
            int registroNuevaPartida = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    using (var contextoTransaccion = contexto.Database.BeginTransaction())
                    {
                        try
                        {
                            Partida partida = new Partida
                            {
                                codigoPartida = nuevaPartida.codigoPartida,
                                modoJuego = nuevaPartida.modoJuego,
                                estadoPartida = nuevaPartida.estadoPartida,
                                idAnfitrion = idJugador,
                            };
                            contexto.Partida.Add(partida);
                            contexto.SaveChanges();
                            int idPartida = partida.idPartida;
                            DetallePartida detallePartida = new DetallePartida
                            {
                                FKidJugador = idJugador,
                                FKidPartida = idPartida,
                            };
                            contexto.DetallePartida.Add(detallePartida);
                            contexto.SaveChanges();
                            contextoTransaccion.Commit();
                            registroNuevaPartida = Constantes.ValorExitoso;
                        }
                        catch (DbEntityValidationException excepcionValidacion)
                        {
                            _bitacora.Warn(excepcionValidacion);
                            contextoTransaccion.Rollback();
                            registroNuevaPartida = Constantes.ValorError;
                        }
                        catch (EntityException excepcionEntidad)
                        {
                            _bitacora.Error(excepcionEntidad);
                            contextoTransaccion.Rollback();
                            registroNuevaPartida = Constantes.ValorError;
                        }
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                registroNuevaPartida = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                registroNuevaPartida = Constantes.ValorError;
            }
            return registroNuevaPartida;
        }

        public static int ActualizarEstadoDePartidaPorIdPartida(int idPartida, string nuevoEstado)
        {
            int resultadoActualizacionEstado = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var partida = contexto.Partida.Find(idPartida);
                    if (partida != null) {
                        partida.estadoPartida = nuevoEstado;
                        resultadoActualizacionEstado = contexto.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacionEstado = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoActualizacionEstado = Constantes.ValorError;
            }
            return resultadoActualizacionEstado;
        }

        public int ValidarInexistenciaCodigoPartida(string codigoPartida)
        {
            int resultadoInexistencia = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var partida = contexto.Partida.Any(entidad => entidad.codigoPartida == codigoPartida);
                    if (partida)
                    {
                        resultadoInexistencia = Constantes.ValorExitoso;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Warn(excepcionSql);
                resultadoInexistencia = Constantes.ValorError;
            }
            return resultadoInexistencia;
        }

        public List<Pregunta> RecuperarPreguntas()
        {
            List<Pregunta> preguntas = new List<Pregunta>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    preguntas = contexto.Pregunta.ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                Pregunta pregunta = new Pregunta
                {
                    idPregunta = Constantes.ValorError,
                };
                preguntas.Insert(0, pregunta);
            }
            return preguntas;
        }

        public List<Respuesta> RecuperarRespuestasPorIdPregunta(int idPregunta)
        {
            List<Respuesta> respuestas = new List<Respuesta>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    respuestas = contexto.Respuesta.Where(respuesta => respuesta.FKidPregunta == idPregunta)
                        .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                Respuesta respuesta = new Respuesta
                {
                    idRespuesta = Constantes.ValorError,
                };
                respuestas.Insert(0, respuesta);
            }
            return respuestas;
        }

        public static Partida ObtenerPartidaPorCodigoPartida(string codigoPartida)
        {
            Partida partida = new Partida();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    partida = contexto.Partida.FirstOrDefault(entidad => entidad.codigoPartida == codigoPartida);                    
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                partida = new Partida
                {
                    idPartida = Constantes.ValorError
                };
            }
            return partida;
        }

        public List<Respuesta> ObtenerRespuestasPorIdPreguntas(List<int> idPreguntas)
        {
            List<Respuesta> respuestasObtenidas = new List<Respuesta>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    respuestasObtenidas = contexto.Respuesta
                    .Where(entidad => idPreguntas.Contains(entidad.FKidPregunta))
                    .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                Respuesta respuesta = new Respuesta
                {
                    idRespuesta = Constantes.ValorError
                };
                respuestasObtenidas.Insert(0, respuesta);
            }
            return respuestasObtenidas;
        }

        public int VerificarCatalogoPreguntas() 
        {
            int verificacionCatalogoPreguntas = Constantes.ValorNeutro;

            try
            {
                using (var contexto = new PasswordEntidades())
                {                    
                    int totalPreguntas = contexto.Pregunta.Count();

                    if (totalPreguntas >= Constantes.NumeroPreguntasCatalogo)
                    {
                        verificacionCatalogoPreguntas = Constantes.ValorExitoso;
                    }                  
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                verificacionCatalogoPreguntas = Constantes.ValorError;
            }
            return verificacionCatalogoPreguntas;
        }

        public int VerificarCatalogoRespuestas()
        {
            int verificacionCatalogoRespuestas = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    int totalRespuestas = contexto.Respuesta.Count();
                    if (totalRespuestas >= Constantes.NumeroRespuestasCatalogo)
                    {
                        verificacionCatalogoRespuestas = Constantes.ValorExitoso;
                    }
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                verificacionCatalogoRespuestas = Constantes.ValorError;
            }
            return verificacionCatalogoRespuestas;
        }
    }
}
