using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioJugadores
    {
        private static List<string> _jugadoresActivos = new List<string>();


        public int ConectarJugadorJuego(string jugador)
        {
            int resultadoConexion = 0;
            if (!_jugadoresActivos.Contains(jugador))
            {
                _jugadoresActivos.Add(jugador);
                resultadoConexion = 1;
            }
            return resultadoConexion;
        }


        public void DesconectarJugadorJuego(string jugador)
        {
            if (_jugadoresActivos.Contains(jugador))
            {
                _jugadoresActivos.Remove(jugador);
            }
        }

        public List<string> ObtenerJugadores()
        {
            return _jugadoresActivos;
        }

        public bool VerificarConexionUsuario(string jugador)
        {
            bool resultadoConexion = false;
            if (_jugadoresActivos.Contains(jugador))
            {
                resultadoConexion = true;
            }
            return resultadoConexion;
        }
    }
}