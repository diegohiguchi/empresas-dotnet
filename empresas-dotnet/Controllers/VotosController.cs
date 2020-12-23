using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using empresas_dotnet.Application.Votos.Interfaces;
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
    public class VotosController : MainController
    {
        private readonly IVotoApplication _votoApplication;
        private readonly IMapper _mapper;

        public VotosController(
            IVotoApplication votoApplication,
            INotificador notificador,
            IMapper mapper) : base(notificador)
        {
            _votoApplication = votoApplication;
            _mapper = mapper;
        }

        [ClaimsAuthorize("Votos", "Listar")]
        [HttpGet]
        public async Task<IEnumerable<VotoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<VotoViewModel>>(await _votoApplication.ObterTodos()).OrderByDescending(x => x.NumeroVoto);
        }

        [ClaimsAuthorize("Votos", "Listar")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VotoViewModel>> ObterPorId(Guid id)
        {
            var voto = _mapper.Map<VotoViewModel>(await _votoApplication.ObterVotoPorId(id));

            if (voto == null) return NotFound();

            return voto;
        }

        [ClaimsAuthorize("Votos", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<VotoViewModel>> Adicionar(VotoViewModel votoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _votoApplication.Adicionar(_mapper.Map<Voto>(votoViewModel));

            return CustomResponse();
        }

        [ClaimsAuthorize("Votos", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _votoApplication.Remover(id);

            return CustomResponse();
        }
    }
}
