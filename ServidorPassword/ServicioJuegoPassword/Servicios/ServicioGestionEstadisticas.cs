using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioGestionEstadisticas
    {        

        public int AumentarPartidasGanadasPorIdEstadistica(int idEstadistica)
        {
            return GestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
        }

        public int AumentarPartidasPerdidasPorIdEstadistica(int idEstadistica)
        {
            return GestionEstadisticas.AgregarPartidaPerdidaPorIdEstadistica(idEstadistica);
        }

        public EstadisticaContrato ObtenerEstadisticaPorIdEstadistica(int idEstadistica)
        {
            var datosEstadistica = GestionEstadisticas.ObtenerEstadisticaPorIdEstadistica(idEstadistica);
            return EstadisticaContrato.ConvertirDeAccesoADatos(datosEstadistica);
        }

        public int SumarPuntajePorIdEstadistica(int idEstadistica, int puntaje)
        {
            return GestionEstadisticas.AgregarPuntajePorIdEstadistica(idEstadistica, puntaje);
        }
    }
}