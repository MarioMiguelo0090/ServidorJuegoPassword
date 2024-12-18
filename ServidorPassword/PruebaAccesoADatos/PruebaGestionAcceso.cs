﻿using AccesoADatos;
using AccesoADatos.Auxiliares;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionAcceso
    {
        [TestInitialize]
        public void ConfigurarAcceso(TestContext contextoPrueba) 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();
            acceso.correo = "ejemplo@gmail.com";
            acceso.contrasenia = "11c3c4b9db9fc12fd6f7c57a9ab81468668ff1d3bb0ed28ed507b6a5c989e2aa";
            Jugador jugador = new Jugador();
            jugador.nombreUsuario = "Ejemplo";
            jugador.rutaImagen = "";
            jugador.descripcion = "";
            gestionAcceso.RegistrarAcceso(acceso, jugador);            
        }
        
        [TestMethod]
        public void PruebaRegistrarAccesoExitoso()
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();
            acceso.correo = "mariolimon@gmail.com";
            acceso.contrasenia = "11c3c4b9db9fc12fd6f7c57a9ab81468668ff1d3bb0ed28ed507b6a5c989e2aa";
            Jugador jugador=new Jugador();
            jugador.nombreUsuario = "MarioLimon";
            jugador.rutaImagen = "";
            jugador.descripcion = "";
            int resultadoObtenido=gestionAcceso.RegistrarAcceso(acceso,jugador);
            int resultadoEsperado = 1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
        
        [TestMethod]
        public void PruebaRegistrarAccesoFallida()
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();                
            Jugador jugador =new Jugador();
            int resultadoObtenido = gestionAcceso.RegistrarAcceso(acceso,jugador);
            int resultadoEsperado = -1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetonarIdAccesoPorCorreoExitoso() 
        {            
            String correo= "mariolimon@gmail.com";
            int resultadoEsperado = 1;
            GestionAcceso gestionAcceso=new GestionAcceso();
            int resultadoObtenido= gestionAcceso.RetonarIdAccesoPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetonarIdAccesoPorCorreoFallida() 
        {            
            string correo = "ejemplo@hotmail.com";
            int resultadoEsperado = 0;
            GestionAcceso gestionAcceso = new GestionAcceso();
            int resultadoObtenido = gestionAcceso.RetonarIdAccesoPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetornarContraseniaPorCorreoExitoso() 
        {            
            string correo = "mariolimon@gmail.com";
            string resultadoEsperado = "Qwerty1234";
            GestionAcceso gestionAcceso = new GestionAcceso();
            string resultadoObtenido= gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRetornarContraseniaPorCorreoFallida() 
        {            
            string correo = "ejemplo@hotmail.com";
            string contraseniaEsperada = "";
            GestionAcceso gestionAcceso = new GestionAcceso();
            string contrasniaObtenida= gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(contraseniaEsperada, contrasniaObtenida);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoExitoso() 
        {            
            string correo = "mariolimon@gmail.com";
            int resultadoEsperado = 1;
            GestionAcceso gestionAcceso = new GestionAcceso();
            int resultadoObtenido= gestionAcceso.ValidarPresenciaCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoFallida() 
        {            
            string correo = "ejemplo@gmail.com";
            int resultadoEsperado = 0;
            GestionAcceso gestionAcceso = new GestionAcceso();
            int resultadoObtenido= gestionAcceso.ValidarPresenciaCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerCuentaPorCorreoExitosa() 
        {   
            Cuenta cuentaPrueba=new Cuenta();
            cuentaPrueba.IdAcceso = 1;
            cuentaPrueba.Correo= "mariolimon@gmail.com";
            cuentaPrueba.Contrasenia= "11c3c4b9db9fc12fd6f7c57a9ab81468668ff1d3bb0ed28ed507b6a5c989e2aa";            
            cuentaPrueba.IdJugador = 1;            
            cuentaPrueba.NombreUsuario = "MarioLimon";
            cuentaPrueba.RutaImagen = "";
            cuentaPrueba.Descripcion = "";
            GestionAcceso gestionAcceso = new GestionAcceso();
            Cuenta cuentaObtenida = gestionAcceso.ObtenerCuentaPorCorreo(cuentaPrueba.Correo);
            Assert.AreEqual(cuentaPrueba, cuentaObtenida);
        }

        [TestMethod]
        public void PruebaObtenerCuentaPorCorreoFallida() 
        {            
            string correo = "ejemplo@gmail.com";
            Cuenta cuentaEsperada= new Cuenta();
            cuentaEsperada.IdAcceso= 0;
            GestionAcceso gestionAcceso = new GestionAcceso();
            Cuenta cuentaObtenida= gestionAcceso.ObtenerCuentaPorCorreo(correo);
            Assert.AreEqual(cuentaEsperada.IdAcceso,cuentaObtenida.IdAcceso);
        }

        [TestMethod]
        public void PruebaRecuperarCuentaPorIdJugadorExitosa() 
        {
            Cuenta cuentaEsperada = new Cuenta {
                IdAcceso = 1,
                IdJugador = 1,               
            };
            int idJugador = 1;
            GestionAcceso gestionAcceso = new GestionAcceso();
            Cuenta cuentaObtenida = gestionAcceso.RecuperarCuentaPorIdJugador(idJugador);
            Assert.AreEqual(cuentaEsperada,cuentaObtenida);
        }

    }
}
