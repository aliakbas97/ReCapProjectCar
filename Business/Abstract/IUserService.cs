using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Core.Entity.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);

        IResult Add(User user);

        IDataResult<User> GetByMail(string email);
        IResult Update(User user);
        IResult Delete(User user);



    }
}
