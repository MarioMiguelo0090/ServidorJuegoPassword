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
    public class PruebaGestionAmistadExcepcion
    {
        [TestMethod]
        public void PruebaRegistrarNuevaSolicitudAmistadExcepcion()
        {
            Amistad amistad = new Amistad
            {
                idJugadorAmigo = 2,
                fechaSolicitud = DateTime.Today,
                FKidJugador = 1,
            };
            int resultadoEsperado = -1;
            GestionAmistad gestionAmistad = new GestionAmistad();
            int resultadoObtenido = gestionAmistad.RegistrarNuevaSolicitudAmistad(amistad);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaConfirmarSolicitudAmistadPorIdAmistadExcepcion() 
        {
            Amistad amistad = new Amistad
            {
                idAmistad = 1,
                respuesta = true,
                fechaRespuesta = DateTime.Today,
            };
            int resultadoEsperado = -1;            
            int resultadoObtenido = GestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarSolicitudesAmistadPorIdJugadorExcepcion() 
        {
            int idJugador = 3;
            int resultadoEsperado = -1;            
            List<int> solicitudesAmistadObtenidas = GestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);
            int resultadoObtenido = solicitudesAmistadObtenidas.First();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarAmigosPorIdJugadorExcepcion() 
        {
            int idJugador = 1;            
            int idAmistadEsperada = -1;
            List<Jugador> amistadesObtenidas = GestionAmistad.RecuperarAmigosPorIdJugador(idJugador);
            int idAmistadObtenida = amistadesObtenidas.First().idJugador;
            Assert.AreEqual(idAmistadEsperada, idAmistadObtenida);
        }

        [TestMethod]
        public void PruebaObtenerIdJugadorPorCorreoExcepcion() 
        {
            string correo = "mariolimon13c@gmail.com";            
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionAmistad.ObtenerIdJugadorPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarNombresDeUsuarioPorIdJugadorExcepcion() 
        {
            List<int> idJugadores = new List<int>();
            idJugadores.Add(1);            
            List<string> nombresUsuario = GestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
            string resultadoEsperado = "excepcion";
            string resultadoObtenido = nombresUsuario.First();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarExistenciaAmistadPorIdJugadoresExcepcion() 
        {
            int idJugadorRemitente = 1;
            int idJugadorDestinatario = 3;            
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorRemitente, idJugadorDestinatario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerIdAmistadPorIdJugadoresExcepcion() 
        {
            int idJugadorUno = 1;
            int idJugadorDos = 2;            
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno, idJugadorDos);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
