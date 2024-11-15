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
        public void PruebaRegistrarNuevaSolicitudAmistadFallida() 
        {
            Amistad amistad = new Amistad();         
            int resultadoEsperado = -1;
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
        public void PruebaConfirmarSolicitudAmistadPorIdAmistadFallida() 
        {
            Amistad amistad = new Amistad
            {
                idAmistad = 0,
                respuesta = true,
                fechaRespuesta = DateTime.Today,
            };
            int resultadoEsperado = 0;
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoObtenido = gestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarSolicitudesAmistadPorIdJugadorExitosa() 
        {            
            int idJugador = 3;
            int resultadoEsperado = 2;
            GestionAmistad gestionAmistad = new GestionAmistad();            
            List<int> solicitudesAmistadObtenidas=gestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);            
            int resultadoObtenido=solicitudesAmistadObtenidas.Count;
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);            
        }

        [TestMethod]
        public void PruebaRecuperarSolicitudesAmistadPorIdJugadorFallida() 
        {
            int idJugador = 4;
            int resultadoEsperado = 0;
            GestionAmistad gestionAmistad = new GestionAmistad();
            List<int> solicitudesAmistadObtenidas = gestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);
            int resultadoObtenido = solicitudesAmistadObtenidas.Count;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarAmigosPorIdJugadorExitosa() 
        {
            int idJugador = 1;
            GestionAmistad gestionAmistad=new GestionAmistad();
            int idAmistadEsperada = 1;
            List<int> amistadesObtenidas=gestionAmistad.RecuperarIdAmigosPorIdJugador(idJugador);
            int idAmistadObtenida=amistadesObtenidas.First();
            Assert.AreEqual(idAmistadEsperada, idAmistadObtenida);
        }

        [TestMethod]
        public void PruebaRecuperarAmigosPorIdJugadorFallida() 
        {
            int idJugador = 3;
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoEsperado = 0;
            List<int> amistadesObtenidas = gestionAmistad.RecuperarIdAmigosPorIdJugador(idJugador);
            int resultadoObtenido = amistadesObtenidas.Count();
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdJugadorPorCorreoExitosa() 
        {
            string correo = "mariolimon13c@gmail.com";
            GestionAmistad gestionAmistad= new GestionAmistad();
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionAmistad.ObtenerIdJugadorPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdJugadorPorCorreoFallida() 
        {
            string correo = "ejemplo@gmail.com";
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionAmistad.ObtenerIdJugadorPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarExistenciaAmistadPorIdJugadoresExitosa() 
        {
            int idJugadorRemitente = 1;
            int idJugadorDestinatario = 3;
            GestionAmistad gestionAmistad=new GestionAmistad();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorRemitente, idJugadorDestinatario);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarExistenciaAmistadPorIdJugadoresFallida() 
        {
            int idJugadorRemitente = 1;
            int idJugadorDestinatario = 4;
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorRemitente, idJugadorDestinatario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarNombresDeUsuarioPorIdJugadorExitosa() 
        {
            List<int> idJugadores = new List<int>();
            idJugadores.Add(1);
            GestionAmistad gestionAmistad= new GestionAmistad();
            List<string> nombresUsuario=gestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
            string resultadoEsperado = "MarioMiguelLimon";
            string resultadoObtenido = nombresUsuario.First();
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarNombresDeUsuarioPorIdJugadorFallida() 
        {
            List<int> idJugadores = new List<int>();
            idJugadores.Add(8);
            GestionAmistad gestionAmistad = new GestionAmistad();
            List<string> resultadoObtenido = gestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
            List<string> resultadoEsperado = new List<string>();            
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdAmistadPorIdJugadoresExitosa() 
        {
            int idJugadorUno = 1;
            int idJugadorDos = 2;
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno, idJugadorDos);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdAmistadPorIdJugadoresFallida() 
        {
            int idJugadorUno = 0;
            int idJugadorDos = 0;
            GestionAmistad gestionAmistad=new GestionAmistad();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno, idJugadorDos);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }
    }
}
