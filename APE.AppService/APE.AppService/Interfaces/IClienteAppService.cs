using System;
using System.Collections.Generic;
using APE.Application.ViewModels.Cliente;

namespace APE.Application.Interfaces
{
    public interface IClienteAppService
    {
        void Inserir(CadastrarClienteViewModel viewModel);
        ClienteViewModel Deletar(Guid id);
        ICollection<ClienteViewModel> ListarComContato();

    }
}
