using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants.Messages;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
         ICustomerDal _customerDal;

         public CustomerManager(ICustomerDal customerDal)
         {
             _customerDal = customerDal;
         }

         public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),CustomerMessages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetById(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(cu=>cu.CustomerId == id));
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CustomerId > 0)
            {
                _customerDal.Update(customer);
                return new SuccessResult(CustomerMessages.CustomerUpdate);
            }
            return new ErrorResult(CustomerMessages.CustomerIdNotSpace);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(CustomerMessages.CustomerDeleted);
        }
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), CustomerMessages.CustomerListed);
        }
    }
}
