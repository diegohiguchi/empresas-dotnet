using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empresas_dotnet.ViewModels
{
    public class ListaFilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Genero { get; set; }

        public string Diretor { get; set; }

        public IList<ListaAtorFilmeViewModel> AtorFilmes { get; set; }

    }
}
