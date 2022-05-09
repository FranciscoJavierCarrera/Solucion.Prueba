using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cliente:ClassBase
    {
        public string NumeroIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direcion { get; set; }
        public string Telefono { get; set; }
        public ICollection<Cuenta> Cuentas { get; set; }
    }
}
