using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Logging;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DbCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (DbCarContext dbCarContext = new DbCarContext())
            {
                var result =
                    from customer in dbCarContext.Customers
                    join user in dbCarContext.Users
                        on customer.UserId equals user.UserId
                    select new CustomerDetailDto()
                    {
                        UserId = user.UserId,
                        UserFirstName = user.FirstName,
                        UserLastName = user.LastName,

                        CompanyName = customer.CompanyName,
                        CustomerId = customer.CustomerId
                    };
                return result.ToList();
            }
        }

        
    }
}
