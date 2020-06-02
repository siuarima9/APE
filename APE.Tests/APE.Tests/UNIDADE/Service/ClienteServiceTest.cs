using APE.Domain.Enums;
using APE.Domain.Models;
using APE.Domain.Service;
using APE.Infra.Context;
using APE.Infra.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace APE.Tests.UNIDADE.Service
{
    public class ClienteServiceTest
    {
        private Mock<ApeContext> _contextMock;
        private Mock<ClienteRepository> _clienteRepository;
        private Mock<ContatoRepository> _contatoRepository;
        private ClienteService _clienteService;
        private Mock<DbSet<Cliente>> _dbSetCliente;

        public ClienteServiceTest()
        {
            _contextMock = new Mock<ApeContext>();
            _dbSetCliente = new Mock<DbSet<Cliente>>();
            _clienteRepository = new Mock<ClienteRepository>(_contextMock.Object);
            _contatoRepository = new Mock<ContatoRepository>(_contextMock.Object);
            _clienteService = new ClienteService(_clienteRepository.Object, _contatoRepository.Object);
        }

        [Fact]
        public void InserirCliente_Sucesso()
        {
            //Arrange
            var clienteIncompleto = CriarClienteIncompleto();

            //Act
            _clienteRepository.Setup(x => x.Listar(It.IsAny<Expression<Func<Cliente, bool>>>())).Returns(new List<Cliente>());
            _clienteService.Inserir(clienteIncompleto);

            //Assert
            _clienteRepository.Verify(x => x.Inserir(It.IsAny<Cliente>()), Times.Once);
            _contatoRepository.Verify(x => x.Inserir(It.IsAny<Contato>()), Times.Once);
            _clienteRepository.Verify(x => x.Salvar(), Times.Once);
            _contatoRepository.Verify(x => x.Salvar(), Times.Once);
        }

        [Fact]
        public void InserirCliente_ClienteJaExiste()
        {
            //Arrange
            var clienteIncompleto = CriarClienteIncompleto();

            //Act
            _clienteRepository.Setup(x => x.Listar(It.IsAny<Expression<Func<Cliente, bool>>>())).Returns(new List<Cliente>(){new Cliente()});
            _clienteService.Inserir(clienteIncompleto);

            //Assert
            _clienteRepository.Verify(x => x.Inserir(It.IsAny<Cliente>()), Times.Never);
            _contatoRepository.Verify(x => x.Inserir(It.IsAny<Contato>()), Times.Never);
            _clienteRepository.Verify(x => x.Salvar(), Times.Never);
            _contatoRepository.Verify(x => x.Salvar(), Times.Never);
        }

        [Fact]
        public void DeletarCliente_Sucesso()
        {
            //Arrange
            var idCliente = Guid.NewGuid();
            var contato = new Contato.ContatoBuilder().InformarIdCliente(idCliente).Build();
            var cliente = new Cliente.ClienteBuilder().InformarId(idCliente).InformarContato(contato).Build();
            
            AssertDbSet((new List<Cliente>() { cliente }).AsQueryable());

            string mensagem = string.Empty;
            //Act
            try
            {
                _clienteService.Deletar(Guid.NewGuid());
            }
            catch (Exception e)
            {
                mensagem = e.Message;
            }
            
            //Assert
            _clienteRepository.Verify(x => x.Deletar(cliente), Times.Never);
            _contatoRepository.Verify(x => x.Deletar(cliente.Contato), Times.Never);
            _clienteRepository.Verify(x => x.Salvar(), Times.Never);
            mensagem.Should().Be("Cliente não existe");
        }

        [Fact]
        public void DeletarCliente_ClienteNaoEncontrado()
        {
            //Arrange
            var idCliente = Guid.NewGuid();
            var contato = new Contato.ContatoBuilder().InformarIdCliente(idCliente).Build();
            var cliente = new Cliente.ClienteBuilder().InformarId(idCliente).InformarContato(contato).Build();

            AssertDbSet((new List<Cliente>() { cliente }).AsQueryable());

            //Act
            _clienteService.Deletar(idCliente);

            //Assert
            _clienteRepository.Verify(x => x.Deletar(cliente), Times.Once);
            _contatoRepository.Verify(x => x.Deletar(cliente.Contato), Times.Once);
            _clienteRepository.Verify(x => x.Salvar(), Times.Once);
        }

        private Cliente CriarClienteIncompleto()
        {
            var contato = new Contato.ContatoBuilder().InformarDddTelefone("79").InformarNumeroTelefone("78987898").InformarEmail("email@email.com").Build();

            return new Cliente.ClienteBuilder().InformarContato(contato).InformarNomeCompleto("Jose", "Pereira").InformarCpf("45678945678").InformarGenero((int)Genero.Masculino).Build();
        }

        private void AssertDbSet(IQueryable<Cliente> clientes)
        {
            _dbSetCliente.As<IQueryable<Cliente>>().Setup(x => x.Provider).Returns(clientes.Provider);
            _dbSetCliente.As<IQueryable<Cliente>>().Setup(x => x.Expression).Returns(clientes.Expression);
            _dbSetCliente.As<IQueryable<Cliente>>().Setup(x => x.ElementType).Returns(clientes.ElementType);
            _dbSetCliente.As<IQueryable<Cliente>>().Setup(x => x.GetEnumerator()).Returns(clientes.GetEnumerator);

            _dbSetCliente.Setup(r => r.Add(It.IsAny<Cliente>())).Callback<Cliente>((s) => clientes.ToList().Add(s));
            _dbSetCliente.Setup(r => r.Remove(It.IsAny<Cliente>())).Callback<Cliente>((s) => clientes.ToList().Remove(s));

            _contextMock.Setup(x => x.Set<Cliente>()).Returns(_dbSetCliente.Object);
        }
    }
}
