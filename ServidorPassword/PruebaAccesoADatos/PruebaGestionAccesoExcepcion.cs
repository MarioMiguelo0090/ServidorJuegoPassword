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
            jugador.nombre = "Mario Miguel";
            jugador.apellidos = "Limon Cabrera";
            jugador.estadoJugador = true;
            Perfil perfil = new Perfil();
            perfil.nombreUsuario = "MarioLimon";
            perfil.rutaImagen = "";
            perfil.descripcion = "";
            int resultadoObtenido = gestionAcceso.RegistrarAcceso(acceso, jugador, perfil);
            int resultadoEsperado = -1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetonarIdAccesoPorCorreoExcepcion() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "mariolimon@gmail.com";
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionAcceso.RetonarIdAccesoPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetornarContraseniaPorCorreoExcepcion()
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "mariolimon@gmail.com";
            string resultadoEsperado = "excepcion";
            string resultadoObtenido = gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoExcepcion() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "mariolimon@gmail.com";
            int resultadoEsperado = -1;
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
