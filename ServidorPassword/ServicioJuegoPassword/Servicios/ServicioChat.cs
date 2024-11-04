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
        private static List<IServicioChatCallback> _clientes = new List<IServicioChatCallback>();
        public void Chatear(string chat)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioChatCallback>();
            if (!_clientes.Contains(cliente))
            {
                _clientes.Add(cliente);
            }            
            string mensaje = chat + Environment.NewLine;            
            foreach (var callback in _clientes)
            {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                {
                    callback.Responder(mensaje);
                }
            }
        }
    }
}
