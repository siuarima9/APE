using System;
using System.Collections.Generic;
using System.Linq;
using APE.Domain.Interface;
using APE.Domain.Models;
using APE.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace APE.Infra.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly ApeContext _context;

        public ClienteRepository(ApeContext context) : base(context)
        {
            _context = context;
        }


        public Cliente ObterPorId(Guid id)
        {
            var cliente = _context.Set<Cliente>()
                .Where(x => x.Id == id)
                .Include(x => x.Contato)
                .FirstOrDefault();

            return cliente;
        }

        public ICollection<Cliente> ListarComContato()
        {
            return _context.Set<Cliente>().AsNoTracking()
                .Include(cliente => cliente.Contato)
                .ToList();
        }
    }
}
