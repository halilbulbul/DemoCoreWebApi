using Infrastructure.DataAccess;
using Infrastructure.Model.Abstract;
using Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Abstract
{
    public interface IBusinessBase<TEntity>
          where TEntity : IEntity, new()
    {
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, RepositoryParameters<TEntity> parameters = null);
        IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Remove(TEntity entity);
    }
}
