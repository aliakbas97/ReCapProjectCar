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
            if (YetkisiVarMı(true))
            {
                _carDal.Add(car);

            }
        }

        public List<Car> GetAll()
        {
            // iş kodu giriliyor
            // yetkisi varsa ürünleri listeleyecez

            return _carDal.GetAll();

        }

        
        public bool YetkisiVarMı(bool yetki)
        {
            if (yetki == true)
            {
                return true;
            }
            else
            {
                return false;
            }    
            
        }

        

        //public bool UpdatedAuthority(Car car)
        //{
        //    if(car.CarId==1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }    
        //}
    }
}
