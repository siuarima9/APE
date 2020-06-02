using APE.Domain.Interface;
using APE.Domain.Models;
using APE.Infra.Context;

namespace APE.Infra.Repositories
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        private readonly ApeContext _context;

        public ContatoRepository(ApeContext context) : base(context)
        {
            _context = context;
        }
    }
}
