using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Auxiliares
{
    public class Cuenta
    {
        public int IdAcceso { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public int IdPerfil { get; set; }
        public string NombreUsuario { get; set; }
        public string RutaImagen { get; set; }
        public string Descripcion { get; set; }
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public override bool Equals(object obj)
        {
            bool resultado = false;
            if (obj is Cuenta nuevaCuenta) 
            {
                resultado= this.IdAcceso == nuevaCuenta.IdAcceso &&
                    this.IdJugador == nuevaCuenta.IdJugador &&
                    this.IdPerfil == nuevaCuenta.IdPerfil;
            }
            return resultado;
        }
    }    
}
