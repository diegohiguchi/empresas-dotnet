using empresas_dotnet.Application.Filmes.Interfaces;
using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces;
using empresas_dotnet.Domain.Interfaces.Services;
using empresas_dotnet.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Application.Filmes
{
    public class FilmeApplication : BaseService, IFilmeApplication
    {
        private readonly IFilmeService _filmeService;
        public FilmeApplication(
            IFilmeService filmeService,
            INotificador notificador) : base(notificador)
        {
            _filmeService = filmeService;
        }

        public async Task<IEnumerable<Filme>> ObterTodos(int PageNumber, int pageSize)
        {
            return await _filmeService.ObterTodos(PageNumber, pageSize);
        }

        public async Task<Filme> ObterFilmePorId(Guid id)
        {
            return await _filmeService.ObterPorId(id);
        }

        public async Task Adicionar(Filme filme)
        {
            if (_filmeService.ObterPorId(filme.Id).Result != null)
            {
                Notificar("Já existe filme com esse id.");
                return;
            }

            var novoFilme = new Filme(
                filme.Nome,
                filme.Genero,
                filme.Diretor
            );

            foreach (var ator in filme.AtorFilmes)
                novoFilme.AdicionarAtor(ator);

            await _filmeService.Adicionar(novoFilme);
        }

        public async Task Atualizar(Guid id, Filme filme)
        {
            var novoFilme = _filmeService.ObterPorId(id).Result;

            if (novoFilme == null)
            {
                Notificar("Filme não encontrado.");
                return;
            }

            novoFilme.AlterarNome(filme.Nome);
            novoFilme.AlterarGenero(filme.Genero);
            novoFilme.AlterarDiretor(filme.Diretor);

            await _filmeService.Atualizar(novoFilme);
        }

        public async Task Remover(Guid id)
        {
            var novoFilme = _filmeService.ObterPorId(id).Result;

            if (novoFilme == null)
            {
                Notificar("Filme não encontrado.");
                return;
            }

            await _filmeService.Remover(id);
        }
    }
}
