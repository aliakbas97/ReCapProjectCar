using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            InMemoryCarDal _ınMemoryCarDal = new InMemoryCarDal();
            foreach (var carr in carManager.GetAll())
            {
                Console.WriteLine(carr.CarId + "  " + carr.BrandId + "  " + carr.ColorId + "  " + carr.DailyPrice+ "  "+ carr.Description);
            }

            Console.WriteLine(" UPDATED CARID 1");

            _ınMemoryCarDal.Add(new Car { CarId = 8, BrandId = 7, ColorId = 4, ModelYear = 1999, DailyPrice = 3500, Description = " Mazda, Green, 1996 model , fiyat 10500" });

          _ınMemoryCarDal.Update(new Car { CarId = 1, BrandId = 5, ColorId = 4, ModelYear = 1996, DailyPrice = 9500, Description = " Mercedes, Green, 1996 model , fiyat 9500" });

            Console.WriteLine(" branId si 2 olan lar ");

            foreach (var carbrandID in _ınMemoryCarDal.GetById(2))
            {
                Console.WriteLine(carbrandID.CarId + "  " + carbrandID.BrandId + "  " + carbrandID.ColorId + "  " + carbrandID.DailyPrice + "  " + carbrandID.Description);
            } 


            Console.WriteLine(" CardId güncellendikten sonraki liste ");

            //foreach (var carUpdate in carManager.GetAll())
            //{
            //    Console.WriteLine(carUpdate.CarId+ " " + carUpdate.BrandId + " " +carUpdate.ColorId + " " + carUpdate.DailyPrice + " " +carUpdate.Description);
            //}

            foreach (var updatedCars in _ınMemoryCarDal.GetAll())
            {
                Console.WriteLine(updatedCars.CarId + "  " + updatedCars.BrandId + "  " + updatedCars.ColorId + "  " + updatedCars.DailyPrice + "  " + updatedCars.Description);
            }


            Console.WriteLine(" CarId = 3 olanı silinince tablo ");
            _ınMemoryCarDal.Delete(new Car { CarId = 3 });

            foreach (var cardelete in _ınMemoryCarDal.GetAll())
            {
                Console.WriteLine(cardelete.CarId + "  " + cardelete.BrandId + "  " + cardelete.ColorId + "  " + cardelete.DailyPrice + "  " + cardelete.Description);
            }
            Console.WriteLine(" yeni car eklendi carId = 9 ");
            carManager.YetkisiVarMı(true);
            carManager.Add(new Car { CarId = 9, BrandId = 6, ColorId = 6, ModelYear = 1994, DailyPrice = 13500, Description = " ferrari, blue, 1994 model , fiyat 13500" });

            foreach (var caradd in carManager.GetAll())
            {
                Console.WriteLine(caradd.CarId + "  " + caradd.BrandId + "  " + caradd.ColorId + "  " + caradd.DailyPrice + "  " + caradd.Description);
            }


            Console.WriteLine(" yeni araba eklenemedi denemesi ");
            carManager.YetkisiVarMı(false);
            carManager.Add(new Car { CarId = 10, BrandId = 9, ColorId = 6, ModelYear = 1984, DailyPrice = 17500, Description = " lambo, red, 1984 model , fiyat 17500" });

            foreach (var caradde in _ınMemoryCarDal.GetAll())
            {
                Console.WriteLine(caradde.CarId + "  " + caradde.BrandId + "  " + caradde.ColorId + "  " + caradde.DailyPrice + "  " + caradde.Description);
            }
        }
    }
}
