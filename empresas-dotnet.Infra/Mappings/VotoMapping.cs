using empresas_dotnet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Infra.Mappings
{
    public class VotoMapping : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.NumeroVoto)
                .IsRequired();

            builder.HasOne(f => f.Filme)
                .WithMany(p => p.Votos)
                .HasForeignKey(x => x.FilmeId);

            builder.HasOne(f => f.User)
                .WithMany(p => p.Votos)
                .HasForeignKey(x => x.UserId);

            builder.ToTable("Voto");
        }
    }
}
