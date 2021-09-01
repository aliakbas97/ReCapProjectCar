using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Core.Utilities.Business;
using Core.Utilities.FileHelper.FileUpload;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Delete(CarImage carImage)
        {
            try
            {
                var imageDelete = _carImageDal.Get(c => c.CarId == carImage.CarId);
                if(imageDelete==null)
                {
                    return new ErrorResult(Messages.CarImageNotFound);
                }
                _carImageDal.Delete(carImage);
                return new SuccessfullResult();

            }
            catch (Exception)
            {

                return new ErrorResult("resim silinemedi");
            }
            
        }

        public IDataResult<List<CarImage>> Getall()
        {

            return new SuccessfullDataResult<List<CarImage>>(_carImageDal.GetAll());


        }

        //public IDataResult<List<CarImage>> GetCarImageByBrandId(int BrandId)
        //{
        //    return new SuccessfullDataResult<List<CarImage>>(_carImageDal.Get(br => br.));
        //}

        public IDataResult<List<CarImage>> GetCarImagebyCarId(int carId)
        {
            return new SuccessfullDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId ==carId));
            
        }

        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            try
            {
                var ImageUpdate = _carImageDal.Get(c=>c.CarId == carImage.CarId);
                if(ImageUpdate==null)
                {
                    return new ErrorResult(Messages.CarImageNotFound);
                }
                var updateFile = _fileHelper.Update(formFile, carImage.ImagePath);
                if(!updateFile.Success)
                {
                    return new ErrorResult(Messages.CarImageNotUpdated);
                }
                carImage.ImagePath = updateFile.Message;
                _carImageDal.Update(carImage);


                return new SuccessfullResult(Messages.CarUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarImageNotUpdated);
            }
            

        }

        public IResult Upload(CarImage carImage, IFormFile formFile)
        {
            var controlBusiness = BusinessRules.Run(ImageLimitedForCars(carImage.CarId));
            if(controlBusiness!=null)
            {
                return new ErrorResult(Messages.CarImageNotAdd);
            }

            var imageUpload = _fileHelper.Upload(formFile);

            carImage.ImagePath = imageUpload.Message;
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessfullResult(Messages.CarImageAdded);









        }

        private IResult ImageLimitedForCars(int IdCar)
        {
            var imageCount = _carImageDal.GetAll(c=>c.CarId ==IdCar);
            if(imageCount.Count >5)
            {
                return new ErrorResult(Messages.CarImageOverLimit);
            }
            return new SuccessfullResult();


        }



    }
}
