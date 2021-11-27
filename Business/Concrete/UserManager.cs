using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
         IUserDal _userDal;

         public UserManager(IUserDal userDal)
         {
             _userDal = userDal;
         }

         public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),UserMessages.UserListed);
        }

        public IDataResult<List<User>> GetById(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.Id == id), UserMessages.UserListed);
        }

        public IDataResult<List<OperationClaim>> GetUserClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user)+"talepler listelendi");
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(User user)
        {
            _userDal.Update(user);
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserUpdate);

        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length<2)
            {
                return new ErrorResult(UserMessages.UserNameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UserUpdate);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(UserMessages.UserDeleted);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        public IDataResult<List<OperationClaim>> GetClaimsById(int userId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaimsByUserId(userId));
        }
    }
}
