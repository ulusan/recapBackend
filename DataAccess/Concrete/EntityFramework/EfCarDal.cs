using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from c in dbCarContext.Cars
                    join co in dbCarContext.Colors
                    on c.ColorId equals co.ColorId
                    join b in dbCarContext.Brands
                    on c.BrandId equals b.BrandId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        Description = c.Description,
                        DailyPrice = c.DailyPrice,
                        ColorName = co.ColorName,
                    };
                return result.ToList();
            }
        }
    }
}
