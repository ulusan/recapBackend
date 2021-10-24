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
    public class EfColorDal : IColorDal
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                return filter == null
                    ? dbCarContext.Set<Color>().ToList()
                    : dbCarContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Add(Color entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var addedEntity = dbCarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbCarContext.SaveChanges();
            }
        }

        public void Update(Color entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var updatedEntity = dbCarContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbCarContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var deletedEntity = dbCarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbCarContext.SaveChanges();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                return dbCarContext.Set<Color>().SingleOrDefault(filter);
            }
        }
    }
}
