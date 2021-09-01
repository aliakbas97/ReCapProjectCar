using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {
        IDataResult<List<CarImage>> Getall();
        //IDataResult<List<CarImage>> GetCarImageByBrandId(int BrandId);
        IDataResult<List<CarImage>> GetCarImagebyCarId(int carId);
        IResult Upload(CarImage carImage, IFormFile formFile);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage, IFormFile formFile);
            




    }
}
