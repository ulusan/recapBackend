using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int id);
        IResult Add(Rental user);
        IResult Update(Rental user);
        IResult Delete(Rental user);
        IDataResult<List<CarRentalDetailDto>> GetRentalCarDetails();

        IResult TransactionalOperation(Rental rental);

        IResult ChechReturnDate(int carId);
        IResult UpdateReturnDate(Rental rental);
        

        
    }
}
