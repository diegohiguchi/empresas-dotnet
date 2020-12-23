using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Application.Votos.Interfaces
{
    public interface IVotoApplication
    {
        Task<IEnumerable<Voto>> ObterTodos();
        Task<Voto> ObterVotoPorId(Guid id);
        Task Adicionar(Voto voto);
        //Task Atualizar(Guid id, Voto voto);
        Task Remover(Guid id);
    }
}
