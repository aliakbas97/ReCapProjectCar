using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Customer>> GetCustomerByUserId(int id);
        IDataResult<List<Rental>> GetAllRentalCar();

        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<UserDetailDto>> GetUserDetails();
        


        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        //bool UpdatedAuthority(Car car);

        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);

        IResult Add(Car car);
        IResult Add(User user);
        IResult Add(Customer customer);
        IResult Add(Rental rental);



        IResult Update(Car car);
        IResult Update(User user);
        IResult Update(Customer customer);
        IResult Update(Rental rental);

        IResult Delete(Car car);
        IResult Delete(User user);
        IResult Delete(Customer customer);
        IResult Delete(Rental rental);

      
    }
}
