using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Dtos
{
    public class UsuarioDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

    }

    public class UsuarioRegistroDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

    }
}
