using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioJuegoPassword.Servicios;
using System;

namespace PruebaServicioJuegoPassword
{
    [TestClass]
    public class PruebaServicioGestionAcceso
    {
        [TestMethod]
        public void PruebaEncriptarContraseniaExitoso()
        {
            ServicioPassword servicioGestionAcceso=new ServicioPassword();
            string contrasenia = "Qwerty1234$";
            string contraseniaEncriptada=servicioGestionAcceso.EncriptarContrasenia(contrasenia);            
            Assert.IsNotNull(contraseniaEncriptada);
        }            
        
        [TestMethod]
        public void PruebaValidarInicioDeSesionExitosa() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso = new Acceso();
            acceso.correo = "mariolimon@gmail.com";
            acceso.contrasenia = "Qwerty1234$";            
            int resultadoEsperado = 1;            
            int resultadoObtenido=servicioGestionAcceso.ValidarInicioDeSesion(acceso);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarNombreUsuarioExitoso() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            string nombreUsuario = "MarioLimon";
            Assert.IsFalse(servicioGestionAcceso.ValidarNombreUsuario(nombreUsuario));
        }

        [TestMethod]
        public void PruebaValidarNombreUsuarioFallido() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            string nombreUsuario = "nadie";            
            Assert.IsTrue(servicioGestionAcceso.ValidarNombreUsuario(nombreUsuario));
        }


        [TestMethod]
        public void PruebaValidarNuevoRegistroExitoso() 
        {
            Acceso acceso = new Acceso();
            acceso.contrasenia = "Banco1234$";
            acceso.correo = "mariolimon@gmail.com";
            Jugador jugador = new Jugador();
            jugador.nombre = "Mario";
            jugador.apellidos = "Limon Cabrera";
            Perfil perfil = new Perfil();
            perfil.nombreUsuario = "MarioLimon";
            perfil.descripcion = "Nuevo jugador en password";
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Assert.IsTrue(servicioGestionAcceso.ValidarNuevoRegistro(acceso,perfil,jugador));
        }


        [TestMethod]
        public void PruebaValidarNuevoRegistroFallido() 
        {
            Acceso acceso = new Acceso();
            Jugador jugador = new Jugador();
            Perfil perfil = new Perfil();
            ServicioPassword servicioGestionAcceso = new ServicioPassword();            
            Assert.IsFalse(servicioGestionAcceso.ValidarNuevoRegistro(acceso, perfil, jugador));
        }

        [TestMethod]
        public void PruebaRegistrarNuevoJugadorExitosa() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso=new Acceso();
            acceso.contrasenia = "Oscar1234$";
            acceso.correo = "oscar@gmail.com";
            Perfil perfil = new Perfil();
            perfil.nombreUsuario = "OscarApodaca";
            perfil.descripcion = "";
            perfil.rutaImagen = "";
            Jugador jugador=new Jugador();
            jugador.nombre = "Oscar";
            jugador.apellidos = "Apodaca Garcia";
            jugador.estadoJugador = true;
            servicioGestionAcceso.RegistrarNuevoJugador(acceso,perfil,jugador);
        }


    }
}
