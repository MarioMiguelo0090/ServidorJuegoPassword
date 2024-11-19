using AccesoADatos;
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
        private static List<JugadorContrato> _jugadoresConectados = new List<JugadorContrato>();
        private static List<IServicioSalaDeEsperaCallback> _callbacks = new List<IServicioSalaDeEsperaCallback>();

        public void ConectarJugador(string nombreUsuario, string rutaImagen)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();

            if (!_callbacks.Contains(cliente))
            {
                _callbacks.Add(cliente);
            }

            if (!_jugadoresConectados.Any(j => j.NombreUsuario == nombreUsuario))
            {
                _jugadoresConectados.Add(new JugadorContrato
                {
                    NombreUsuario = nombreUsuario,
                    RutaImagen = rutaImagen
                });
                NotificarJugadoresActualizados();
            }
        }

        public void DesconectarJugador(string nombreUsuario)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();

            _jugadoresConectados.RemoveAll(j => j.NombreUsuario == nombreUsuario);
            _callbacks.Remove(cliente);
            NotificarJugadoresActualizados();
        }

        public List<JugadorContrato> ObtenerJugadoresConectados()
        {
            return _jugadoresConectados;
        }

        private void NotificarJugadoresActualizados()
        {
            foreach (var callback in _callbacks)
            {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                {
                    callback.ActualizarListaJugadores(_jugadoresConectados);
                }
            }
        }
    }
}
