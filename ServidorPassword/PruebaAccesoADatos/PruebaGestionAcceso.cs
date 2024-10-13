using AccesoADatos;
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
            acceso.contrasenia = "Qwerty1234";
            int resultadoObtenido=gestionAcceso.RegistrarAcceso(acceso);
            int resultadoEsperado = 1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRegistrarAccesoExcepcion()
        {
            GestionAcceso gestionAcceso = new GestionAcceso();
            Acceso acceso = new Acceso();                        
            int resultadoObtenido = gestionAcceso.RegistrarAcceso(acceso);
            int resultadoEsperado = -1;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
