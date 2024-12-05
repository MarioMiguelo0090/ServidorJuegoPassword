using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionLogros
    {
        [TestMethod]
        public void PruebaObtenerLogrosPorIdJugadorExitosa() 
        {            
            int idJugador = 11;
            List<int> resultadoEsperado= new List<int>();
            resultadoEsperado.Add(1);
            resultadoEsperado.Add(3);
            List<int> resultadoObtenido=GestionLogros.ObtenerLogrosPorIdJugador(idJugador);
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
