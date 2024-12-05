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
            int resultadoObtenido = GestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
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
            int resultadoObtenido = GestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarSolicitudesAmistadPorIdJugadorExitosa() 
        {            
            int idJugador = 3;
            int resultadoEsperado = 2;            
            List<int> solicitudesAmistadObtenidas= GestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);            
            int resultadoObtenido=solicitudesAmistadObtenidas.Count;
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);            
        }

        [TestMethod]
        public void PruebaRecuperarSolicitudesAmistadPorIdJugadorFallida() 
        {
            int idJugador = 4;
            int resultadoEsperado = 0;            
            List<int> solicitudesAmistadObtenidas = GestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);
            int resultadoObtenido = solicitudesAmistadObtenidas.Count;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarAmigosPorIdJugadorExitosa() 
        {
            int idJugador = 1;                        
            List<Jugador> amistadesObtenidas= GestionAmistad.RecuperarAmigosPorIdJugador(idJugador);            
            Assert.IsTrue(amistadesObtenidas.Count() == 2);
        }

        [TestMethod]
        public void PruebaRecuperarAmigosPorIdJugadorFallida() 
        {
            int idJugador = 3;            
            int resultadoEsperado = 0;
            //List<int> amistadesObtenidas = GestionAmistad.RecuperarIdAmigosPorIdJugador(idJugador);
            //int resultadoObtenido = amistadesObtenidas.Count();
            //Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdJugadorPorCorreoExitosa() 
        {
            string correo = "mariolimon13c@gmail.com";            
            int resultadoEsperado = 1;
            int resultadoObtenido= GestionAmistad.ObtenerIdJugadorPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdJugadorPorCorreoFallida() 
        {
            string correo = "ejemplo@gmail.com";            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionAmistad.ObtenerIdJugadorPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarExistenciaAmistadPorIdJugadoresExitosa() 
        {
            int idJugadorRemitente = 1;
            int idJugadorDestinatario = 3;            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorRemitente, idJugadorDestinatario);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarExistenciaAmistadPorIdJugadoresFallida() 
        {
            int idJugadorRemitente = 1;
            int idJugadorDestinatario = 4;            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorRemitente, idJugadorDestinatario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarNombresDeUsuarioPorIdJugadorExitosa() 
        {
            List<int> idJugadores = new List<int>();
            idJugadores.Add(1);            
            List<string> nombresUsuario=GestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
            string resultadoEsperado = "MarioMiguelLimon";
            string resultadoObtenido = nombresUsuario.First();
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarNombresDeUsuarioPorIdJugadorFallida() 
        {
            List<int> idJugadores = new List<int>();
            idJugadores.Add(8);           
            List<string> resultadoObtenido = GestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
            List<string> resultadoEsperado = new List<string>();            
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdAmistadPorIdJugadoresExitosa() 
        {
            int idJugadorUno = 1;
            int idJugadorDos = 2;            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno, idJugadorDos);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdAmistadPorIdJugadoresFallida() 
        {
            int idJugadorUno = 0;
            int idJugadorDos = 0;            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno, idJugadorDos);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }
    }
}
