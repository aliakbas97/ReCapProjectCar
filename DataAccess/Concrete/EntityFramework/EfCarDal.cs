using Core.DataAccess.Entity;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext carContext= new RentCarContext())
            {
                var result = from ca in carContext.Cars
                             join br in carContext.Brands
                             on ca.BrandId equals br.BrandId
                             join co in carContext.Colors
                             on ca.ColorId equals co.ColorId
                             select new CarDetailDto { CarName = ca.CarName, BrandName = br.BrandName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice };
                return result.ToList();
            }
        }
    }
}
