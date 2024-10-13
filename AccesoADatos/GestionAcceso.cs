using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccesoADatos
{
    public class GestionAcceso
    {
        private static readonly log4net.ILog Bitacora= log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public int RegistrarAcceso(Acceso _acceso) 
        {            
            int resultadoRegistro = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    Acceso acceso = new Acceso
                    {
                        correo = _acceso.correo,
                        contrasenia = _acceso.contrasenia,
                    };
                    contexto.Acceso.Add(acceso);
                    resultadoRegistro = contexto.SaveChanges();
                }
            }
            catch (DbEntityValidationException excepcionValidacion)
            {
                foreach (var validationErrors in excepcionValidacion.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Bitacora.Warn($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                resultadoRegistro = -1;
            }
            catch (SqlException excepcionSQL)
            {
                Bitacora.Error(excepcionSQL);
                resultadoRegistro = -1;
            }
            return resultadoRegistro;                                 
        }
    }
}
