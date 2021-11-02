using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetById(int id);

        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IResult Add(Customer user);
        IResult Update(Customer user);
        IResult Delete(Customer user);
    }
}
