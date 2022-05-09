using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UsuarioRol:ClassBase
    {
        [StringLength(32)]
        public string Descripcion { get; set; }

        public int UsurioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
