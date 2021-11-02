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
            CarManager carManager = new CarManager(new EfCarDal());
            //LocalGetCar(carManager);


            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //LocalBrandTest(brandManager);


            ColorManager colorManager = new ColorManager(new EfColorDal());
            //LocalColorTest(colorManager);


            UserManager userManager = new UserManager(new EfUserDal());
            LocalUserTest(userManager);


            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //LocalCustomerTest(customerManager);


            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //LocalRentalTest(rentalManager);



        }

        private static void LocalRentalTest(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalCarDetails();
            if (result.Success)
            {
                Console.WriteLine("-----Rental Cars-----");
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(
                        $"Rent Id:                      {rental.RentalId} \n" +
                        $"Customer Name:                {rental.CustomerFirstName} {rental.CustomerLastName}\n" +
                        $"Customer Company Name:        {rental.CompanyName}\n" +
                        $"Car Brand:                    {rental.BrandName}\n" +
                        $"Rent Date:                    {rental.RentDate} - {rental.ReturnDate} \n" +
                        $"---------------------"
                    );
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void LocalUserTest(UserManager userManager)
        {
            var result = userManager.GetAll();
            if (result.Success)
            {

                Console.WriteLine($"User Info: \n");
                foreach (var user1 in result.Data)
                {

                    Console.WriteLine(
                        $"User Id:                {user1.UserId} \n" +
                        $"User First Name:              {user1.FirstName} \n" +
                        $"User Last Name:              {user1.LastName} \n" +
                        $"User E-Mail:            {user1.Email}  \n" +
                        $"User Password:            {user1.PasswordSalt}  \n" +

                        $"--------------------------------");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void LocalCustomerTest(CustomerManager customerManager)
        {
            var result = customerManager.GetCustomerDetails();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine($"customer Info: \n" +
                        $"Customer Id:                      {customer.CustomerId} \n" +
                        $"Customer of company name:         {customer.CompanyName} \n" +
                        $"Customer of full name:            {customer.UserFirstName} {customer.UserLastName}\n" +
                        $"--------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void LocalColorTest(ColorManager colorManager)
        {
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine($"Color Info: \n" +
                        $"Color Id:         {color.ColorId} \n" +
                        $"Color Name:       {color.ColorName} \n" +
                        $"--------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void LocalBrandTest(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine($"Brand Info: \n" +
                        $"Brand Id:         {brand.BrandId} \n" +
                        $"Brand Name:       {brand.BrandName} \n" +
                        $"--------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void LocalGetCar(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine("-----------------Car Info-----------------\n");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(
                        $"" +
                        $"Car Id:           {car.CarId} \n" +
                        $"Brand Name:       {car.BrandName} \n" +
                        $"Color Name:       {car.ColorName} \n" +
                        $"Daily Price:      {car.DailyPrice} \n" +
                        $"Car Description:  {car.Description}\n" +
                        $"------------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}