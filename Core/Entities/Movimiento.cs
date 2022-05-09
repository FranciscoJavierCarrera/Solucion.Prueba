using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Movimiento : ClassBase
    {
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
        public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento {get; set;}
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
