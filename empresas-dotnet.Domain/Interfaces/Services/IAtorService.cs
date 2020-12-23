using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Services
{
    public interface IAtorService : IDisposable
    {
        Task<IEnumerable<Ator>> ObterTodos();
        Task Adicionar(Ator produto);
        Task Atualizar(Ator produto);
        Task Remover(Guid id);
        Task<Ator> ObterPorId(Guid id);
    }
}
