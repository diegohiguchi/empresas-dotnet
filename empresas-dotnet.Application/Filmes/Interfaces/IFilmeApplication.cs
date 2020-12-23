using empresas_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Application.Filmes.Interfaces
{
    public interface IFilmeApplication
    {
        Task<IEnumerable<Filme>> ObterTodos(int pageNumber, int pageSize);
        Task<Filme> ObterFilmePorId(Guid id);
        Task Adicionar(Filme filme);
        Task Atualizar(Guid id, Filme filme);
        Task Remover(Guid id);
    }
}
