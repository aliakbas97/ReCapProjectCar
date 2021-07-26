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
            
                _carDal.Add(car);
            
            
           
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

        public List<Car> GetById(int BrandId)
        {
            return _carDal.GetById(BrandId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

       

        

        
    }
}
