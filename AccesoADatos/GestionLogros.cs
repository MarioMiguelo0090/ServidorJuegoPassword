using AccesoADatos.Auxiliares;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class GestionLogros
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int RegistrarLogroPorIdJugador(int idJugador, int idLogro) 
        {
            int resultadoRegitroLogro = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var detalleLogro = new DetalleLogro() 
                    {
                        FKIdJugador = idJugador,
                        FKIdLogro = idLogro,
                    };
                    contexto.DetalleLogro.Add(detalleLogro);
                    resultadoRegitroLogro = contexto.SaveChanges();
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoRegitroLogro = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoRegitroLogro = Constantes.ValorError;
            }
            return resultadoRegitroLogro;
        }

        public int VerificarRegistroLogroPorIdJugador(int idJugador, int idLogro) 
        {
            int verificacionLogro = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    bool logroExistente = contexto.DetalleLogro
                    .Any(detalleLogro => detalleLogro.FKIdJugador == idJugador && detalleLogro.FKIdLogro == idLogro);                    
                    if (logroExistente)
                    {
                        verificacionLogro = Constantes.ValorExitoso;
                    }
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                verificacionLogro = Constantes.ValorError;
            }
            return verificacionLogro;
        }

        public List<int> ObtenerLogrosPorIdJugador(int idJugador) 
        {
            List<int> logros = new List<int>();
            try
            {
                using (var contexto = new PasswordEntidades())
                {                    
                    logros = contexto.DetalleLogro
                        .Where(detalleLogro => detalleLogro.FKIdJugador == idJugador)
                        .Select(detalleLogro => detalleLogro.FKIdLogro)
                        .ToList();
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                logros.Insert(0, Constantes.ValorError);
            }
            return logros;
        }

        public int VerificarCatalogoLogros()
        {
            int resultadoVerificacion = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {                    
                    int totalLogros = contexto.Logro.Count();
                    if (totalLogros >= Constantes.NumeroLogros)
                    {
                        resultadoVerificacion = Constantes.ValorExitoso;
                    }                    
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoVerificacion = Constantes.ValorError; 
            }
            return resultadoVerificacion;
        }

        public int VerificarCumplimientoPrimerLogroPorIdEstadistica(int idEstadistica) 
        {
            int resultadoVerificacion = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var estadistica = contexto.Estadistica.FirstOrDefault(entidad => entidad.idEstadistica == idEstadistica);                    
                    if (estadistica != null && estadistica.partidasGanadas > Constantes.ValorNeutro)
                    {
                        resultadoVerificacion = Constantes.ValorExitoso;
                    }
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoVerificacion = Constantes.ValorError;
            }
            return resultadoVerificacion;
        }

        public int VerificarCumplimientoSegundoLogroPorIdEstadistica(int idEstadistica)
        {
            int resultadoVerificacion = Constantes.ValorNeutro;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var estadistica = contexto.Estadistica.FirstOrDefault(entidad => entidad.idEstadistica == idEstadistica);
                    if (estadistica != null && estadistica.partidasGanadas >= Constantes.NumeroPartidasGanadas)
                    {
                        resultadoVerificacion = Constantes.ValorExitoso;
                    }
                }
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoVerificacion = Constantes.ValorError;
            }
            return resultadoVerificacion;
        }       
    }
}
