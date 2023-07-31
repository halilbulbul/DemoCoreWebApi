using Infrastructure.Business.Abstract;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Abstract;
using Infrastructure.Model.Abstract;
using Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Concrete
{
    public class BusinessBase<TEntity> : IBusinessBase<TEntity>
        where TEntity : IEntity, new()
    {
        IEntityRepository<TEntity> _repo;
        public BusinessBase(IEntityRepository<TEntity> repo)
        {
            _repo = repo;
        }

        public IResult Add(TEntity entity)
        {
            return _repo.Add(entity);
        }

        public IResult Delete(TEntity entity)
        {
            return _repo.Delete(entity);
        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            return _repo.Get(filter, includeList);
        }

        public IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter, RepositoryParameters<TEntity> parameters = null)
        {
            return _repo.GetAll(filter, parameters);
        }

        public IResult Remove(TEntity entity)
        {
            return _repo.Update(entity);
        }

        public IResult Update(TEntity entity)
        {
            return _repo.Update(entity);
        }
    }
}
