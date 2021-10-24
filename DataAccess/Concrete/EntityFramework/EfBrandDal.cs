using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal :IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                return filter == null
                    ? dbCarContext.Set<Brand>().ToList()
                    : dbCarContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Add(Brand entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var addedEntity = dbCarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbCarContext.SaveChanges();
            }
        }

        public void Update(Brand entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var updatedEntity = dbCarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbCarContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var deletedEntity = dbCarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbCarContext.SaveChanges();
            }
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                return dbCarContext.Set<Brand>().SingleOrDefault(filter);
            }
        }
    }
}
