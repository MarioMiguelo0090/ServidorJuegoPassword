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
        public string NombreUsuario { get; set; }
        public string RutaImagen { get; set; }
        public string Descripcion { get; set; }
        public int IdJugador { get; set; }        

        public int IdEstadistica {  get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Cuenta nuevaCuenta)
            {
                return this.IdAcceso == nuevaCuenta.IdAcceso &&
                       this.IdJugador == nuevaCuenta.IdJugador;
            }
            return false;
        }

        public override int GetHashCode()
        {            
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + IdAcceso.GetHashCode();
                hash = hash * 23 + IdJugador.GetHashCode();
                return hash;
            }
        }
    }    
}
