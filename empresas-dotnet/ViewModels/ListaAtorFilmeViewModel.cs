using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empresas_dotnet.ViewModels
{
    public class ListaAtorFilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid AtorId { get; set; }
        public AtorViewModel Ator { get; set; }
    }
}
