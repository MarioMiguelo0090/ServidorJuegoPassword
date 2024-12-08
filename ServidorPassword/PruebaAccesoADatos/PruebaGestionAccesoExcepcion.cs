using AccesoADatos;
using AccesoADatos.Auxiliares;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionAccesoExcepcion
    {
        [TestMethod]
        public void PruebaRegistrarAccesoExcepcion() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();
            acceso.correo = "mariolimon@gmail.com";
            acceso.contrasenia = "11c3c4b9db9fc12fd6f7c57a9ab81468668ff1d3bb0ed28ed507b6a5c989e2aa";
            Jugador jugador = new Jugador();            
            jugador.nombreUsuario = "MarioLimon";
            jugador.rutaImagen = "";
            jugador.descripcion = "";
            int resultadoObtenido = gestionAcceso.RegistrarAcceso(acceso, jugador);
            int resultadoEsperado = -1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetonarIdAccesoPorCorreoExcepcion() 
        {            
            string correo = "mariolimon@gmail.com";
            int resultadoEsperado = -1;
            GestionAcceso gestionAcceso = new GestionAcceso();
            int resultadoObtenido = gestionAcceso.RetonarIdAccesoPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetornarContraseniaPorCorreoExcepcion()
        {            
            string correo = "mariolimon@gmail.com";
            string resultadoEsperado = "excepcion";
            GestionAcceso gestionAcceso= new GestionAcceso();
            string resultadoObtenido = gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoExcepcion() 
        {            
            string correo = "mariolimon@gmail.com";
            int resultadoEsperado = -1;
            GestionAcceso gestionAcceso = new GestionAcceso();
            int resultadoObtenido = gestionAcceso.ValidarPresenciaCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerCuentaPorCorreoExcepcion() 
        {
            Cuenta cuentaPrueba = new Cuenta();
            cuentaPrueba.IdAcceso = -1;
            GestionAcceso gestionAcceso = new GestionAcceso();
            Cuenta cuentaObtenida = gestionAcceso.ObtenerCuentaPorCorreo(cuentaPrueba.Correo);
            Assert.AreEqual(cuentaPrueba.IdAcceso, cuentaObtenida.IdAcceso);
        }
    }
}
