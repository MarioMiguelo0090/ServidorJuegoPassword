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
    public class GestionEstadisticas
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int AgregarPuntajePorIdEstadistica(int idEstadistica, int puntajeAAgregar)
        {
            int resultadoAgregacionPuntaje = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var estadistica = contexto.Estadistica.FirstOrDefault(entidad => entidad.idEstadistica == idEstadistica);

                    if (estadistica != null)
                    {
                        estadistica.puntaje += puntajeAAgregar;
                        resultadoAgregacionPuntaje = contexto.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoAgregacionPuntaje = -1;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoAgregacionPuntaje = -1;
            }

            return resultadoAgregacionPuntaje;
        }

        public static int AgregarPartidaGanadaPorIdEstadistica(int idEstadistica)
        {
            int resultadoAgregacionPuntaje = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var estadistica = contexto.Estadistica.FirstOrDefault(entidad => entidad.idEstadistica == idEstadistica);

                    if (estadistica != null)
                    {
                        estadistica.partidasGanadas += 1;
                        resultadoAgregacionPuntaje = contexto.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoAgregacionPuntaje = -1;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoAgregacionPuntaje = -1;
            }
            return resultadoAgregacionPuntaje;
        }

        public static int AgregarPartidaPerdidaPorIdEstadistica(int idEstadistica)
        {
            int resultadoAgregacionPuntaje = 0;
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var estadistica = contexto.Estadistica.FirstOrDefault(entidad => entidad.idEstadistica == idEstadistica);

                    if (estadistica != null)
                    {
                        estadistica.partidasPerdidas += 1;
                        resultadoAgregacionPuntaje = contexto.SaveChanges();
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoAgregacionPuntaje = -1;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoAgregacionPuntaje = -1;
            }
            return resultadoAgregacionPuntaje;
        }

        public static Estadistica ObtenerEstadisticaPorIdEstadistica(int idEstadistica)
        {
            Estadistica resultadoEstadistica = new Estadistica();
            try
            {
                using (var contexto = new PasswordEntidades())
                {
                    var estadistica = contexto.Estadistica.FirstOrDefault(entidad => entidad.idEstadistica == idEstadistica);
                    if (estadistica != null)
                    {
                        resultadoEstadistica = estadistica;
                    }
                    else
                    {
                        resultadoEstadistica.idEstadistica = 0;
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoEstadistica.idEstadistica = -1;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoEstadistica.idEstadistica = -1;
            }
            return resultadoEstadistica;
        }
    }
}