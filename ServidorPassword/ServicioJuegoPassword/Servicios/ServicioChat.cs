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
    public class ServicioChat : IServicioChat
    {
        private static List<IServicioChatCallback> clientes = new List<IServicioChatCallback>();
        public void Chatear(string chat)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioChatCallback>();
            if (!clientes.Contains(cliente))
            {
                clientes.Add(cliente);
            }            
            string mensaje = chat + Environment.NewLine;            
            foreach (var callback in clientes)
            {
                if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                {
                    callback.Responder(mensaje);
                }
            }
        }
    }
}
