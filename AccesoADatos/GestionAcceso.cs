using AccesoADatos.Auxiliares;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace AccesoADatos
{
    public class GestionAcceso
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int RegistrarAcceso(Acceso nuevoAcceso, Jugador nuevoJugador)
        {
            int resultadoRegistro = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    using (var contextoTransaccion = contexto.Database.BeginTransaction())
                    {
                        try
                        {
                            Acceso acceso = new Acceso
                            {
                                correo = nuevoAcceso.correo,
                                contrasenia = nuevoAcceso.contrasenia,
                            };
                            contexto.Acceso.Add(acceso);
                            contexto.SaveChanges();
                            int idAcceso = acceso.idAcceso;
                            Estadistica estadistica = new Estadistica
                            {
                                puntaje = 0,
                                partidasGanadas = 0,
                                partidasPerdidas = 0,
                            };
                            contexto.Estadistica.Add(estadistica);
                            contexto.SaveChanges();
                            int idEstadisitca = estadistica.idEstadistica;
                            Jugador jugador = new Jugador
                            {
                                nombreUsuario = nuevoJugador.nombreUsuario,
                                descripcion = nuevoJugador.descripcion,
                                rutaImagen = nuevoJugador.rutaImagen,
                                FKidAcceso = idAcceso,
                                FKidEstadistica = idEstadisitca,
                            };
                            contexto.Jugador.Add(jugador);
                            contexto.SaveChanges();
                            contextoTransaccion.Commit();
                            resultadoRegistro = 1;
                        }
                        catch (DbEntityValidationException excepcionValidacion)
                        {
                            _bitacora.Warn(excepcionValidacion);
                            contextoTransaccion.Rollback();
                            resultadoRegistro = -1;
                        }
                        catch (EntityException excepcionSQL)
                        {
                            _bitacora.Error(excepcionSQL);
                            contextoTransaccion.Rollback();
                            resultadoRegistro = -1;
                        }
                    }
                }
            }
            catch (EntityException excepcionSQL)
            {
                _bitacora.Error(excepcionSQL);
                resultadoRegistro = -1;
            }
            return resultadoRegistro;
        }

        public static int RetonarIdAccesoPorCorreo(string correo)
        {
            int idAcceso = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var acceso = contexto.Acceso.FirstOrDefault(entidad => entidad.correo == correo);
                    if (acceso != null)
                    {
                        idAcceso = acceso.idAcceso;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                idAcceso = -1;
            }
            return idAcceso;
        }

        public string RetornarContraseniaPorCorreo(string correo)
        {
            string contrasenia = "";
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var acceso = contexto.Acceso.FirstOrDefault(entidad => entidad.correo == correo);
                    if (acceso != null)
                    {
                        contrasenia = acceso.contrasenia;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                contrasenia = "excepcion";
            }
            return contrasenia;
        }

        public static int ValidarPresenciaCorreo(string correo)
        {
            int resultado = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var acceso = contexto.Acceso.Any(entidad => entidad.correo == correo);
                    if (acceso)
                    {
                        resultado = 1;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultado = -1;
            }
            return resultado;
        }

        public static Cuenta ObtenerCuentaPorCorreo(string correo)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var resultadoConsulta = (from jugador in contexto.Jugador
                                             join acceso in contexto.Acceso on jugador.FKidAcceso equals acceso.idAcceso
                                             where acceso.correo == correo
                                             select new
                                             {
                                                 acceso.idAcceso,
                                                 acceso.correo,
                                                 acceso.contrasenia,
                                                 jugador.nombreUsuario,
                                                 jugador.rutaImagen,
                                                 jugador.descripcion,
                                                 jugador.idJugador,
                                                 jugador.FKidEstadistica,
                                             }).FirstOrDefault();
                    if (resultadoConsulta != null)
                    {
                        cuenta.IdAcceso = resultadoConsulta.idAcceso;
                        cuenta.Correo = resultadoConsulta.correo;
                        cuenta.Contrasenia = resultadoConsulta.contrasenia;
                        cuenta.NombreUsuario = resultadoConsulta.nombreUsuario;
                        cuenta.RutaImagen = resultadoConsulta.rutaImagen;
                        cuenta.Descripcion = resultadoConsulta.descripcion;
                        cuenta.IdJugador = resultadoConsulta.idJugador;
                        cuenta.IdEstadistica = resultadoConsulta.FKidEstadistica ?? 0;
                    }
                    else
                    {
                        cuenta.IdAcceso = 0;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                cuenta.IdAcceso = -1;
            }
            return cuenta;
        }

        public static Cuenta RecuperarCuentaPorIdJugador(int idJugador)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var resultadoConsulta = (from jugador in contexto.Jugador
                                             join acceso in contexto.Acceso on jugador.FKidAcceso equals acceso.idAcceso
                                             where jugador.idJugador == idJugador
                                             select new
                                             {
                                                 acceso.idAcceso,
                                                 acceso.correo,
                                                 jugador.nombreUsuario,
                                                 jugador.rutaImagen,
                                                 jugador.descripcion,
                                                 jugador.idJugador,
                                                 jugador.FKidEstadistica,
                                             }).FirstOrDefault();
                    if (resultadoConsulta != null)
                    {
                        cuenta.IdAcceso = resultadoConsulta.idAcceso;
                        cuenta.Correo = resultadoConsulta.correo;
                        cuenta.NombreUsuario = resultadoConsulta.nombreUsuario;
                        cuenta.RutaImagen = resultadoConsulta.rutaImagen;
                        cuenta.Descripcion = resultadoConsulta.descripcion;
                        cuenta.IdJugador = resultadoConsulta.idJugador;
                        cuenta.IdEstadistica = resultadoConsulta.FKidEstadistica ?? 0;
                    }
                    else
                    {
                        cuenta.IdAcceso = 0;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                cuenta.IdAcceso = -1;
            }
            return cuenta;
        }

    }
}