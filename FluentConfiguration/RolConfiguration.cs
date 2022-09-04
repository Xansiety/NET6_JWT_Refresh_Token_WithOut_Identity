using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET6_JWT_Refresh_Token_WithOut_Identity.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6_JWT_Refresh_Token_WithOut_Identity.FluentConfiguration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.Property(p => p.Id)
                    .IsRequired();
            builder.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(p => p.Activo)
                    .HasDefaultValue(true);
        }
    }
}
