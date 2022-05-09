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
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.Property(c => c.Saldo).HasColumnType("decimal(18,4)");
            builder.Property(c => c.NumeroCuenta).IsRequired().HasMaxLength(32);
            builder.HasOne(c => c.TipoCuenta).WithMany().HasForeignKey(t => t.TipoCuentaId);
            builder.HasOne(c => c.Cliente).WithMany(x=> x.Cuentas).HasForeignKey(c => c.ClienteId);
           
        }
    }
}
