#region usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineCoding.Domain.BaseEntities;

#endregion

namespace OnlineCoding.IDal.IUnitOfWork
{
    public interface IGenericRepository<TEntity, in TKey> where TEntity : BaseEntity
    {
        #region Public Methods

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity FindById(TKey id);

        Task<TEntity> FindByIdAsync(TKey id);

        void Add(TEntity entityToAdd);
        void Update(TEntity entityToUpdate);
        void Delete(TKey id);

        #endregion
    }
}