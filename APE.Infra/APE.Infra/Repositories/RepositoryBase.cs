using APE.Domain.Interface;
using APE.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APE.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<Guid, TEntity> where TEntity : class
    {
        private readonly ApeContext _context;

        public RepositoryBase(ApeContext context)
        {
            _context = context;
        }
        
        public virtual ICollection<TEntity> Listar()
        {
            return  _context.Set<TEntity>().ToList();
        }

        public virtual ICollection<TEntity> Listar(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual void Alterar(TEntity entity)
        {
            _context.Update(entity);
        }

        public virtual void Inserir(TEntity entity)
        {
            _context.Add(entity);
        }

        public virtual TEntity Deletar(TEntity entity)
        {
            return _context.Remove(entity).Entity;
        }

        public virtual int Salvar()
        {
            return _context.SaveChanges();
        }
    }
}
