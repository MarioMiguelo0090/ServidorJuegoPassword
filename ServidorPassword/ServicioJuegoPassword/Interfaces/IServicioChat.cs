using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato del servicio de chat.
    /// </summary>
    [ServiceContract(CallbackContract=typeof(IServicioChatCallback))]
    public interface IServicioChat
    {
        /// <summary>
        /// Método para enviar un mensaje de chat.
        /// </summary>
        /// <param name="chat">El mensaje a enviar.</param>
        [OperationContract(IsOneWay = true)]
        void Chatear(string chat);
    }

    /// <summary>
    /// Interfaz de devolución de llamadas que recibe los mensajes del chat.
    /// </summary>
    [ServiceContract]
    public interface IServicioChatCallback 
    {
        /// <summary>
        /// Método para recibir el mensaje del servicio del chat.
        /// </summary>
        /// <param name="respuesta">La respuesta del chat recibida</param>
        [OperationContract]
        void Responder(string respuesta);
    }
}
