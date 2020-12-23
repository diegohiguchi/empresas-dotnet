using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Domain.Entities
{
    public class AtorFilme : Entity
    {
        public Guid AtorId { get; set; }
        public virtual Ator Ator { get; private set; }
        public Guid FilmeId { get; set; }
        public virtual Filme Filme { get; private set; }

        public AtorFilme() { }

        public AtorFilme(Guid atorId, Guid filmeId)
        {
            AtorId = atorId;
            FilmeId = filmeId;
        }
    }
}
