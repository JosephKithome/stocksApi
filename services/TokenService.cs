using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.services
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _config; // makes the appsettings.json configuration available in this context
        private readonly SymmetricSecurityKey _key; // the key associated with the token
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SigningKey"]));

        }

        public string createToken(AppUser appUser)
        {
           var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.Email, appUser.Email.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName),
            new Claim(JwtRegisteredClaimNames.UniqueName, appUser.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, appUser.FirstName),
            new Claim(JwtRegisteredClaimNames.Sub, appUser.Id.ToString()), // subject
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()), // issued at time
            new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds().ToString()), // expiration time
            new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()), // not before
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // unique token identifier

           };

           var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
           var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
           };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}