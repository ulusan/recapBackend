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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        //Tümünü getir
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),BrandMessages.BrandListed);
        }
        //İşlemsel Operasyon
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Brand brand)
        {
            _brandDal.Update(brand);
            _brandDal.Add(brand);
            return new SuccessResult(BrandMessages.BrandUpdate);

        }
        //Markaların Id sini getir
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == brandId));
        }
        //Marka ekle
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            
            _brandDal.Add(brand);
            return new SuccessResult(BrandMessages.BrandAdded); ;
        }
        //Marka sil
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(BrandMessages.BrandDeleted);
        }
        //markayı güncelle
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(BrandMessages.BrandUpdate);
        }


        //Marka Adının Var Olup Olmadığını Kontrol Edin
        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result == true)
            {
                return new ErrorResult(BrandMessages.SameNameExist);
            }
            return new SuccessResult();
        }
        //Marka Varlığını Kontrol Edin
        private IResult CheckBrandExist(int brandId)
        {
            var result = _brandDal.GetAll(b => b.BrandId == brandId).Any();
            if (!result)
            {
                return new ErrorResult("marka bulunamadı.");
            }
            return new SuccessResult();
        }
    }
}
