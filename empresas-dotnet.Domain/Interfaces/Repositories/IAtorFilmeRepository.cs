using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Repositories
{
    public interface IAtorFilmeRepository : IRepository<AtorFilme>
    {
        Task<IEnumerable<AtorFilme>> ListarTodos();
        Task<AtorFilme> ObterAtorFilmePorId(Guid id);
    }
}
