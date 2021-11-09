using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Business.ValidationRools.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
         IRentalDal _rentalDal;

         public RentalManager(IRentalDal rentalDal)
         {
             _rentalDal = rentalDal;
         }

         public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),RentalMessages.RentalListed);
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.RentalId==id));
        }

        public IResult ChechReturnDate(int carId)
        {
            var result = _rentalDal.GetCarRentalDetails();
            if (result.Count > 0)
            {
                return new ErrorResult(RentalMessages.RentalAddFailed);
            }
            return new SuccessResult(RentalMessages.RentalAdded);
        }

        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(p => p.RentalId == rental.RentalId);
            var updateRental = result.LastOrDefault();

            if (updateRental != null)
            {
                return new ErrorResult(RentalMessages.RentalUpdateFailed);
            }

            updateRental.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updateRental);
            return new SuccessResult(RentalMessages.RentalUpdated);
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails(), RentalMessages.RentalListed);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = ChechReturnDate(rental.CarId);
            if (!result.Success && rental.ReturnDate < rental.RentDate)
            {
                return new ErrorResult(RentalMessages.RentalAddFailed);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentalId! > 0)
            {
                return new ErrorResult(RentalMessages.RentalUpdateFailed);
            }

            _rentalDal.Update(rental);
            return new SuccessResult(RentalMessages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId < 1)
            {
                return new ErrorResult(RentalMessages.RentalDeleteFailed);
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(RentalMessages.RentalDeleted);
        }
    }
}
