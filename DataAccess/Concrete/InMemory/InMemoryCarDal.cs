using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            
            
            
            cars = new List<Car>
        {
            new Car  { CarId=1 , BrandId =1 , ColorId =1 , DailyPrice =500 , ModelYear = 1990, Description =" Hundai , Kırmızı, 1990 model , FİYAT =500" },
            new Car { CarId=2 , BrandId=1 , ColorId=1 , DailyPrice= 600 , ModelYear = 1995 , Description = "Hundai , Kırmızı 1995 model , FİYAT= 600" },
            new Car { CarId = 3 , BrandId=1 , ColorId =2 , DailyPrice =450, ModelYear =1992, Description = "Hundai , Yeşil 1992 model  , FİYAT= 450"},
            new Car {CarId=4, BrandId=2, ColorId=1, DailyPrice = 650 , ModelYear = 1996, Description =" Ford , Kırmızı 1996 model  , FİYAT= 650" },
            new Car {CarId=5, BrandId=2, ColorId=3, DailyPrice =700, ModelYear=2000, Description ="Ford, Mavi  2000 model   , FİYAT= 700"},
            new Car {CarId=6, BrandId =3, ColorId=1 , DailyPrice=650 , ModelYear =1990, Description =" Bmw, Kırmızı  1990 model   , FİYAT= 650"},
            new Car{CarId=7 , BrandId=3, ColorId=2 , DailyPrice= 750, ModelYear=2005, Description ="Bmw, Yeşil, 2005 model  ,  , FİYAT= 750"}
           
        };

        }

        public void Add(Car car)
        {
            
            cars.Add(car);


        }

        public void Delete(Car car)
        {
            Car carDelete = cars.SingleOrDefault(c => c.CarId == car.CarId);
            cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int BrandId)
        {
            
            
                 return cars.Where(c => c.BrandId == BrandId).ToList();
                
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updateCar = cars.SingleOrDefault(c => c.CarId == car.CarId);
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.Description = car.Description;

            
        }
    }
}
