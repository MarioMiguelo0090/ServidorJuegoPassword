using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionPerfil
    {
        [TestMethod]
        public void PruebaValidarPresenciaDeNombreUsuarioExitoso() 
        {
            GestionPerfil gestionPerfil = new GestionPerfil();
            string nombreUsuario = "MarioLimon";
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionPerfil.ValidarPresenciaDeNombreUsuario(nombreUsuario);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarRutaImagenPorIdPerfilExitosa() 
        {
            int idPerfil = 1;
            string rutaImagen = "ImagenEjemplo.jpg";
            GestionPerfil gestionPerfil=new GestionPerfil();    
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuadarRutaImagenPorIdPerfil(idPerfil,rutaImagen);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaGuadarDescripcionPorIdPerfilExitosa() 
        {
            int idPerfil = 1;
            string descripcion = "Soy un nuevo jugador en password";
            GestionPerfil gestionPerfil = new GestionPerfil();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionPerfil.GuadarDescripcionPorIdPerfil(idPerfil,descripcion);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }
    }
}
