using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionAmistad
    {
        [TestMethod]
        public void PruebaRegistrarNuevaSolicitudAmistadExitosa() 
        {
            Amistad amistad = new Amistad
            {
                idJugadorAmigo = 2,
                fechaSolicitud = DateTime.Today,
                FKidJugador= 1,
            };
            int resultadoEsperado = 1;
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoObtenido = gestionAmistad.RegistrarNuevaSolicitudAmistad(amistad);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaConfirmarSolicitudAmistadPorIdAmistadExitosa() 
        {
            Amistad amistad = new Amistad
            {
                idAmistad = 1,
                respuesta=true,
                fechaRespuesta=DateTime.Today,
            };
            int resultadoEsperado = 1;  
            GestionAmistad gestionAmistad=new GestionAmistad();
            int resultadoObtenido = gestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarSolicitudesAmistadPorIdJugadorExitosa() 
        {
            int idJugador = 2;
            int idAmistadEsperado = 2;
            GestionAmistad gestionAmistad = new GestionAmistad();            
            List<Amistad> resultadoObtenido=gestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);
            Amistad amistadObtenida=resultadoObtenido.First();
            Assert.AreEqual(idAmistadEsperado, amistadObtenida.idAmistad);
        }

        [TestMethod]
        public void PruebaRecuperarAmigosPorIdJugadorExitosa() 
        {
            int idJugador = 1;
            GestionAmistad gestionAmistad=new GestionAmistad();
            int idAmistadEsperada = 1;
            List<Amistad> amistadesObtenidas=gestionAmistad.RecuperarAmigosPorIdJugador(idJugador);
            Amistad amistadObtenida=amistadesObtenidas.First();
            Assert.AreEqual(idAmistadEsperada,amistadObtenida.idAmistad);
        }

        [TestMethod]
        public void PruebaObtenerIdJugadorPorCorreoExitosa() 
        {
            string correo = "mariolimon@gmail.com";
            GestionAmistad gestionAmistad= new GestionAmistad();
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionAmistad.ObtenerIdJugadorPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
