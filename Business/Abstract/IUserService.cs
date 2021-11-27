using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetByMail(string email);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int id);
        IDataResult<List<OperationClaim>> GetUserClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsById(int userId);

        IResult TransactionalOperation(User user);

        
        
    }
}
