using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Repositories
{
    public interface IVotoRepository : IRepository<Voto>
    {
        Task<IEnumerable<Voto>> ListarTodos();
        Task<Voto> ObterVotoPorId(Guid id);
    }
}
