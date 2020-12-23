using empresas_dotnet.Application.Ators.Interfaces;
using empresas_dotnet.Domain.Entities;
using empresas_dotnet.Domain.Interfaces;
using empresas_dotnet.Domain.Interfaces.Services;
using empresas_dotnet.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace empresas_dotnet.Application.Ators
{
    public class AtorApplication : BaseService, IAtorApplication
    {
        private readonly IAtorService _atorService;
        public AtorApplication(
            IAtorService atorService,
            INotificador notificador) : base(notificador)
        {
            _atorService = atorService;
        }

        public async Task<IEnumerable<Ator>> ObterTodos()
        {
            return await _atorService.ObterTodos();
        }

        public async Task<Ator> ObterAtorPorId(Guid id)
        {
            return await _atorService.ObterPorId(id);
        }

        public async Task Adicionar(Ator ator)
        {
            if (_atorService.ObterPorId(ator.Id).Result != null)
            {
                Notificar("Já existe ator com esse id.");
                return;
            }

            var novoAtor = new Ator(
                ator.Nome
            );

            await _atorService.Adicionar(novoAtor);
        }

        public async Task Atualizar(Guid id, Ator ator)
        {
            var novoAtor = _atorService.ObterPorId(id).Result;

            if (novoAtor == null)
            {
                Notificar("Ator não encontrado.");
                return;
            }

            novoAtor.AlterarNome(ator.Nome);

            await _atorService.Atualizar(novoAtor);
        }

        public async Task Remover(Guid id)
        {
            var novoAtor = _atorService.ObterPorId(id).Result;

            if (novoAtor == null)
            {
                Notificar("Ator não encontrado.");
                return;
            }

            await _atorService.Remover(id);
        }
    }
}
