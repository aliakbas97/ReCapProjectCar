using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<UserDetailDto>> GetUserDetails();

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);



    }
}
