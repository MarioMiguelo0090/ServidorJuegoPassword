using AccesoADatos.Auxiliares;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class GestionAcceso
    {
        private static readonly log4net.ILog _bitacora= log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                
        public int RegistrarAcceso(Acceso nuevoAcceso,Jugador nuevoJugador,Perfil nuevoPerfil) 
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
                            Perfil perfil = new Perfil
                            {
                                nombreUsuario = nuevoPerfil.nombreUsuario,
                                descripcion = nuevoPerfil.descripcion,
                                rutaImagen = nuevoPerfil.rutaImagen,
                            };
                            contexto.Perfil.Add(perfil);
                            contexto.SaveChanges();
                            int idPerfil = perfil.idPerfil;
                            Jugador jugador = new Jugador
                            {
                                nombre = nuevoJugador.nombre,
                                apellidos = nuevoJugador.apellidos,
                                estadoJugador = nuevoJugador.estadoJugador,
                                FKidAcceso = idAcceso,
                                FKIdPerfil = idPerfil,
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
                            resultadoRegistro = -2;
                        }
                        catch (SqlException excepcionSQL)
                        {
                            _bitacora.Error(excepcionSQL);
                            contextoTransaccion.Rollback();
                            resultadoRegistro = -1;
                        }
                    }
                }
            }            
            catch (SqlException excepcionSQL)
            {
                _bitacora.Error(excepcionSQL);
                resultadoRegistro = -1;
            }
            return resultadoRegistro;                                 
        }
        
        public int RetonarIdAccesoPorCorreo(string correo) 
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
            catch (SqlException excepcionSql) 
            {
                _bitacora.Warn(excepcionSql);
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
            catch (SqlException excepcionSql)
            {
                _bitacora.Warn(excepcionSql);                
            }
            return contrasenia;
        }

        public int ValidarPresenciaCorreo(string correo) 
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
                _bitacora.Warn(excepcionSql);
                resultado = -1;
            }
            return resultado;
        }

        public Cuenta ObtenerCuentaPorCorreo(string correo) 
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var resultadoConsulta = (from jugador in contexto.Jugador
                                             join acceso in contexto.Acceso on jugador.FKidAcceso equals acceso.idAcceso
                                             join perfil in contexto.Perfil on jugador.FKIdPerfil equals perfil.idPerfil
                                             where acceso.correo == correo
                                             select new
                                             {
                                                 acceso.idAcceso,
                                                 acceso.correo,
                                                 acceso.contrasenia,
                                                 perfil.idPerfil,
                                                 perfil.nombreUsuario,
                                                 perfil.rutaImagen,
                                                 perfil.descripcion,
                                                 jugador.idJugador,
                                                 jugador.nombre,
                                                 jugador.apellidos,
                                             }).FirstOrDefault();
                    if (resultadoConsulta != null)
                    {
                        cuenta.IdAcceso = resultadoConsulta.idAcceso;
                        cuenta.Correo = resultadoConsulta.correo;
                        cuenta.Contrasenia = resultadoConsulta.contrasenia;
                        cuenta.IdPerfil = resultadoConsulta.idPerfil;
                        cuenta.NombreUsuario = resultadoConsulta.nombreUsuario;
                        cuenta.RutaImagen = resultadoConsulta.rutaImagen;
                        cuenta.Descripcion = resultadoConsulta.descripcion;
                        cuenta.IdJugador = resultadoConsulta.idJugador;
                        cuenta.Nombre = resultadoConsulta.nombre;
                        cuenta.Apellidos = resultadoConsulta.apellidos;
                    }
                    else 
                    {
                        cuenta.IdAcceso = 0;
                    }
                }
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Warn(excepcionSql);
                cuenta.IdAcceso = -1;
            }            
            return cuenta;                        
        }
        
    }
}
