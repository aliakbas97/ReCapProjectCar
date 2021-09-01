using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {

        IDataResult<List<Rental>> GetAllRentalCar();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

    }
}
