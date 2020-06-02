using System;
using System.Collections.Generic;
using APE.Application.Interfaces;
using APE.Application.ViewModels.Cliente;
using APE.Domain.Interface.Service;
using APE.Domain.Models;
using AutoMapper;

namespace APE.Application.Concretes
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public void Inserir(CadastrarClienteViewModel viewModel)
        {
            _clienteService.Inserir(_mapper.Map<Cliente>(viewModel));
        }

        public ClienteViewModel Deletar(Guid id)
        {
            var cliente = _clienteService.Deletar(id);

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        public ICollection<ClienteViewModel> ListarComContato()
        {
            var clientes = _mapper.Map<ICollection<ClienteViewModel>>(_clienteService.ListarComContato());

            return clientes;
        }
    }
}
