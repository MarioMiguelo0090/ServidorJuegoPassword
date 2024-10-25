using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioJuegoPassword.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaServicioJuegoPassword
{
    [TestClass]
    public class PruebaServicioPersonalizacionPerfil
    {
        [TestMethod]
        public void PruebaEditarCorreoPorIdAccesoExitosa() 
        {
            int idAcceso = 2;
            string correo = "oscar@gmail.com";
            ServicioPassword servicioPersonalizacionPerfil= new ServicioPassword();
            int resultadoEsperado = 1;
            int resultadoObtenido=servicioPersonalizacionPerfil.EditarCorreoPorIdAcceso(idAcceso,correo);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarCorreoPorIdAccesoFallida() 
        {
            int idAcceso = 0;
            string correo = "ejemplo@gmail.com";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarDescripcionPorIdPerfilExitosa() 
        {
            int idPerfil = 2;
            string descripcion = "Nueva descripcion";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarDescripcionPorIdPerfil(idPerfil,descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarDescripcionPorIdPerfilFallida() 
        {
            int idPerfil = 0;
            string descripcion = "Nueva descripcion";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarDescripcionPorIdPerfil(idPerfil, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarNombreUsuarioPorIdPerfilExitosa() 
        {
            int idPerfil = 2;
            string nombreUsuario = "OscarApodacaGarcia";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarNombreUsuarioPorIdPerfil(idPerfil, nombreUsuario);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarNombreUsuarioPorIdPerfilFallida() 
        {
            int idPerfil = 0;
            string nombreUsuario = "OscarApodacaGarcia";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarNombreUsuarioPorIdPerfil(idPerfil, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarRutaImagenPorIdPerfilExitosa() 
        {
            int idPerfil = 2;
            string rutaImagen = "Imagen2.jpg";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarRutaImagenPorIdPerfil(idPerfil, rutaImagen);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarRutaImagenPorIdPerfilFallida() 
        {
            int idPerfil = 0;
            string rutaImagen = "Imagen2.jpg";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarRutaImagenPorIdPerfil(idPerfil, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarContraseniaPorIdAccesoExitosa() 
        {
            int idAcceso = 2;
            string contrasenia = "Oscar1234$";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarContraseniaPorIdAcceso(idAcceso,contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarContraseniaPorIdAccesoFallida() 
        {
            int idAcceso = 0;
            string contrasenia = "Oscar1234$";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarContraseniaPorIdAcceso(idAcceso, contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
