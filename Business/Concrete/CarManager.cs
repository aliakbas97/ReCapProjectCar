using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService

    {
        
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {

            if (car.Description.Length>=2 && car.DailyPrice > 0)
                {
                _carDal.Add(car);
                 }
            else
                {
                Console.WriteLine(" car does not added");
                    }
            
           
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            // iş kodu giriliyor
            // yetkisi varsa ürünleri listeleyecez

            return _carDal.GetAll();

        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        //public List<Car> GetById(int BrandId)
        //{
        //    return _carDal.GetById(BrandId);
        //}

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

       

        

        
    }
}
