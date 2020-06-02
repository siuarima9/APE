using System;
using System.Collections.Generic;
using System.Text;

namespace APE.Application.ViewModels.Cliente
{
    public class ContatoViewModel
    {
        public Guid Id { get; set; }
        public string DddTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }
    }
}
