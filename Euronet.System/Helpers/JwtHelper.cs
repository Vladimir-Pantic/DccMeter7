using Euronet.System.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.System.Helpers
{
    public class JwtHelper
    {

        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtTokenAsync(string username)
        {

            var secretKey = Settings.Settings.Instance.JwtSettings.SecretKey;
            var issuer = Settings.Settings.Instance.JwtSettings.Issuer;
            var audience = Settings.Settings.Instance.JwtSettings.Audience;
            var expiryDuration = Settings.Settings.Instance.JwtSettings.ExpiryDurationMinutes;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiryDuration),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenDescriptor);

            return await Task.FromResult(token);

        }

        //public ClaimsPrincipal ValidateToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var secretKey = _configuration["JwtSettings:SecretKey"];
        //    var issuer = _configuration["JwtSettings:Issuer"];
        //    var audience = _configuration["JwtSettings:Audience"];
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        //    var validationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidIssuer = issuer,
        //        ValidAudience = audience,
        //        IssuerSigningKey = securityKey
        //    };

        //    try
        //    {
        //        var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
        //        return principal;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
