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
            GestionPerfil gestionPerfil = new GestionPerfil();
            string nombreUsuario = "MarioLimon";
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaDeNombreUsuarioFallida()
        {
            GestionPerfil gestionPerfil = new GestionPerfil();
            string nombreUsuario = "nadie";
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarRutaImagenPorIdPerfilExitosa()
        {
            int idPerfil = 1;
            string rutaImagen = "ImagenEjemplo.jpg";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuadarRutaImagenPorIdPerfil(idPerfil, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarRutaImagenPorIdPerfilFallida()
        {
            GestionPerfil gestionPerfil = new GestionPerfil();
            int idPerfil = 0;
            string rutaImagen = "ImagenEjemplo.jpg";
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionPerfil.GuadarRutaImagenPorIdPerfil(idPerfil, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarDescripcionPorIdPerfilExitosa()
        {
            int idPerfil = 1;
            string descripcion = "Soy un nuevo jugador en password";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuadarDescripcionPorIdPerfil(idPerfil, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarDescripcionPorIdPerfilFallida()
        {
            int idPerfil = 0;
            string descripcion = "Nada";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionPerfil.GuadarDescripcionPorIdPerfil(idPerfil, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarNombreUsuarioPorIdPerfilExitosa()
        {
            int idPerfil = 1;
            string nombreUsuario = "MarioMiguelLimon";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuardarNombreUsuarioPorIdPerfil(idPerfil, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarNombreUsuarioPorIdPerfilFallida()
        {
            int idPerfil = 0;
            string nombreUsuario = "nadie";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionPerfil.GuardarNombreUsuarioPorIdPerfil(idPerfil, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarCorreoPorIdAccesoExitosa() 
        {
            int idAcceso = 2;
            string correo = "oscarapodaca@gmail.com";
            GestionPerfil gestionPerfil=new GestionPerfil();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarCorreoPorIdAccesoFallida() 
        {
            int idAcceso = 0;
            string correo = "ejemplo@gmail.com";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarContraseniaPorIdAccesoExitosa() 
        {
            int idAcceso = 2;
            string contrasenia = "a095f496d56094b03ba1746842f74e3fb295c7c7dbb516eefe11dfe53fd1e6a0";
            GestionPerfil gestionPerfil=new GestionPerfil();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso,contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuardarContraseniaPorIdAccesoFallida() 
        {
            int idAcceso = 0;
            string contrasenia = "Contrasenia123$";
            GestionPerfil gestionPerfil= new GestionPerfil();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso,contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
