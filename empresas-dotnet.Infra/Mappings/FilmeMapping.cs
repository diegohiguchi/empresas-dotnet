using empresas_dotnet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Infra.Mappings
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Genero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Diretor)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Filme");
        }
    }
}
