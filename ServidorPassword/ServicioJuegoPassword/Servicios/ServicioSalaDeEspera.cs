using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{    
    public partial class ServicioPassword : IServicioSalaDeEspera
    {
        private readonly List<JugadorContrato> _jugadores;
        private readonly List<IServicioSalaDeEsperaCallback> _clientesSalaDeEspera;

        public List<JugadorContrato> ObtenerJugadores()
        {
            return _jugadores;
        }

        public void RegistrarJugador(JugadorContrato jugador)
        {
            _jugadores.Add(jugador);            
            foreach (var cliente in _clientesSalaDeEspera)
            {
                try
                {
                    cliente.JugadorConectado(jugador);
                }
                catch (Exception ex)
                {                    
                    Console.WriteLine($"Error al notificar cliente: {ex.Message}");
                }
            }
        }

        public void Conectar()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();
            if (!_clientesSalaDeEspera.Contains(callback))
            {
                _clientesSalaDeEspera.Add(callback);
            }
        }

        public void Desconectar()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();
            if (_clientesSalaDeEspera.Contains(callback))
            {
                _clientesSalaDeEspera.Remove(callback);
            }
        }
    }
}
