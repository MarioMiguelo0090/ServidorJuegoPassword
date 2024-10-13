using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract(CallbackContract=typeof(IServicioChatCallback))]
    public interface IServicioChat
    {
        [OperationContract(IsOneWay = true)]
        void Chatear(string chat);
    }
    [ServiceContract]
    public interface IServicioChatCallback 
    {
        [OperationContract]
        void Responder(string respuesta);
    }
}
