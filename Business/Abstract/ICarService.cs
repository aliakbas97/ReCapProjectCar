using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();

        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        //bool UpdatedAuthority(Car car);

        List<Car> GetCarsByDailyPrice(decimal min, decimal max);

        void Add(Car car);


        void Update(Car car);
        void Delete(Car car);

      
    }
}
