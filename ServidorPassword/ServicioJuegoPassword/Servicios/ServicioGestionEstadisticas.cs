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
        private GestionEstadisticas _gestionEstadisticas = new GestionEstadisticas();

        public int AumentarPartidasGanadasPorIdEstadistica(int idEstadistica)
        {
            return _gestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
        }

        public int AumentarPartidasPerdidasPorIdEstadistica(int idEstadistica)
        {
            return _gestionEstadisticas.AgregarPartidaPerdidaPorIdEstadistica(idEstadistica);
        }

        public EstadisticaContrato ObtenerEstadisticaPorIdEstadistica(int idEstadistica)
        {
            var datosEstadistica = _gestionEstadisticas.ObtenerEstadisticaPorIdEstadistica(idEstadistica);
            return EstadisticaContrato.ConvertirDeAccesoADatos(datosEstadistica);
        }

        public int SumarPuntajePorIdEstadistica(int idEstadistica, int puntaje)
        {
            return _gestionEstadisticas.AgregarPuntajePorIdEstadistica(idEstadistica, puntaje);
        }
    }
}