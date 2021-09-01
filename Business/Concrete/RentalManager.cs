using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
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
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessfullResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAllRentalCar()
        {
            return new SuccessfullDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalCarListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessfullResult(Messages.RentalCarUpdated);
        }

    }




}
