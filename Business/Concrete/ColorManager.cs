using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Business.ValidationRools.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Color>>(ColorMessages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), ColorMessages.ColorListed);
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Color color)
        {
            _colorDal.Update(color);
            _colorDal.Add(color);
            return new SuccessResult(ColorMessages.ColorUpdate);

        }
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(co=>co.ColorId==colorId));
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            
            _colorDal.Add(color);
            return new SuccessResult(ColorMessages.ColorAdded);
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(ColorMessages.ColorUpdate);
        }
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(ColorMessages.ColorDeleted);
        }
        private IResult CheckIfColorNameExist(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
