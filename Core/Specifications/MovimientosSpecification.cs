using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class MovimientosSpecification : BaseSpecification<Movimiento>
    {
        public MovimientosSpecification()
        {
            AddInclude(m => m.TipoMovimiento);
        }
        
        public MovimientosSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(m => m.TipoMovimiento);
        }
    }
}
