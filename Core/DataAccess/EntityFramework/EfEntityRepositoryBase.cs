using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>
    where TEntity :class,IEntity,new()
    where TContext : DbContext ,new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext dbCarContext = new TContext())
            {
                return filter == null
                    ? dbCarContext.Set<TEntity>().ToList()
                    : dbCarContext.Set<TEntity>().Where(filter).ToList();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext northwindContext = new TContext())
            {
                return northwindContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext dbCarContext = new TContext())
            {
                var addedEntity = dbCarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbCarContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext dbCarContext = new TContext())
            {
                var updatedEntity = dbCarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbCarContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext dbCarContext = new TContext())
            {
                var deletedEntity = dbCarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbCarContext.SaveChanges();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext dbCarContext = new TContext())
            {
                return dbCarContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }
    }
}
