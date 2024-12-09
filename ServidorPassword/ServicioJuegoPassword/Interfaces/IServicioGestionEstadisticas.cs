using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para gestionar las estadísticas de los jugadores en el sistema.
    /// </summary>
    [ServiceContract]
    public interface IServicioGestionEstadisticas
    {
        /// <summary>
        /// Suma un puntaje a las estadisticas de un jugador.
        /// </summary>
        /// <param name="idEstadistica">Identificador de la estadistica del jugador</param>
        /// <param name="puntaje">Puntaje a sumar.</param>
        /// <returns>Retorna 1 si el puntaje es registrado.</returns>
        [OperationContract]
        int SumarPuntajePorIdEstadistica(int idEstadistica, int puntaje);

        /// <summary>
        /// Aumenta en 1 las partidas ganadas de un jugador.
        /// </summary>
        /// <param name="idEstadistica">Identificador de la estadistica del jugador</param>
        /// <returns>Retorna 1 si aumentan las partidas ganadas.</returns>
        [OperationContract]
        int AumentarPartidasGanadasPorIdEstadistica(int idEstadistica);

        /// <summary>
        /// Aumenta en 1 las partidas pérdidas de un jugador.
        /// </summary>
        /// <param name="idEstadistica">Identificador de la estadistica del jugador</param>
        /// <returns>Retorna 1 si aumentan las partidas ganadas.</returns>
        [OperationContract]
        int AumentarPartidasPerdidasPorIdEstadistica(int idEstadistica);

        /// <summary>
        /// Recupera las estadísticas del jugador.
        /// </summary>
        /// <param name="idEstadistica">Identificador de la estadistica del jugador</param>
        /// <returns>Estadísticas del jugador.</returns>
        [OperationContract]
        EstadisticaContrato ObtenerEstadisticaPorIdEstadistica(int idEstadistica);
    }


    /// <summary>
    /// Representa las estadísticas de un jugador.
    /// </summary>
    [DataContract]
    public class EstadisticaContrato
    {
        /// <summary>
        /// Identificador único de las estadísticas.
        /// </summary>
        [DataMember]
        public int IdEstadistica { set; get; }

        /// <summary>
        /// Puntaje total del jugador.
        /// </summary>
        [DataMember]
        public int Puntaje { set; get; }

        /// <summary>
        /// Partidas ganadas del jugador.
        /// </summary>
        [DataMember]
        public int PartidasGanadas { set; get; }

        /// <summary>
        /// Partidas pérdidas del jugador.
        /// </summary>
        [DataMember]
        public int PartidasPerdidas { set; get; }

        /// <summary>
        /// Convierte un objeto Estadistica del modelo de datos a EstadisticaContrato.
        /// </summary>
        /// <param name="estadistica">Instancia del modelo de datos.</param>
        /// <returns>Estadistica convertida.</returns>
        public static EstadisticaContrato ConvertirDeAccesoADatos(Estadistica estadistica)
        {
            return new EstadisticaContrato
            {
                IdEstadistica = estadistica.idEstadistica,
                Puntaje = estadistica.puntaje,
                PartidasGanadas = estadistica.partidasGanadas,
                PartidasPerdidas = estadistica.partidasPerdidas,
            };
        }
    }
}