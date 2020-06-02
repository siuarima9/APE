using System;
using System.Collections.Generic;
using System.Linq;
using APE.Domain.Interface;
using APE.Domain.Interface.Service;
using APE.Domain.Models;

namespace APE.Domain.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContatoRepository _contatoRepository;

        public ClienteService(IClienteRepository clienteRepository, IContatoRepository contatoRepository)
        {
            _clienteRepository = clienteRepository;
            _contatoRepository = contatoRepository;
        }

        public void Inserir(Cliente cliente)
        {
            var clientePesquisa = _clienteRepository.Listar(x => x.Cpf == cliente.Cpf);

            if (clientePesquisa.Any())
                return;

            var novoCliente = new Cliente.ClienteBuilder()
                .InformarId(Guid.NewGuid())
                .InformarCpf(cliente.Cpf)
                .InformarGenero(cliente.IdGenero)
                .InformarNomeCompleto(cliente.Nome, cliente.Sobrenome)
                .Build();

            _clienteRepository.Inserir(novoCliente);
            _clienteRepository.Salvar();

            InserirContatoDoClienteCadastrado(novoCliente.Id, cliente.Contato);
        }

        public Cliente Deletar(Guid id)
        {
            var clienteDeletar = _clienteRepository.ObterPorId(id);

            if(clienteDeletar == null)
                throw new Exception("Cliente não existe");

            _contatoRepository.Deletar(clienteDeletar.Contato);
            _clienteRepository.Deletar(clienteDeletar);
            
            Salvar();

            return clienteDeletar;
        }

        public ICollection<Cliente> ListarComContato()
        {
            var clientes = _clienteRepository.ListarComContato();

            return clientes;
        }

        private void InserirContatoDoClienteCadastrado(Guid idCliente, Contato contato)
        {
            var novoContato = new Contato.ContatoBuilder()
                .InformarId(Guid.NewGuid())
                .InformarIdCliente(idCliente)
                .InformarDddTelefone(contato.DddTelefone)
                .InformarNumeroTelefone(contato.NumeroTelefone)
                .InformarEmail(contato.Email)
                .Build();

            _contatoRepository.Inserir(novoContato);
            _contatoRepository.Salvar();
        }



        public void Salvar()
        {
            _clienteRepository.Salvar();
        }
    }
}
