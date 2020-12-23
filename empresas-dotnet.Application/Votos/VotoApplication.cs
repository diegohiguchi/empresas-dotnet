using empresas_dotnet.Application.Votos.Interfaces;
using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces;
using empresas_dotnet.Domain.Interfaces.Services;
using empresas_dotnet.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Application.Votos
{
    public class VotoApplication : BaseService, IVotoApplication
    {
        private readonly IVotoService _votoService;
        public VotoApplication(
            IVotoService votoService,
            INotificador notificador) : base(notificador)
        {
            _votoService = votoService;
        }

        public async Task<IEnumerable<Voto>> ObterTodos()
        {
            return await _votoService.ObterTodos();
        }

        public async Task<Voto> ObterVotoPorId(Guid id)
        {
            return await _votoService.ObterPorId(id);
        }

        public async Task Adicionar(Voto voto)
        {
            if (_votoService.ObterPorId(voto.Id).Result != null)
            {
                Notificar("Já existe voto com esse id.");
                return;
            }

            var novoVoto = new Voto(
                voto.NumeroVoto,
                voto.FilmeId,
                voto.UserId
            );

            await _votoService.Adicionar(novoVoto);
        }

        public async Task Remover(Guid id)
        {
            var novoVoto = _votoService.ObterPorId(id).Result;

            if (novoVoto == null)
            {
                Notificar("Voto não encontrado.");
                return;
            }

            await _votoService.Remover(id);
        }
    }
}
