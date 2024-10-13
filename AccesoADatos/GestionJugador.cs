using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class GestionJugador
    {
        public int RegistrarJugador(Jugador _jugador) 
        {
            using (var contexto = new PasswordEntidades()) 
            {
                var jugador = new Jugador()
                {
                    nombre=_jugador.nombre,
                    apellidos=_jugador.apellidos,
                    estadoJugador=_jugador.estadoJugador,



                };

            }
                return 1;
        }
    }
}
