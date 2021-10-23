using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,CategoryId=1,DailyPrice=400,ModelYear=2015,Description="BMW-SUV"},
                new Car{Id=2,BrandId=2,CategoryId=2,DailyPrice=350,ModelYear=2016,Description="Mercedes-Sedan"},
                new Car{Id=3,BrandId=3,CategoryId=1,DailyPrice=290,ModelYear=2019,Description="Renault-SUV"},
                new Car{Id=4,BrandId=4,CategoryId=1,DailyPrice=170,ModelYear=2011,Description="Dacia-SUV"},
                new Car{Id=5,BrandId=5,CategoryId=2,DailyPrice=150,ModelYear=2009,Description="Nissan-Sedan"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
