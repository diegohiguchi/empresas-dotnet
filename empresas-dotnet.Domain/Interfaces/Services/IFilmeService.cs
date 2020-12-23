using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Interfaces.Services
{
    public interface IFilmeService : IDisposable
    {
        Task<IEnumerable<Filme>> ObterTodos(int pageNumber, int pageSize);
        Task Adicionar(Filme produto);
        Task Atualizar(Filme produto);
        Task Remover(Guid id);
        Task<Filme> ObterPorId(Guid id);
    }
}
