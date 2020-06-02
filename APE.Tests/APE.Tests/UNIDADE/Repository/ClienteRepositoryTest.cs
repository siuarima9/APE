using APE.Domain.Enums;
using APE.Domain.Models;
using APE.Infra.Context;
using APE.Infra.Repositories;
using Moq;
using Xunit;

namespace APE.Tests.UNIDADE.Repository
{
    public class ClienteRepositoryTest
    {
        private ClienteRepository _clienteRepository;
        private Mock<ApeContext> _contextMock;

        public ClienteRepositoryTest()
        {
            _contextMock = new Mock<ApeContext>();
            _clienteRepository = new ClienteRepository(_contextMock.Object);
        }

        [Fact]
        public void AtualizarCliente_Sucesso()
        {
            //Arrange
            var cliente = new Cliente.ClienteBuilder()
                .InformarCpf("01322312311")
                .InformarGenero((int) Genero.Feminino)
                .InformarNomeCompleto("Fernando", "Souza")
                .Build();

            //Act
            _clienteRepository.Alterar(cliente);

            //Assert
            _contextMock.Verify(x => x.Update(cliente), Times.Once);
            _contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CadastrarCliente_Sucesso()
        {
            //Arrange
            var cliente = new Cliente.ClienteBuilder()
                .InformarCpf("01322312311")
                .InformarGenero((int)Genero.Feminino)
                .InformarNomeCompleto("Fernando", "Souza")
                .Build();

            //Act
            _clienteRepository.Inserir(cliente);

            //Assert
            _contextMock.Verify(x => x.Add(cliente), Times.Once);
            _contextMock.Verify(x => x.SaveChanges(), Times.Once);
        }


    }
}
