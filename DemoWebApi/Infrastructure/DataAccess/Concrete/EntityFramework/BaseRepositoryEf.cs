using Infrastructure.DataAccess.Abstract;
using Infrastructure.Model.Abstract;
using Infrastructure.Model.Enums;
using Infrastructure.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Concrete.EntityFramework
{
    public class BaseRepositoryEf<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : IEntity, new()
        where TContext : DbContext, IDisposable, new()
    {
        public IResult Add(TEntity entity)
        {
            using (TContext ctx = new())
            {
                entity.CreatedDate = DateTime.Now;
                ctx.Set<TEntity>().Add(entity);
                if (ctx.SaveChanges() > 0)
                {
                    return new SuccessResult(message: "İşlem Başarılı");
                }
                else
                {
                    return new ErrorResult(message: "Hatalı İşlem!");
                }
            }
        }

        public IResult Delete(TEntity entity)
        {
            using (TContext ctx = new())
            {
                ctx.Set<TEntity>().Remove(entity);
                if (ctx.SaveChanges() > 0)
                {
                    return new SuccessResult(message: "İşlem Başarılı");
                }
                else
                {
                    return new ErrorResult(message: "Hatalı İşlem!");
                }
            }
        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            using (TContext ctx = new())
            {
                IQueryable<TEntity> _dbSet = ctx.Set<TEntity>().Where(x => x.State == true);

                if (includeList != null)
                {
                    foreach (var item in includeList)
                    {
                        _dbSet = _dbSet.Include(item);
                    }
                }
                return new SuccessDataResult<TEntity>(_dbSet.SingleOrDefault(filter));
            }
        }

        public IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter, RepositoryParameters<TEntity> parameters = null)
        {
            using (TContext ctx = new())
            {
                IQueryable<TEntity> _dbSet = ctx.Set<TEntity>().Where(x => x.State == true);

                if (parameters != null)
                {
                    if (parameters.filter != null)
                        _dbSet = _dbSet.Where(parameters.filter);

                    if (parameters.includeList != null)
                    {
                        foreach (var item in parameters.includeList)
                        {
                            _dbSet = _dbSet.Include(item);
                        }
                    }

                    if (parameters.skip != 0)
                        _dbSet = _dbSet.Skip(parameters.skip);

                    if (parameters.take != 0)
                        _dbSet = _dbSet.Take(parameters.take);

                    if (parameters.sortDirection != null)
                    {
                        switch (parameters.sortDirection)
                        {
                            case SortDirection.Ascending:
                                _dbSet = _dbSet.OrderBy(parameters.orderBy);
                                break;
                            case SortDirection.Descending:
                                _dbSet = _dbSet.OrderByDescending(parameters.orderBy);
                                break;
                            default:
                                break;
                        }
                    }

                }

                return new SuccessDataResult<List<TEntity>>(_dbSet.Where(filter).ToList());
            }
        }

        public IResult Remove(TEntity entity)
        {
            using (TContext ctx = new())
            {
                entity.State = false;
                entity.RemoveDate = DateTime.Now;
                ctx.Set<TEntity>().Update(entity);
                if (ctx.SaveChanges() > 0)
                {
                    return new SuccessResult(message: "İşlem Başarılı");
                }
                else
                {
                    return new ErrorResult(message: "Hatalı İşlem!");
                }
            }
        }

        public IResult Update(TEntity entity)
        {
            using (TContext ctx = new())
            {
                entity.UpdatedDate = DateTime.Now;
                ctx.Set<TEntity>().Update(entity);
                if (ctx.SaveChanges() > 0)
                {
                    return new SuccessResult(message: "İşlem Başarılı");
                }
                else
                {
                    return new ErrorResult(message: "Hatalı İşlem!");
                }
            }
        }
    }
}
