using Business.Abstract;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using FluentValidation;
using Core.CrossCuttingConcern.Validation;
using Core.Aspect.Autofac.Validation;

namespace Business.Concrete
{
   public class CarManager : ICarService

    {
        
        ICarDal _carDal;

      
       

       

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

    

      

       



        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            
           


            _carDal.Add(car);
            return new SuccessfullResult(Messages.CarAdded);


        }

      
      

        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessfullResult(Messages.CarDeleted);
        }

       

      
        public IDataResult<List<Car>> GetAll()
        {
            // iş kodu giriliyor
            // yetkisi varsa ürünleri listeleyecez

            return new SuccessfullDataResult<List<Car>> (_carDal.GetAll(),Messages.CarGet);

        }

      

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessfullDataResult<List<CarDetailDto>> ( _carDal.GetCarDetails(), Messages.CarGetDetail);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessfullDataResult<List<Car>> ( _carDal.GetAll(p => p.BrandId == id), Messages.CarGetByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessfullDataResult<List<Car>> (_carDal.GetAll(p => p.ColorId == id),Messages.CarGetByColor);
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessfullDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max),Messages.CarGetByDailyPrice);
        }

       

      

        //public List<Car> GetById(int BrandId)
        //{
        //    return _carDal.GetById(BrandId);
        //}

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessfullResult(Messages.CarUpdated);
        }

        

      
    }
}
