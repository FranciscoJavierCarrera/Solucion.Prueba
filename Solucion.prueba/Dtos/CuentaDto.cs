using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Dtos
{
    public class CuentaDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TipoCuentaId { get; set; }
        
        public decimal Saldo { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaUltimoMov { get; set; }
    }

    public class CuentaDetailDto: CuentaDto
    {
        public string TipoCuentaDescripcion { get; set; }
        public TipoCuentaDto TipoCuenta { get; set; }
        public string ClienteNombre { get; set; }
        public ICollection<MovimientoDto> Movimientos { get; set; }
    }

    public class CuentaShowDto
    {
        public int Id { get; set; }
        public int TipoCuentaId { get; set; }
        public string TipoCuentaDescripcion { get; set; }
        public string ClienteNombre { get; set; }
        public decimal Saldo { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaUltimoMov { get; set; }
    }
}
