using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioGestionAmistad
    {
        private GestionAmistad _gestionAmistad = new GestionAmistad();
        public int RegistrarAmistad(Amistad amistad)
        {
            return _gestionAmistad.RegistrarNuevaSolicitudAmistad(amistad);            
        }

        public int ResponderSolicitudAmistad(Amistad amistad)
        {
            return GestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
        }

        public List<JugadorContrato> ConsultarAmistadesPorIdJugador(int idJugador)
        {
            var amigosObtenidos = GestionAmistad.RecuperarAmigosPorIdJugador(idJugador);
            List<JugadorContrato> amigosFinales = new List<JugadorContrato>();
            foreach (var amigoObtenido in amigosObtenidos) 
            {
                JugadorContrato jugador=JugadorContrato.ConvertirDeAccesoADatos(amigoObtenido);
                amigosFinales.Add(jugador);
            }
            return amigosFinales;
        }

        public List<int> ConsultarSolicitudesAmistadPorIdJugador(int idJugador)
        {
            return GestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);
        }

        public int ConsultarIdJugadorPorCorreo(string correo)
        {
            return GestionAmistad.ObtenerIdJugadorPorCorreo(correo);
        }

        public List<string> ObtenerNombresDeUsuarioPorIdJugadores(List<int> idJugadores)
        {
            return GestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
        }

        public int ValidarExistenciaAmistadPorIdJugadores(int idJugadorUno, int idJugadorDos)
        {
            return GestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorUno,idJugadorDos);
        }

        public int RecuperarIdAmistadPorIdJugadores(int idJugadorUno, int idJugadorDos)
        {
            return GestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno,idJugadorDos);
        }
    }
}
