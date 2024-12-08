using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class ServicioPassword : IServicioChat
    {        
        private static Dictionary<string, List<IServicioChatCallback>> _clientesPorPartida = new Dictionary<string, List<IServicioChatCallback>>();

        public void Chatear(string chat)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioChatCallback>();
            string codigoPartida = chat.Split(':')[1];            
            if (!_clientesPorPartida.ContainsKey(codigoPartida))
            {
                _clientesPorPartida[codigoPartida] = new List<IServicioChatCallback>();
            }

            if (!_clientesPorPartida[codigoPartida].Contains(cliente))
            {
                _clientesPorPartida[codigoPartida].Add(cliente);
            }         
            string mensaje=chat+Environment.NewLine;
            foreach (var callback in _clientesPorPartida[codigoPartida])
            {                                
                callback.Responder(mensaje);                
            }
        }

    }
}
