using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TipoMovimiento:ClassBase
    {
        public string Descripcion { get; set; }
        public int Signo { get; set; }
    }
}
