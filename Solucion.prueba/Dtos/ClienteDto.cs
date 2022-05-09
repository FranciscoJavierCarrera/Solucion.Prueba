using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Direcion { get; set; }
        public string Telefono { get; set; }
        
    }

    public class ClienteWithCuentasDto: ClienteDto
    {
        public ICollection<CuentaShowDto> Cuentas { get; set; }
    }

    public class ClienteEditDto: ClienteDto
    {
        public ICollection<CuentaDto> Cuentas { get; set; }
    }
}
