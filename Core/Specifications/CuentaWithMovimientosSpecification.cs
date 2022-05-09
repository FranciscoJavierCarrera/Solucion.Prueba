using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class CuentaWithMovimientosSpecification :BaseSpecification<Cuenta>
    {
        public CuentaWithMovimientosSpecification()
        {
            AddInclude(c=> c.Movimientos);
            AddInclude(c => c.TipoCuenta);
            AddInclude(c => c.Cliente);
        }
        public CuentaWithMovimientosSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(c=> c.Movimientos);
            AddInclude(c => c.TipoCuenta);
            AddInclude(c => c.Cliente);
           
        }
    }
}
