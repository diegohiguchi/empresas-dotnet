using empresas_dotnet.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace empresas_dotnet.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
