using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace empresas_dotnet.ViewModels
{
    public class AtorFilmeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid AtorId { get; set; }
        public Guid FilmeId { get; set; }

    }
}
