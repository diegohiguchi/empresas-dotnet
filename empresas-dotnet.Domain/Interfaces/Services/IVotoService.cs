using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Services
{
    public interface IVotoService : IDisposable
    {
        Task<IEnumerable<Voto>> ObterTodos();
        Task Adicionar(Voto produto);
        Task Atualizar(Voto produto);
        Task Remover(Guid id);
        Task<Voto> ObterPorId(Guid id);
    }
}
