using AccesoADatos;
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
    public class PruebaServicioGestionAccesoExcepcion
    {
        [TestMethod]
        public void PruebaRegistrarNuevoJugadorExcepcion() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso = new Acceso();
            acceso.contrasenia = "Ivan1234$";
            acceso.correo = "ivanfranco@gmail.com";
            Perfil perfil = new Perfil();
            perfil.nombreUsuario = "FrancoIvanFranco";
            perfil.descripcion = "";
            perfil.rutaImagen = "";
            Jugador jugador = new Jugador();
            jugador.nombre = "Ivan";
            jugador.apellidos = "Franco";
            jugador.estadoJugador = true;
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioGestionAcceso.RegistrarNuevoJugador(acceso, perfil, jugador);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarNombreUsuarioExcepcion() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            string nombreUsuario = "MarioLimon";
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioGestionAcceso.ValidarNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaDeCorreoExcepcion() 
        {
            string correo = "mariolimon@gmail.com";
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            int resultadoEsperado = -1;
            int resultadoObtenido = servicioGestionAcceso.ValidarPresenciaDeCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

    }
}
