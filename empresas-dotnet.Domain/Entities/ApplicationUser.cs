using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool Active { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }
    }
    
}
