using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Services
{
    public class AtorService : IAtorService
    {
        private readonly IAtorRepository _atorRepository;

        public AtorService(IAtorRepository atorRepository)
        {
            _atorRepository = atorRepository;
        }

        public async Task<IEnumerable<Ator>> ObterTodos()
        {
            return await _atorRepository.ListarTodos();
        }

        public async Task Adicionar(Ator ator)
        {
            await _atorRepository.Adicionar(ator);
        }

        public async Task Atualizar(Ator ator)
        {
            await _atorRepository.Atualizar(ator);
        }

        public async Task Remover(Guid id)
        {
            await _atorRepository.Remover(id);
        }

        public async Task<Ator> ObterPorId(Guid id)
        {
            return _atorRepository.ObterAtorPorId(id).Result;
        }

        public void Dispose()
        {
            _atorRepository?.Dispose();
        }
    }
}
