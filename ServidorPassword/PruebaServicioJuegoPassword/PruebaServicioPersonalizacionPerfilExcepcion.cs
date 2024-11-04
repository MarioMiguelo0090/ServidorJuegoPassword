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
    public class PruebaServicioPersonalizacionPerfilExcepcion
    {
        [TestMethod]
        public void PruebaEditarCorreoPorIdAccesoExcepcion() 
        {
            int idAcceso = 2;
            string correo = "oscar@gmail.com";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarCorreoPorIdAcceso(idAcceso, correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarDescripcionPorIdPerfilExcepcion() 
        {
            int idPerfil = 2;
            string descripcion = "Nueva descripcion";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarDescripcionPorIdPerfil(idPerfil, descripcion);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarNombreUsuarioPorIdPerfilExcepcion() 
        {
            int idPerfil = 2;
            string nombreUsuario = "OscarApodacaGarcia";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarNombreUsuarioPorIdPerfil(idPerfil, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarRutaImagenPorIdPerfilExcepcion() 
        {
            int idPerfil = 2;
            string rutaImagen = "Imagen2.jpg";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarRutaImagenPorIdPerfil(idPerfil, rutaImagen);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEditarContraseniaPorIdAccesoExcepcion()
        {
            int idAcceso = 2;
            string contrasenia = "Oscar1234$";
            ServicioPassword servicioPersonalizacionPerfil = new ServicioPassword();
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioPersonalizacionPerfil.EditarContraseniaPorIdAcceso(idAcceso, contrasenia);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
