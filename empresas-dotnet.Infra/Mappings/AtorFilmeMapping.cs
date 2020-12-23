using empresas_dotnet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Infra.Mappings
{
    public class AtorFilmeMapping : IEntityTypeConfiguration<AtorFilme>
    {
        public void Configure(EntityTypeBuilder<AtorFilme> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(f => f.Filme)
               .WithMany(p => p.AtorFilmes)
               .HasForeignKey(x => x.FilmeId);

            builder.HasOne(f => f.Ator)
              .WithMany(p => p.AtorFilmes)
              .HasForeignKey(x => x.AtorId);

            builder.ToTable("AtorFilme");
        }
    }
}
