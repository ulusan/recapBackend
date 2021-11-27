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
        //arabaları listele
        IDataResult<List<CarDetailDto>> GetAll();
        //arabaların id lerini getir
        IDataResult<Car> GetById(int carId);
        //araba ekle
        IResult Add(Car car);
        //araba güncelle
        IResult Update(Car car);
        //araba sil
        IResult Delete(Car car);

        IDataResult<CarDetailDto> GetDetailByCarId(int id);
        //markaların id sini getir
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        //renklerin id sini getir
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        //DailyPrice ı getir listele
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        //araba detaylarını listele
        IDataResult<List<CarDetailDto>> GetCarDetails();
        
        
        IResult TransactionalOperation(Car car);

    }
}
