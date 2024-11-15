using AccesoADatos;
using AccesoADatos.Auxiliares;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionAcceso
    {
        
        [TestMethod]
        public void PruebaRegistrarAccesoExitoso()
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();
            acceso.correo = "mariolimon@gmail.com";
            acceso.contrasenia = "11c3c4b9db9fc12fd6f7c57a9ab81468668ff1d3bb0ed28ed507b6a5c989e2aa";
            Jugador jugador=new Jugador();
            jugador.nombre = "Mario Miguel";
            jugador.apellidos = "Limon Cabrera";
            jugador.estadoJugador = true;
            Perfil perfil = new Perfil();
            perfil.nombreUsuario = "MarioLimon";
            perfil.rutaImagen = "";
            perfil.descripcion = "";
            int resultadoObtenido=gestionAcceso.RegistrarAcceso(acceso,jugador,perfil);
            int resultadoEsperado = 1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
        
        [TestMethod]
        public void PruebaRegistrarAccesoFallida()
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();    
            Perfil perfil = new Perfil();
            Jugador jugador =new Jugador();
            int resultadoObtenido = gestionAcceso.RegistrarAcceso(acceso,jugador,perfil);
            int resultadoEsperado = -1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetonarIdAccesoPorCorreoExitoso() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            String correo= "mariolimon@gmail.com";
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionAcceso.RetonarIdAccesoPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetonarIdAccesoPorCorreoFallida() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "ejemplo@hotmail.com";
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionAcceso.RetonarIdAccesoPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetornarContraseniaPorCorreoExitoso() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "mariolimon@gmail.com";
            string resultadoEsperado = "Qwerty1234";
            string resultadoObtenido=gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetornarContraseniaPorCorreoFallida() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "ejemplo@hotmail.com";
            string contraseniaEsperada = "";
            string contrasniaObtenida=gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(contraseniaEsperada, contrasniaObtenida);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoExitoso() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "mariolimon@gmail.com";
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionAcceso.ValidarPresenciaCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoFallida() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            string correo = "ejemplo@gmail.com";
            int resultadoEsperado = 0;
            int resultadoObtenido=gestionAcceso.ValidarPresenciaCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerCuentaPorCorreoExitosa() 
        {   
            Cuenta cuentaPrueba=new Cuenta();
            cuentaPrueba.IdAcceso = 1;
            cuentaPrueba.Correo= "mariolimon@gmail.com";
            cuentaPrueba.Contrasenia= "11c3c4b9db9fc12fd6f7c57a9ab81468668ff1d3bb0ed28ed507b6a5c989e2aa";
            cuentaPrueba.Nombre = "Mario Miguel";
            cuentaPrueba.Apellidos = "Limon Cabrera";
            cuentaPrueba.IdJugador = 1;
            cuentaPrueba.IdPerfil = 1;
            cuentaPrueba.NombreUsuario = "MarioLimon";
            cuentaPrueba.RutaImagen = "";
            cuentaPrueba.Descripcion = "";            
            GestionAcceso gestionAcceso = new GestionAcceso();
            Cuenta cuentaObtenida=gestionAcceso.ObtenerCuentaPorCorreo(cuentaPrueba.Correo);
            Assert.AreEqual(cuentaPrueba, cuentaObtenida);
        }

        [TestMethod]
        public void PruebaObtenerCuentaPorCorreoFallida() 
        {
            GestionAcceso gestionAcceso=new GestionAcceso();
            string correo = "ejemplo@gmail.com";
            Cuenta cuentaEsperada= new Cuenta();
            cuentaEsperada.IdAcceso= 0;
            Cuenta cuentaObtenida=gestionAcceso.ObtenerCuentaPorCorreo(correo);
            Assert.AreEqual(cuentaEsperada.IdAcceso,cuentaObtenida.IdAcceso);
        }

        [TestMethod]
        public void PruebaRecuperarCuentaPorIdJugadorExitosa() 
        {
            Cuenta cuentaEsperada = new Cuenta {
                IdAcceso = 1,
                IdJugador = 1,
                IdPerfil = 1,
            };
            int idJugador = 1;
            GestionAcceso gestionAcceso = new GestionAcceso();
            Cuenta cuentaObtenida = gestionAcceso.RecuperarCuentaPorIdJugador(idJugador);
            Assert.AreEqual(cuentaEsperada,cuentaObtenida);
        }

    }
}
