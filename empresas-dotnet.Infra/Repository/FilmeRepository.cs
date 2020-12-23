using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empresas_dotnet.Infra.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(ApplicationIdentityDbContext context) : base(context) { }

        public async Task<Filme> ObterFilmePorId(Guid id)
        {
            return await Db.Filme.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Filme>> ListarTodos(int pageNumber, int pageSize)
        {
            return await Db.Filme.AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.AtorFilmes).ThenInclude(p=> p.Ator)
                .ToListAsync();
        }
    }
}
