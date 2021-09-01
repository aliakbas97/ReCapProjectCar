using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessfullResult(Messages.UserAdded);
        }



        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessfullResult(Messages.UserDeleted);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessfullDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(), Messages.UserDetailsListed);
        }


        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessfullResult(Messages.UserUpdated);
        }


    }
}
