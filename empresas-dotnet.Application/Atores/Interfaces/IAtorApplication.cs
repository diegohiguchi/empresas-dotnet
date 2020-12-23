using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Application.Ators.Interfaces
{
    public interface IAtorApplication
    {
        Task<IEnumerable<Ator>> ObterTodos();
        Task<Ator> ObterAtorPorId(Guid id);
        Task Adicionar(Ator ator);
        Task Atualizar(Guid id, Ator ator);
        Task Remover(Guid id);
    }
}
