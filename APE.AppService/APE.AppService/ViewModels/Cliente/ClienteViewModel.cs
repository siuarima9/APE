using System;

namespace APE.Application.ViewModels.Cliente
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public int IdGenero { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }

        public ContatoViewModel Contato { get; set; }
    }
}
