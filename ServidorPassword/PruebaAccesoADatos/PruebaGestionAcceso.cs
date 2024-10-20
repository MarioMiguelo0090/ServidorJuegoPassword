﻿using AccesoADatos;
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
        public void PruebaRegistrarAccesoExcepcion()
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
        public void PruebaRetornarContraseniaPorCorreoExitoso() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            String correo = "mariolimon@gmail.com";
            string resultadoEsperado = "Qwerty1234";
            String resultadoObtenido=gestionAcceso.RetornarContraseniaPorCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarPresenciaCorreoExitoso() 
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            String correo = "mariolimon@gmail.com";
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionAcceso.ValidarPresenciaCorreo(correo);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
