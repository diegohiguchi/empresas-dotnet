using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using empresas_dotnet.Application.Filmes.Interfaces;
using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces;
using empresas_dotnet.Extensions;
using empresas_dotnet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace empresas_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : MainController
    {
        private readonly IFilmeApplication _filmeApplication;
        private readonly IMapper _mapper;

        public FilmesController(
            IFilmeApplication filmeApplication,
            INotificador notificador,
            IMapper mapper) : base(notificador)
        {
            _filmeApplication = filmeApplication;
            _mapper = mapper;
        }

        [ClaimsAuthorize("Filmes", "Listar")]
        [HttpPost("lista")]
        public async Task<IEnumerable<ListaFilmeViewModel>> ObterTodos(PaginacaoViewModel paginacao)
        {
            return _mapper.Map<IEnumerable<ListaFilmeViewModel>>(await _filmeApplication.ObterTodos(paginacao.PageNumber, paginacao.PageSize)).OrderBy(x => x.Nome);
        }

        [ClaimsAuthorize("Filmes", "Listar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ListaFilmeViewModel>> ObterPorId(Guid id)
        {
            var filme = _mapper.Map<ListaFilmeViewModel>(await _filmeApplication.ObterFilmePorId(id));

            if (filme == null) return NotFound();

            return filme;
        }

        [ClaimsAuthorize("Filmes", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<FilmeViewModel>> Adicionar(FilmeViewModel filmeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _filmeApplication.Adicionar(_mapper.Map<Filme>(filmeViewModel));

            return CustomResponse();
        }

        [ClaimsAuthorize("Filmes", "Editar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FilmeViewModel>> Atualizar(Guid id, FilmeViewModel filmeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _filmeApplication.Atualizar(id, _mapper.Map<Filme>(filmeViewModel));

            return CustomResponse();
        }

        [ClaimsAuthorize("Filmes", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _filmeApplication.Remover(id);

            return CustomResponse();
        }
    }
}
