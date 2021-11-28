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
        //Müşteri ekle
        IResult Add(Customer customer);
        //Müşteri güncelle
        IResult Update(Customer customer);
        //Müşteri sil
        IResult Delete(Customer customer);
        //Müşterileri listele
        IDataResult<List<Customer>> GetAll();
        //Müşterilerin id sini listele
        IDataResult<List<Customer>> GetById(int id);
        //Kullanıcı Kimliğine Göre Müşteri Alın
        
        IResult TransactionalOperation(Customer customer);
    }
}
