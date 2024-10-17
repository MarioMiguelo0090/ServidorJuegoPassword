using AccesoADatos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Validadores
{
    public class ValidacionPerfil : AbstractValidator<Perfil>
    {
        public ValidacionPerfil() 
        {
            RuleFor(perfil => perfil.nombreUsuario).NotEmpty().MaximumLength(50);
            RuleFor(perfil => perfil.descripcion).MaximumLength(280);            
        }   
    }
}
