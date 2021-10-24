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
    public class EfCarDal :ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                return filter == null
                    ? dbCarContext.Set<Car>().ToList()
                    : dbCarContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Add(Car entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var addedEntity = dbCarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbCarContext.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var updatedEntity = dbCarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbCarContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var deletedEntity = dbCarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbCarContext.SaveChanges();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                return dbCarContext.Set<Car>().SingleOrDefault(filter);
            }
        }
    }
}
