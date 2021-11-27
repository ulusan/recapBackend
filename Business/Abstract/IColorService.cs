using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        //renkleri listele
        IDataResult<List<Color>> GetAll();
        //renklerin id sini getir
        IDataResult<Color> GetById(int colorId);
        //renk ekle
        IResult Add(Color color);
        //renk güncelle
        IResult Update(Color color);
        //renk sil
        IResult Delete(Color color);

        IResult TransactionalOperation(Color color);
        
    }
}
