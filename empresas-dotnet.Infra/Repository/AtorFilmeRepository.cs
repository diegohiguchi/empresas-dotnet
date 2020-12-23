using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empresas_dotnet.Infra.Repository
{
    public class AtorFilmeRepository : Repository<AtorFilme>, IAtorFilmeRepository
    {
        public AtorFilmeRepository(ApplicationIdentityDbContext context) : base(context) { }

        public async Task<AtorFilme> ObterAtorFilmePorId(Guid id)
        {
            return await Db.AtorFilme.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<AtorFilme>> ListarTodos()
        {
            return await Db.AtorFilme.AsNoTracking()
                .Include(p => p.Ator)
                .Include(p => p.Filme)
                .ToListAsync();
        }
    }
}
