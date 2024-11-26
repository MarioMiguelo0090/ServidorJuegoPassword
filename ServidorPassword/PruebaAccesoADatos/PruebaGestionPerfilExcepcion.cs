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
    public class PruebaGestionPerfilExcepcion
    {
        [TestMethod]
        public void PruebaValidarPresenciaDeNombreUsuarioExcepcion() 
        {
            GestionPerfil gestionPerfil = new GestionPerfil();
            string nombreUsuario = "MarioLimon";
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarRutaImagenPorIdJugadorExcepcion() 
        {
            int idJugador = 1;
            string rutaImagen = "ImagenEjemplo.jpg";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPerfil.GuadarRutaImagenPorIdJugador(idJugador, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarDescripcionPorIdJugadorExcepcion() 
        {
            int idJugador = 1;
            string descripcion = "Soy un nuevo jugador en password";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPerfil.GuadarDescripcionPorIdJugador(idJugador, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarNombreUsuarioPorIdJugadorExcepcion() 
        {
            int idJugador = 1;
            string nombreUsuario = "MarioMiguelLimon";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPerfil.GuardarNombreUsuarioPorIdJugador(idJugador, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarCorreoPorIdAccesoExcepcion() 
        {
            int idAcceso = 2;
            string correo = "oscarapodaca@gmail.com";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarContraseniaPorIdAccesoExcepcion() 
        {
            int idAcceso = 2;
            string contrasenia = "a095f496d56094b03ba1746842f74e3fb295c7c7dbb516eefe11dfe53fd1e6a0";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso, contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
