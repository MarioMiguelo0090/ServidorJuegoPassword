using System;
using System.Collections.Generic;
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
        private static readonly log4net.ILog _bitacora = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int ValidarPresenciaDeNombreUsuario(string nombreUsuario) 
        {
            int resultado = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var perfil = contexto.Perfil.Any(entidad => entidad.nombreUsuario == nombreUsuario);
                    if (perfil)
                    {
                        resultado = 1;
                    }
                }
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Warn(excepcionSql);
                resultado = -1;
            }                            
            return resultado;
        }


        public int GuadarRutaImagenPorIdPerfil(int idPerfil,string rutaImagen) 
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var perfil = contexto.Perfil.Find(idPerfil);
                    perfil.rutaImagen = rutaImagen;
                    resultadoActualizacion = contexto.SaveChanges();
                }
            }
            catch (DbUpdateException excepcionActualizacion) 
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -2;
            }
            return resultadoActualizacion;
        }

        public int GuadarDescripcionPorIdPerfil(int idPerfil, string descripcion)
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var perfil = contexto.Perfil.Find(idPerfil);
                    perfil.descripcion = descripcion;
                    resultadoActualizacion = contexto.SaveChanges();
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -2;
            }
            return resultadoActualizacion;
        }

        public int GuardarNombreUsuarioPorIdPerfil(int idPerfil, string nombreUsuario) 
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var perfil = contexto.Perfil.Find(idPerfil);
                    perfil.nombreUsuario = nombreUsuario;
                    resultadoActualizacion = contexto.SaveChanges();
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -2;
            }
            return resultadoActualizacion;
        }

        public int GuardarCorreoPorIdAcceso(int idAcceso, string correo) 
        {
            int resultadoActualizacion = 0;
            try 
            {
                using (var contexto = new PasswordEntidades()) 
                {
                    var acceso = contexto.Acceso.Find(idAcceso);
                    acceso.correo = correo;
                    resultadoActualizacion = contexto.SaveChanges();
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -2;
            }
            return resultadoActualizacion;
        }

        public int GuardarContraseniaPorIdAcceso(int idAcceso, string contrasenia) 
        {
            int resultadoActualizacion = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var acceso = contexto.Acceso.Find(idAcceso);
                    acceso.contrasenia = contrasenia;
                    resultadoActualizacion = contexto.SaveChanges();
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoActualizacion = -1;
            }
            catch (SqlException excepcionSql)
            {
                _bitacora.Error(excepcionSql);
                resultadoActualizacion = -2;
            }
            return resultadoActualizacion;
        }

    }
}
