using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<IEnumerable<Filme>> ObterTodos(int pageNumber, int pageSize)
        {
            return await _filmeRepository.ListarTodos(pageNumber, pageSize);
        }

        public async Task Adicionar(Filme filme)
        {
            await _filmeRepository.Adicionar(filme);
        }

        public async Task Atualizar(Filme filme)
        {
            await _filmeRepository.Atualizar(filme);
        }

        public async Task Remover(Guid id)
        {
            await _filmeRepository.Remover(id);
        }

        public async Task<Filme> ObterPorId(Guid id)
        {
            return _filmeRepository.ObterFilmePorId(id).Result;
        }

        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }
    }
}
