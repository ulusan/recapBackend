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
        //kiralama ekle
        IResult Add(Rental user);
        //kiralamayı güncelle
        IResult Update(Rental user);
        //kiralamayı sil
        IResult Delete(Rental user);
        //kiralamaları listele
        IDataResult<List<Rental>> GetAll();
        //kiralamaların id sini ver
        IDataResult<List<Rental>> GetById(int id);
        //Kiralık Araba Detaylarını Alın
        IDataResult<List<CarRentalDetailDto>> GetRentalCarDetails();
        //İade Tarihini Kontrol Edin
        IResult ChechReturnDate(int carId);
        //İade Tarihini Güncelle
        IResult UpdateReturnDate(Rental rental);

        IResult TransactionalOperation(Rental rental);

        
        

        
    }
}
