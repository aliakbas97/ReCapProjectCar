using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // RentCarTest();
            // CarDetailsTest();
            //GetCustomerByUserIdTests();
            CarManager carManager = new CarManager(new EfRentalDal());

            Console.WriteLine( carManager.Add(new Rental { Id = 9, CarId = 2, CustomerId = 4, RentDate = new DateTime(2015, 06, 08), ReturnDate = new DateTime(2020,07,04 )}).Message);
            
            foreach (var rent in carManager.GetAllRentalCar().Data)
            {
               
                Console.WriteLine(rent.Id +  "  " + rent.CarId +  "   " + rent.CustomerId +"    " +rent.RentDate + "  " + rent.ReturnDate);
               
            }
        }

        private static void GetCustomerByUserIdTests()
        {
            CarManager carManager = new CarManager(new EfCustomerDal());

            carManager.Add(new Customer { UserId = 3, CompanyName = " ANADOLU HOLDİNG " });

            foreach (var customer in carManager.GetCustomerByUserId(3).Data)
            {
                Console.WriteLine(customer.UserId + "    " + customer.CompanyName);
                Console.WriteLine(carManager.GetCustomerByUserId(3).Message);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "  " + car.BrandName + "    " + car.ColorName + "    " + car.DailyPrice);
            }
        }

        private static void RentCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { CarId = 10, BrandId = 5, ColorId = 3, DailyPrice = 600, ModelYear = 1998, Description = "c" });
            carManager.Update(new Car { CarId = 3, BrandId = 4, ColorId = 2, DailyPrice = 800, ModelYear = 2000, Description = " 250000 KM , 4 CYLİNDER " });

            foreach (var carr in carManager.GetAll().Data)
            {
                Console.WriteLine(carr.CarId + " " + carr.BrandId + "  " + carr.ColorId + "  " + carr.DailyPrice + "  " + carr.ModelYear + "   " + carr.Description+ " "+carr.CarName);
            }

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + "  " + car.ColorId + "  " + car.DailyPrice + "  " + car.ModelYear + "   " + car.Description);
            }

            foreach (var car in carManager.GetCarsByDailyPrice(30, 600).Data)
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + "  " + car.ColorId + "  " + car.DailyPrice + "  " + car.ModelYear + "   " + car.Description);
            }
        }
    }
}
