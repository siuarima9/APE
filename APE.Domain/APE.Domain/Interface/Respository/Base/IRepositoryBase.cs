using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace APE.Domain.Interface
{
    public interface IRepositoryBase<TKey, TEntity>  
        where TKey : struct
        where TEntity : class
    {
        ICollection<TEntity> Listar();
        ICollection<TEntity> Listar(Expression<Func<TEntity, bool>> predicate);
        void Alterar(TEntity entity);
        void Inserir(TEntity entity);
        TEntity Deletar(TEntity entity);
        int Salvar();
    }
}
