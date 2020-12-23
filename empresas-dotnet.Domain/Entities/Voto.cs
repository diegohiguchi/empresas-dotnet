using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace empresas_dotnet.Domain.Entities
{
    public class Voto : Entity
    {
        public int NumeroVoto { get; private set; }
        public Guid FilmeId { get; private set; }
        public string UserId { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Voto() { }

        public Voto(int numeroVoto, Guid filmeId, string usuarioId)
        {
            NumeroVoto = numeroVoto;
            FilmeId = filmeId;
            UserId = usuarioId;
        }
    }
}
