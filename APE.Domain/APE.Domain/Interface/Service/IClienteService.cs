using System;
using System.Collections.Generic;
using APE.Domain.Models;

namespace APE.Domain.Interface.Service
{
    public interface IClienteService
    {
        void Inserir(Cliente cliente);
        Cliente Deletar(Guid id);
        ICollection<Cliente> ListarComContato();
    }
}
