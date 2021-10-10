using Core.Entity.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Extentions;
using System.Linq;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
       private   TokenOptions _tokenOptions;
        private DateTime _accesTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }



        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialHelper.CreateSigningCredential(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accesTokenExpiration
            };
                



        }
        public JwtSecurityToken  CreateJwtSecurityToken(TokenOptions tokenOptions , User user , SigningCredentials signingCredentials , List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(

                 issuer: tokenOptions.Issuer,
                  audience: tokenOptions.Audience,
                signingCredentials: signingCredentials,
               expires:_accesTokenExpiration,
               claims: SetClaims(user,operationClaims),
               notBefore: DateTime.Now

                ) ;

            return jwt;
        }
        public IEnumerable<Claim> SetClaims(User user , List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName  }  {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
