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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(64);
            builder.Property(c => c.NumeroIdentificacion).IsRequired().HasMaxLength(32);
            builder.Property(c => c.ApellidoP).IsRequired().HasMaxLength(64);
            builder.Property(c => c.ApellidoM).IsRequired().HasMaxLength(64);
            builder.Property(c => c.Direcion).IsRequired().HasMaxLength(254);
            builder.Property(c => c.Telefono).IsRequired().HasMaxLength(15);
        }
    }
}
