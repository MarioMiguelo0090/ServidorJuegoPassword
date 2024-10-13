using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Anfitrion
{
    internal class InicioAnfitrion
    {
        static void Main(string[] args)
        {
            using (ServiceHost anfitrion = new ServiceHost(typeof(ServicioJuegoPassword.Servicios.ServicioChat))) 
            {
                anfitrion.Open();
                Console.WriteLine("El servidor esta corriendo");
                Console.ReadLine();
            }
        }
    }
}
