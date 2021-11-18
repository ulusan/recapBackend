using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from c in dbCarContext.Cars
                    join co in dbCarContext.Colors
                        on c.ColorId equals co.ColorId
                    join b in dbCarContext.Brands
                        on c.BrandId equals b.BrandId
                    join img in dbCarContext.CarImages
                        on c.CarId equals img.CarId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        ColorId = co.ColorId,
                        BrandId = b.BrandId,
                        CarName = c.CarName,
                        ColorName = co.ColorName,
                        BrandName = b.BrandName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        ImagePath = img.ImagePath,
                        Description = c.Description
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        
    }
}
