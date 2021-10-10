using Business.Abstract;
using Business.Constants;
using Core.DataAccess.Results;
using Core.DataAccess.Utilities.Results;
using Core.Entity.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }



        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var createToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessfullDataResult<AccessToken>(createToken, Messages.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            
            var checkForEmail = _userService.GetByMail(userForLoginDto.Email);
            if(checkForEmail==null)
            {
                return new ErrorDataResult<User>(Messages.userNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,  checkForEmail.Data.PasswordHash, checkForEmail.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.userWrongPassword);
            }
            return new SuccessfullDataResult<User>(checkForEmail.Data, Messages.UserMailFound);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true


            };
            _userService.Add(user);
            return new SuccessfullDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
          if(_userService.GetByMail(email)==null)
            {
                return new ErrorResult(Messages.userNotFound);
             }
            return new SuccessfullResult();

        }
    }
}
