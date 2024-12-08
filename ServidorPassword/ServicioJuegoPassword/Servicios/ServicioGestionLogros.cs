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
        private GestionLogros _gestionLogros = new GestionLogros();

        public List<int> ObtenerIdLogrosPorIdJugador(int idJugador)
        {
            return _gestionLogros.ObtenerLogrosPorIdJugador(idJugador);
        }

        public int RegistrarNuevoLogroPorIdJugador(int idJugador, int idLogro)
        {
            return _gestionLogros.RegistrarLogroPorIdJugador(idJugador, idLogro);
        }

        public int VerificarCatalogoDeLogros()
        {
            return _gestionLogros.VerificarCatalogoLogros();
        }

        public int VerificarPrimerLogroPorIdEstadistica(int idEstadistica)
        {
            return _gestionLogros.VerificarCumplimientoPrimerLogroPorIdEstadistica(idEstadistica);
        }

        public int VerificarRegistroEspecificoLogroPorIdJugador(int idJugador, int idLogro)
        {
            return _gestionLogros.VerificarRegistroLogroPorIdJugador(idJugador, idLogro);
        }

        public int VerificarSegundoLogroPorIdEstadistica(int idEstadistica)
        {
            return _gestionLogros.VerificarCumplimientoSegundoLogroPorIdEstadistica(idEstadistica);
        }
    }
}
