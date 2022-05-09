using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Usuario:IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool Snactivo { get; set; }

        public List<UsuarioRol> UsuarioRol { get; set; }
    }
}
