using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetailById(int id);

        IDataResult<List<CarDetailDto>> GetAllByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId);

        
        
        
        IResult TransactionalOperation(Car car);

    }
}
