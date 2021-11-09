using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace TestUıiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brandy in brandManager.GetAll().Data)
            {
                Console.WriteLine(brandy.BrandName);
            }
        }

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));

        //    var result = carManager.GetCarDetails();
        //    if (result.Success)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.CarName + "/" + car.CarName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

        //}
    }
}