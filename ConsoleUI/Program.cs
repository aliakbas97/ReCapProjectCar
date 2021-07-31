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
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { CarId = 6, BrandId = 5, ColorId = 3, DailyPrice = 600, ModelYear = 1998, Description = " 200000 km ,4 cylinder" });
            carManager.Update(new Car { CarId = 3, BrandId = 4, ColorId = 2, DailyPrice = 800, ModelYear = 2000, Description = " 250000 KM , 4 CYLİNDER " });

            foreach (var carr in carManager.GetAll())
            {
                Console.WriteLine(carr.CarId + " " + carr.BrandId + "  " + carr.ColorId + "  " + carr.DailyPrice + "  " + carr.ModelYear + "   " + carr.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + "  " + car.ColorId + "  " + car.DailyPrice + "  " + car.ModelYear + "   " + car.Description);
            }

            foreach (var car in carManager.GetCarsByDailyPrice(30,600))
            {
                Console.WriteLine(car.CarId + " " + car.BrandId + "  " + car.ColorId + "  " + car.DailyPrice + "  " + car.ModelYear + "   " + car.Description);
            }
        }
    }
}
