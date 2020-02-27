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
using Microsoft.AspNetCore.Authorization;
using business.WSUser.interfaces;
using business.WSTeacher;
using business.WSTeacher.HeadTeacher;
using business.WSAdmin;
using business.WSHR;

namespace CRMDevEducation.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token(string login, string password)
        {
            var identity = GetIndentity(login, password);
            IUserManager manager = CreateManager(identity);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Please make sure you've provided a valid login and password!" });
            }
            var nowTime = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: nowTime,
                claims: identity.Claims,
                expires: nowTime.AddMinutes(AuthOptions.LIFETIME),
                signingCredentials: new SigningCredentials(
                    AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            StorageToken.Add("Bearer " + encodedJwt, manager); 
            var respose = new { 
                access_token = encodedJwt,
                Id = identity.Claims.ToArray()[0].Value,
                Login = identity.Claims.ToArray()[1].Value,
                Role = identity.Claims.ToArray()[2].Value
            };
            return Json(respose); 
        }

        private IUserManager CreateManager(ClaimsIdentity identity)
        {
            if (identity == null) return null;
            IUserManager manager = null;
            if (identity.Claims.ToArray()[2].Value == "Admin") manager = new AdminManager();
            else if (identity.Claims.ToArray()[2].Value == "HR") manager = new HRManager(Convert.ToInt32(identity.Claims.ToArray()[0].Value));
            else if (identity.Claims.ToArray()[2].Value == "HeadHR") manager = new HeadHR(Convert.ToInt32(identity.Claims.ToArray()[0].Value));
            else if (identity.Claims.ToArray()[2].Value == "Teacher") manager = new NormalTeacherManager(Convert.ToInt32(identity.Claims.ToArray()[0].Value));
            else if (identity.Claims.ToArray()[2].Value == "HeadTeacher") manager = new MaxHeadTeacherManager(Convert.ToInt32(identity.Claims.ToArray()[0].Value));
 
            return manager;
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
                    new Claim("Id", Convert.ToString(user.Id)),
                    new Claim("Login", Convert.ToString(user.Login)),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
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