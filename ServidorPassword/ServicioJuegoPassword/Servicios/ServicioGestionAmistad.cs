﻿using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioGestionAmistad
    {
        private GestionAmistad _gestionAmistad = new GestionAmistad();
        public int RegistrarAmistad(Amistad amistad)
        {
            return _gestionAmistad.RegistrarNuevaSolicitudAmistad(amistad);            
        }

        public int ResponderSolicitudAmistad(Amistad amistad)
        {
            return _gestionAmistad.ConfirmarSolicitudAmistadPorIdAmistad(amistad);
        }

        public List<int> ConsultarAmistadesPorIdJugador(int idJugador)
        {
            return _gestionAmistad.RecuperarIdAmigosPorIdJugador(idJugador);
        }

        public List<int> ConsultarSolicitudesAmistadPorIdJugador(int idJugador)
        {
            return _gestionAmistad.RecuperarSolicitudesAmistadPorIdJugador(idJugador);
        }

        public int ConsultarIdJugadorPorCorreo(string correo)
        {
            return _gestionAmistad.ObtenerIdJugadorPorCorreo(correo);
        }

        public List<string> ObtenerNombresDeUsuarioPorIdJugadores(List<int> idJugadores)
        {
            return _gestionAmistad.RecuperarNombresDeUsuarioPorIdJugador(idJugadores);
        }

        public int ValidarExistenciaAmistadPorIdJugadores(int idJugadorUno, int idJugadorDos)
        {
            return _gestionAmistad.ValidarExistenciaAmistadPorIdJugadores(idJugadorUno,idJugadorDos);
        }

        public int RecuperarIdAmistadPorIdJugadores(int idJugadorUno, int idJugadorDos)
        {
            return _gestionAmistad.ObtenerIdAmistadPorIdJugadores(idJugadorUno,idJugadorDos);
        }
    }
}
