using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Services
{
    public class VotoService : IVotoService
    {
        private readonly IVotoRepository _votoRepository;

        public VotoService(IVotoRepository votoRepository)
        {
            _votoRepository = votoRepository;
        }

        public async Task<IEnumerable<Voto>> ObterTodos()
        {
            return await _votoRepository.ListarTodos();
        }

        public async Task Adicionar(Voto voto)
        {
            await _votoRepository.Adicionar(voto);
        }

        public async Task Atualizar(Voto voto)
        {
            await _votoRepository.Atualizar(voto);
        }

        public async Task Remover(Guid id)
        {
            await _votoRepository.Remover(id);
        }

        public async Task<Voto> ObterPorId(Guid id)
        {
            return _votoRepository.ObterVotoPorId(id).Result;
        }

        public void Dispose()
        {
            _votoRepository?.Dispose();
        }
    }
}
