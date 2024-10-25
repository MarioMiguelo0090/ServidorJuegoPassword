using AccesoADatos;
using AccesoADatos.Auxiliares;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioJuegoPassword.Servicios;
using System;

namespace PruebaServicioJuegoPassword
{
    [TestClass]
    public class PruebaServicioGestionAcceso
    {
        [TestMethod]
        public void PruebaRegistrarNuevoJugadorExitosa()
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso = new Acceso();
            acceso.contrasenia = "Ivan1234$";
            acceso.correo = "ivan@gmail.com";
            Perfil perfil = new Perfil();
            perfil.nombreUsuario = "FrancoIvan";
            perfil.descripcion = "";
            perfil.rutaImagen = "";
            Jugador jugador = new Jugador();
            jugador.nombre = "Ivan";
            jugador.apellidos = "Franco";
            jugador.estadoJugador = true;
            int resultadoEsperado = 1;
            int resultadoObtenido = servicioGestionAcceso.RegistrarNuevoJugador(acceso, perfil, jugador);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRegistrarNuevoJugadorFallida()
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso = new Acceso();
            Perfil perfil = new Perfil();
            Jugador jugador = new Jugador();
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioGestionAcceso.RegistrarNuevoJugador(acceso, perfil, jugador);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInicioDeSesionExitosa()
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso = new Acceso();
            acceso.correo = "mariolimon@gmail.com";
            acceso.contrasenia = "Qwerty1234$";
            int resultadoEsperado = 1;
            int resultadoObtenido = servicioGestionAcceso.ValidarInicioDeSesion(acceso);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInicioDeSesionFallida() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Acceso acceso = new Acceso();
            acceso.correo = "mariolimon@gmail.com";
            acceso.contrasenia = "OtraContrasenia";
            int resultadoEsperado = 0;
            int resultadoObtenido = servicioGestionAcceso.ValidarInicioDeSesion(acceso);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaEncriptarContraseniaExitosa()
        {
            ServicioPassword servicioGestionAcceso=new ServicioPassword();
            string contrasenia = "Oscar1234$";
            string contraseniaEsperada = "a095f496d56094b03ba1746842f74e3fb295c7c7dbb516eefe11dfe53fd1e6a0";
            string contraseniaObtenida=servicioGestionAcceso.EncriptarContrasenia(contrasenia);
            Assert.AreEqual(contraseniaEsperada,contraseniaObtenida);
        }

        [TestMethod]
        public void PruebaEncriptarContraseniaFallida() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            string contrasenia = "Oscar1234$";            
            string contraseniaObtenida = servicioGestionAcceso.EncriptarContrasenia(contrasenia);
            Assert.IsNotNull(contraseniaObtenida);
        }        

        [TestMethod]
        public void PruebaValidarNombreUsuarioExitosa() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            string nombreUsuario = "MarioLimon";
            Assert.IsFalse(servicioGestionAcceso.ValidarNombreUsuario(nombreUsuario));
        }

        [TestMethod]
        public void PruebaValidarNombreUsuarioFallida() 
        {
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            string nombreUsuario = "nadie";            
            Assert.IsTrue(servicioGestionAcceso.ValidarNombreUsuario(nombreUsuario));
        }

        [TestMethod]
        public void PruebaRecuperarCuentaPorCorreoExitosa() 
        {
            string correo = "mariolimon@gmail.com";
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Cuenta cuentaEsperada=new Cuenta();
            cuentaEsperada.IdAcceso = 1;
            cuentaEsperada.IdJugador = 1;
            cuentaEsperada.IdPerfil = 1;
            Cuenta cuentaObtenida=servicioGestionAcceso.RecuperarCuentaPorCorreo(correo);
            Assert.AreEqual(cuentaEsperada,cuentaObtenida);
        }

        [TestMethod]
        public void PruebaRecuperarCuentaPorCorreoFallida() 
        {
            string correo = "ejemplo@gmail.com";
            ServicioPassword servicioGestionAcceso = new ServicioPassword();
            Cuenta cuentaEsperada = new Cuenta();
            cuentaEsperada.IdAcceso = 1;
            cuentaEsperada.IdJugador = 1;
            cuentaEsperada.IdPerfil = 1;
            Cuenta cuentaObtenida = servicioGestionAcceso.RecuperarCuentaPorCorreo(correo);
            Assert.AreNotEqual(cuentaEsperada, cuentaObtenida);
        }
    }
}
