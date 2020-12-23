using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace empresas_dotnet.Infra.Repository
{
    public class AtorRepository : Repository<Ator>, IAtorRepository
    {
        public AtorRepository(ApplicationIdentityDbContext context) : base(context) { }

        public async Task<Ator> ObterAtorPorId(Guid id)
        {
            return await Db.Ator.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Ator>> ListarTodos()
        {
            return await Db.Ator.AsNoTracking()
                .ToListAsync();
        }
    }
}
