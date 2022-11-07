using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GulaylarCase.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetSql(string sql);
    }
}
