using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empresas_dotnet.Infra.Repository
{
    public class VotoRepository : Repository<Voto>, IVotoRepository
    {
        public VotoRepository(ApplicationIdentityDbContext context) : base(context) { }

        public async Task<Voto> ObterVotoPorId(Guid id)
        {
            return await Db.Voto.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Voto>> ListarTodos()
        {
            return await Db.Voto.AsNoTracking()
                .ToListAsync();
        }
    }
}
