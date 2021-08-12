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

namespace Business.Concrete
{
   public class CarManager : ICarService

    {
        
        ICarDal _carDal;

        IUserDal _userDal;

        IRentalDal _rentalDal;

        ICustomerDal _customerDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public CarManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public CarManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public CarManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Car car)
        {

            if (car.Description.Length<=2 && car.DailyPrice < 0)
                {

                return new ErrorResult(Messages.CarAddedInvalid);
                
             
                 }

           
            _carDal.Add(car);
            return new SuccessfullResult(Messages.CarAdded);


        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessfullResult(Messages.UserAdded);
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessfullResult(Messages.CustomerAdded);
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == default)
            {
                return new ErrorResult(Messages.RentalCarFail);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessfullResult(Messages.RentalCarSuccess);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessfullResult(Messages.CarDeleted);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessfullResult(Messages.UserDeleted);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessfullResult(Messages.CustomerDeleted);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessfullResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            // iş kodu giriliyor
            // yetkisi varsa ürünleri listeleyecez

            return new SuccessfullDataResult<List<Car>> (_carDal.GetAll(),Messages.CarGet);

        }

        public IDataResult<List<Rental>> GetAllRentalCar()
        {
            return new SuccessfullDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalCarListed);
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

        public IDataResult<List<Customer>> GetCustomerByUserId(int id)
        {
            return new SuccessfullDataResult<List<Customer>>(_customerDal.GetAll(p => p.UserId == id), Messages.CustomerGet);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessfullDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UserDetailsListed);
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

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessfullResult(Messages.UserUpdated);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessfullResult(Messages.CustomerUpdated);

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessfullResult(Messages.RentalCarUpdated);
        }
    }
}
