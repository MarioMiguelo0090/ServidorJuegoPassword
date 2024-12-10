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
    public class GestionEstadisticas
    {
        private static readonly ILog _bitacora = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int AgregarPuntajePorIdEstadistica(int idEstadistica, int puntajeAAgregar)
        {
            int resultadoAgregacionPuntaje = Constantes.ValorNeutro;
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
                resultadoAgregacionPuntaje = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoAgregacionPuntaje = Constantes.ValorError;
            }
            return resultadoAgregacionPuntaje;
        }

        public int AgregarPartidaGanadaPorIdEstadistica(int idEstadistica)
        {
            int resultadoAgregacionPuntaje = Constantes.ValorNeutro;
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
                resultadoAgregacionPuntaje = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoAgregacionPuntaje = Constantes.ValorError;
            }
            return resultadoAgregacionPuntaje;
        }

        public int AgregarPartidaPerdidaPorIdEstadistica(int idEstadistica)
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
                resultadoAgregacionPuntaje = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoAgregacionPuntaje = Constantes.ValorError;
            }
            return resultadoAgregacionPuntaje;
        }

        public Estadistica ObtenerEstadisticaPorIdEstadistica(int idEstadistica)
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
                        resultadoEstadistica.idEstadistica = Constantes.ValorNeutro;
                    }
                }
            }
            catch (DbUpdateException excepcionActualizacion)
            {
                _bitacora.Warn(excepcionActualizacion);
                resultadoEstadistica.idEstadistica = Constantes.ValorError;
            }
            catch (EntityException excepcionEntidad)
            {
                _bitacora.Error(excepcionEntidad);
                resultadoEstadistica.idEstadistica = Constantes.ValorError;
            }
            return resultadoEstadistica;
        }
    }
}