using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class GestionPerfil
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int ValidarPresenciaDeNombreUsuario(string nombreUsuario) 
        {
            int resultadoPresencia = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var perfil = contexto.Jugador.Any(entidad => entidad.nombreUsuario == nombreUsuario);
                    if (perfil)
                    {
                        resultadoPresencia = 1;
                    }
                }
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Warn(excepcionSql);
                resultadoPresencia = -1;
            }                            
            return resultadoPresencia;
        }

        public static int GuadarRutaImagenPorIdJugador(int idJugador,string rutaImagen) 
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var jugador = contexto.Jugador.Find(idJugador);
                    if (jugador != null)
                    {
                        jugador.rutaImagen = rutaImagen;
                        resultadoActualizacion = contexto.SaveChanges();
                    }                                      
                }
            }
            catch (DbUpdateException excepcionActualizacion) 
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -1;
            }
            return resultadoActualizacion;
        }

        public static int GuadarDescripcionPorIdJugador(int idJugador, string descripcion)
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var jugador = contexto.Jugador.Find(idJugador);
                    if (jugador != null)
                    {
                        jugador.descripcion = descripcion;
                        resultadoActualizacion = contexto.SaveChanges();
                    }                    
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -1;
            }
            return resultadoActualizacion;
        }

        public static int GuardarNombreUsuarioPorIdJugador(int idJugador, string nombreUsuario) 
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var jugador = contexto.Jugador.Find(idJugador);
                    if (jugador != null)
                    {
                        jugador.nombreUsuario = nombreUsuario;
                        resultadoActualizacion = contexto.SaveChanges();
                    }                    
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -1;
            }
            return resultadoActualizacion;
        }

        public static int GuardarCorreoPorIdAcceso(int idAcceso, string correo) 
        {
            int resultadoActualizacion = 0;
            try 
            {
                using (var contexto = new PasswordEntidades()) 
                {
                    var acceso = contexto.Acceso.Find(idAcceso);
                    if (acceso != null) 
                    {
                        acceso.correo = correo;
                        resultadoActualizacion = contexto.SaveChanges();
                    }                    
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -1;
            }
            return resultadoActualizacion;
        }

        public static int GuardarContraseniaPorIdAcceso(int idAcceso, string contrasenia) 
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var acceso = contexto.Acceso.Find(idAcceso);
                    if (acceso != null) 
                    {
                        acceso.contrasenia = contrasenia;
                        resultadoActualizacion = contexto.SaveChanges();
                    }                    
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (EntityException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -1;
            }
            return resultadoActualizacion;
        }

        public static int ObtenerIdAccesoPorCorreo(string correo) 
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
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                idAcceso = -1;
            }
            return idAcceso;
        }

        
    }
}
