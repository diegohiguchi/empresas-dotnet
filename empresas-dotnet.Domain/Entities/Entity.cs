using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
