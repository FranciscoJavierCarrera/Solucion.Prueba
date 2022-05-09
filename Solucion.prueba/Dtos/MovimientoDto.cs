using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Dtos
{
    public class MovimientoDto
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public int TipoMovimientoId { get; set; }
        public TipoMovimientoDto TipoMovimiento { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
