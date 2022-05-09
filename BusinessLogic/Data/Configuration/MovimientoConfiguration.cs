using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data.Configuration
{
    public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.Property(m => m.Monto).IsRequired().HasColumnType("decimal(18,4)");
            builder.HasOne(t => t.Cuenta).WithMany(x => x.Movimientos).HasForeignKey(y=> y.CuentaId);
        }
    }
}
