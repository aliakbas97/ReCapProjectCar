using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class AuthsController:ControllerBase
    {
        IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("userlogin")]
        public IActionResult LoginUser(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if(!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var resultCreateToken = _authService.CreateAccessToken(userToLogin.Data);
            if(resultCreateToken.Success)
            {
                return Ok(resultCreateToken.Data);
            }
            
            return BadRequest(resultCreateToken.Message);
        }

        [HttpPost("userregister")]
        public IActionResult RegisterUser(UserForRegisterDto userForRegisterDto )
        {
            var userToExist = _authService.UserExist(userForRegisterDto.Email);
            if(userToExist.Success)
            {
                return BadRequest(userToExist.Message);
            }
            var registerToUser = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var resultAccessToken = _authService.CreateAccessToken(registerToUser.Data);
            if(resultAccessToken.Success)
            {
                return Ok(resultAccessToken);
            }
            return BadRequest(resultAccessToken.Message);



           


        }
    }
}
