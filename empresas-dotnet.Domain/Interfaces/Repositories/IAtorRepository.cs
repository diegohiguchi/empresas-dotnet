using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Repositories
{
    public interface IAtorRepository : IRepository<Ator>
    {
        Task<IEnumerable<Ator>> ListarTodos();
        Task<Ator> ObterAtorPorId(Guid id);
    }
}
