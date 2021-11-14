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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DbCarContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails()
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from rental in dbCarContext.Rentals
                    join car in dbCarContext.Cars on rental.CarId equals car.CarId
                    join brand in dbCarContext.Brands on car.BrandId equals brand.BrandId
                    join color in dbCarContext.Colors on car.ColorId equals color.ColorId
                    join customer in dbCarContext.Customers on rental.CustomerId equals customer.CustomerId
                    join user in dbCarContext.Users on customer.UserId equals user.Id
                    select new CarRentalDetailDto()
                    {
                        RentalId = rental.RentalId,
                        CustomerId = customer.CustomerId,
                        CustomerFirstName = user.FirstName,
                        CustomerLastName = user.LastName,
                        CompanyName = customer.CompanyName,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
