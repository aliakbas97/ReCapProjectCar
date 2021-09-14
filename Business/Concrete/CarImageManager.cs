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
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }
        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(ImageFull(carImage));

            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult("İmage Error");
            }

            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessfullResult(Messages.CarImageAdded);

        }

       
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.CarId == carImage.CarId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            //FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessfullResult(Messages.CarImageDeleted);
        }

      
        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccessfullDataResult<CarImage>(_carImageDal.Get(c => c.CarId == Id));

        }
        public IDataResult<List<CarImage>> GetById(int Id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(Id));

            if (result != null)
            {
                return new SuccessfullDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == Id));
            }

            return new SuccessfullDataResult<List<CarImage>>(CheckIfCarImageNull(Id).Data);

        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessfullDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {

            if (carImage == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            var updateFile = FileHelper.Update(file, carImage.ImagePath);
            if (!updateFile.Success)
            {
                return new ErrorResult(updateFile.Message);
            }

            carImage.ImagePath = updateFile.Message;

            _carImageDal.Update(carImage);

            return new SuccessfullResult(Messages.CarImageUpdated);
        }


        private IResult ImageFull(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageOverLimit);
            }
            return new SuccessfullResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int Id)
        {
            string path = @"\images\logo.jpg";

            var result = _carImageDal.GetAll(c => c.CarId == Id).Any();
            if (!result)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = Id, ImageDate = DateTime.Now, ImagePath = path });
                return new SuccessfullDataResult<List<CarImage>>(carImage);
            }

            return new SuccessfullDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == Id).ToList());




        }

    }
}
