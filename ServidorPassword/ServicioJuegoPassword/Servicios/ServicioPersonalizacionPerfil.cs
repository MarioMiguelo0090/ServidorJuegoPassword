﻿using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioPersonalizacionPerfil
    {
                
        public int EditarCorreoPorIdAcceso(int idAcceso, string correo)
        {
            return _gestionPerfil.GuardarCorreoPorIdAcceso(idAcceso, correo);
        }

        public int EditarDescripcionPorIdPerfil(int idPerfil, string descripcion)
        {
            return _gestionPerfil.GuadarRutaImagenPorIdPerfil(idPerfil, descripcion);
        }

        public int EditarNombreUsuarioPorIdPerfil(int idPerfil, string nombreUsuario)
        {
            return _gestionPerfil.GuardarNombreUsuarioPorIdPerfil(idPerfil, nombreUsuario);
        }

        public int EditarRutaImagenPorIdPerfil(int idPerfil, string rutaImagen)
        {            
            return _gestionPerfil.GuadarRutaImagenPorIdPerfil(idPerfil,rutaImagen);
        }

        public int EditarContraseniaPorIdAcceso(int idAcceso, string contrasenia)
        {
            return _gestionPerfil.GuardarContraseniaPorIdAcceso(idAcceso, contrasenia);
        }
    }
}
