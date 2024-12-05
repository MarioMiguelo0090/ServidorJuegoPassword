using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioGestionLogros
    {
        private GestionLogros _gestionLogros=new GestionLogros();

        public List<int> ObtenerIdLogrosPorIdJugador(int idJugador)
        {
            return GestionLogros.ObtenerLogrosPorIdJugador(idJugador);
        }

        public int RegistrarNuevoLogroPorIdJugador(int idJugador, int idLogro)
        {
            return _gestionLogros.RegistrarLogroPorIdJugador(idJugador, idLogro);
        }

        public int VerificarCatalogoDeLogros()
        {
            return GestionLogros.VerificarCatalogoLogros();
        }

        public int VerificarPrimerLogroPorIdEstadistica(int idEstadistica)
        {
            return GestionLogros.VerificarCumplimientoPrimerLogroPorIdEstadistica(idEstadistica);
        }

        public int VerificarRegistroEspecificoLogroPorIdJugador(int idJugador, int idLogro)
        {
            return GestionLogros.VerificarRegistroLogroPorIdJugador(idJugador, idLogro);
        }

        public int VerificarSegundoLogroPorIdEstadistica(int idEstadistica)
        {
            return GestionLogros.VerificarCumplimientoSegundoLogroPorIdEstadistica(idEstadistica);
        }
    }
}
