using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using business;
using business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CRMDevEducation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token(string login, string password)
        {
            StorageToken storage = new StorageToken();
            var identity = GetIndentity(login, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Ты дурак" });
            }
            var nowTime = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: nowTime,
                claims: identity.Claims,
                expires: nowTime.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(
                    AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            storage.Add(jwt);
            var respose = new { accass_token = encodedJwt, role = identity.Name };
            return Json(respose);
        }

      
        private ClaimsIdentity GetIndentity(string login, string password)
        {
            User user = Identifier.Check(login, password);

            if (user == null)
                return null;
            else
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claim,
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType
                    );
                return claimsIdentity;
            }
        }
    }
}