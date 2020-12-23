using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task<IEnumerable<Filme>> ListarTodos(int pageNumber, int pageSize);
        Task<Filme> ObterFilmePorId(Guid id);
    }
}
