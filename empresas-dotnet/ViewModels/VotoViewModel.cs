using empresas_dotnet.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace empresas_dotnet.ViewModels
{
    public class VotoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 4, ErrorMessage = "O campo {0} precisa ter entre {0} e {4}")]
        public int NumeroVoto { get; set; }
        public Guid FilmeId { get; set; }
        public string UserId { get; set; }
    }
}
