#region usings

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineCoding.Domain.BaseEntities;
using OnlineCoding.IDal.IUnitOfWork;

#endregion

namespace OnlineCoding.Dal.UnitOfWork
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity
    {
        #region Constructors

        //Prepare the environment here
        private GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Public Methods

        public static IGenericRepository<TEntity, TKey> Create(DbContext context)
        {
            return new GenericRepository<TEntity, TKey>(context);
        }

        #endregion

        #region Private Functions

        private IQueryable<TEntity> QFind(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        #endregion

        #region Fields

        //Set the variables here
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Interface Implementation

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = QFind(filter, orderBy, includeProperties).ToList();
            return query;
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return QFind(filter, orderBy, includeProperties).ToListAsync();
        }

        public TEntity FindById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public Task<TEntity> FindByIdAsync(TKey id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Add(TEntity entityToAdd)
        {
            entityToAdd.TimeStamp = DateTime.Now;
            _dbSet.Add(entityToAdd);
        }

        public void Update(TEntity entityToUpdate)
        {
            entityToUpdate.TimeStamp = DateTime.Now;
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Delete(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        #endregion
    }
}