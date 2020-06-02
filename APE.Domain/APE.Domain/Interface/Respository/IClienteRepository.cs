using APE.Domain.Models;
using System;
using System.Collections.Generic;

namespace APE.Domain.Interface
{
    public interface IClienteRepository : IRepositoryBase<Guid, Cliente>
    {
        Cliente ObterPorId(Guid id);
        ICollection<Cliente> ListarComContato();
    }
}
