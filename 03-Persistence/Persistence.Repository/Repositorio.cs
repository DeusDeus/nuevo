using Common.IdentidadPersonalizada;
using Persistence.DatabaseContext;
using Persistence.DbContextScope;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repository
{
    // retorna asqueryable para evitar que se ejecute la consulta 
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        public Repository(IAmbientDbContextLocator context)
        {
            _ambientDbContextLocator = context;
        }

        private ApplicationDbContext DbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<ApplicationDbContext>();

                if (dbContext == null)
                {
                    throw new InvalidOperationException("No hay ambiente DbContext del tipo UserManagementDbContext encontrado. Esto significa que este método de repositorio se ha llamado fuera del ámbito de un DbContextScope.");
                }

                return dbContext;
            }
        }

        private IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties,
                                                       IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<T> Members
        public IQueryable<T> AsQueryable()
        {
            return DbContext.Set<T>().AsQueryable();
        }
        // 
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        } 
        //un valor busado
        public T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.SingleOrDefault(where);
        }
        //el primer valor encontrado
        public T First(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public void Delete(T entity)
        {
            if (entity is ISoftDeleted)
            {
                ((ISoftDeleted)entity).Deleted = true;

                DbContext.Set<T>().Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                DbContext.Set<T>().Remove(entity);
            }
        }

        public void Insert(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                DbContext.Entry(e).State = EntityState.Added;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                DbContext.Entry(e).State = EntityState.Modified;
            }
        }
        #endregion

        #region SQL Queries
        public virtual IQueryable<T> SelectQuery(string query, params object[] Parametros)
        {
            return DbContext.Set<T>().SqlQuery(query, Parametros).AsQueryable();
        }
       
        public virtual int ExecuteSqlCommand(string query, params object[] Parametros)
        {
            return DbContext.Database.ExecuteSqlCommand(query, Parametros);
        }

        public IQueryable<I> ExecuteSqlCommand<I>(string query, params object[] Parametros) where I : class
        {
            return DbContext.Database.SqlQuery<I>(query, Parametros).AsQueryable();
        }
        #endregion
    }
}