using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionPerfil
    {
        [TestMethod]
        public void PruebaValidarPresenciaDeNombreUsuarioExitoso()
        {            
            string nombreUsuario = "MarioLimon";
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaDeNombreUsuarioFallida()
        {            
            string nombreUsuario = "nadie";
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarRutaImagenPorIdJugadorExitosa()
        {
            int idJugador = 1;
            string rutaImagen = "pack://application:,,,/Imagenes/Fondos/perfil1.png";            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionPerfil.GuadarRutaImagenPorIdJugador(idJugador, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarRutaImagenPorIdJugadorFallida()
        {            
            int idJugador = 0;
            string rutaImagen = "ImagenEjemplo.jpg";
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPerfil.GuadarRutaImagenPorIdJugador(idJugador, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarDescripcionPorIdJugadorExitosa()
        {
            int idJugador = 1;
            string descripcion = "Soy un nuevo jugador en password";            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionPerfil.GuadarDescripcionPorIdJugador(idJugador, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarDescripcionPorIdJugadorFallida()
        {
            int idJugador = 0;
            string descripcion = "Nada";            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPerfil.GuadarDescripcionPorIdJugador(idJugador, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarNombreUsuarioPorIdJugadorExitosa()
        {
            int idJugador = 1;
            string nombreUsuario = "MarioMiguelLimon";            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionPerfil.GuardarNombreUsuarioPorIdJugador(idJugador, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarNombreUsuarioPorIdJugadorFallida()
        {
            int idJugador = 0;
            string nombreUsuario = "nadie";            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPerfil.GuardarNombreUsuarioPorIdJugador(idJugador, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarCorreoPorIdAccesoExitosa() 
        {
            int idAcceso = 2;
            string correo = "oscarapodaca@gmail.com";            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarCorreoPorIdAccesoFallida() 
        {
            int idAcceso = 0;
            string correo = "ejemplo@gmail.com";            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarContraseniaPorIdAccesoExitosa() 
        {
            int idAcceso = 2;
            string contrasenia = "a095f496d56094b03ba1746842f74e3fb295c7c7dbb516eefe11dfe53fd1e6a0";            
            int resultadoEsperado = 1;
            int resultadoObtenido = GestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso,contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarContraseniaPorIdAccesoFallida() 
        {
            int idAcceso = 0;
            string contrasenia = "Contrasenia123$";            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso,contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
