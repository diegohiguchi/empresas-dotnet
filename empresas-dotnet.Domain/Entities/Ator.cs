using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Domain.Entities
{
    public class Ator : Entity
    {
        public string Nome { get; private set; }
        public virtual IEnumerable<AtorFilme> AtorFilmes { get; set; }

        public Ator() { }
        public Ator(string nome)
        {
            Nome = nome;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}
