using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Domain.Entities
{
    public class Filme : Entity
    {
        public string Nome { get; private set; }
        public string Genero { get; private set; }
        public string Diretor { get; private set; }
        public IList<AtorFilme> AtorFilmes { get; set; }
        public IList<Voto> Votos { get; set; }

        public Filme() { }

        public Filme(string nome, string genero, string diretor)
        {
            Nome = nome;
            Genero = genero;
            Diretor = diretor;
            AtorFilmes = new List<AtorFilme>();
        }

        public void AdicionarAtor(AtorFilme atorFilme)
        {
            AtorFilmes.Add(atorFilme);
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarGenero(string genero)
        {
            Genero = genero;
        }

        public void AlterarDiretor(string diretor)
        {
            Diretor = diretor;
        }

        public void AtualizarAtorFilmes(IList<AtorFilme> atorFilmes)
        {
            AtorFilmes = atorFilmes;
        }
    }
}
