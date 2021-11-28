using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;


namespace DataAccess.Abstract
{
    public interface ICarDal :IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        CarDetailDto GetCarDetailById(int id);
        List<CarDetailDto> GetAllByColorId(int colorId);
        List<CarDetailDto> GetAllByBrandId(int brandId);
    }
}

