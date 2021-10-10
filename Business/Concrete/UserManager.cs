using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Core.Entity.Concrete;
using DataAccess.Abstract;

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

        public IDataResult<User> GetByMail(string email)
        {
           return new SuccessfullDataResult<User>(_userDal.Get( u => u.Email == email),Messages.UserMailFound);

        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessfullDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.UserDetailsListed);
        }


        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessfullResult(Messages.UserUpdated);
        }


    }
}
