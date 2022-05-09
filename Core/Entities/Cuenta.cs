using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cuenta:ClassBase
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int TipoCuentaId { get; set;}
        public TipoCuenta TipoCuenta { get; set;}
        public decimal Saldo { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaUltimoMov { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
