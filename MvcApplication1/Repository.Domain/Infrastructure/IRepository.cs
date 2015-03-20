using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Domain.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> List();

        IQueryable<TEntity> QueryByPage(Expression<Func<TEntity, bool>> FunWhere,
                                               Expression<Func<TEntity, string>> FunOrder,
                                    int PageSize, int PageIndex, out int recordsCount);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
       
        
    }
}
