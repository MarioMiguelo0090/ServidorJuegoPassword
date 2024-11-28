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
    [ServiceContract]
    public interface IServicioGestionEstadisticas
    {
        [OperationContract]
        int SumarPuntajePorIdEstadistica(int idEstadistica, int puntaje);

        [OperationContract]
        int AumentarPartidasGanadasPorIdEstadistica(int idEstadistica);

        [OperationContract]
        int AumentarPartidasPerdidasPorIdEstadistica(int idEstadistica);

        [OperationContract]
        EstadisticaContrato ObtenerEstadisticaPorIdEstadistica(int idEstadistica);
    }

    [DataContract]
    public class EstadisticaContrato
    {
        [DataMember]
        public int IdEstadistica { set; get; }

        [DataMember]
        public int Puntaje { set; get; }

        [DataMember]
        public int PartidasGanadas { set; get; }

        [DataMember]
        public int PartidasPerdidas { set; get; }

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