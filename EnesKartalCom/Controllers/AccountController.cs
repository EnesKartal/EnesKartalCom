using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EnesKartalCom.Data;
using EnesKartalCom.Helpers;
using EnesKartalCom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace EnesKartalCom.Controllers
{
    public class AccountController : BaseController
    {
        Config config;
        IHttpContextAccessor accessor;
        public AccountController(EKDbContext dbContext, Config config, IHttpContextAccessor accessor) : base(dbContext)
        {
            this.config = config;
            this.accessor = accessor;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            //if (Request.IsAuthenticated)
            //return Redirect("/");
            //else
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginInput input, string returnUrl)
        {
            try
            {

                var user = dbContext.AppUser.FirstOrDefault(s => s.IsActive && s.Email == input.Username);
                if (user == null)
                    throw new Exception("Kullanıcı Bulunamadı");

                if (!AccountHelper.VerifyHashedPassword(input.Password, user.Password, config.Secret))
                    throw new Exception("Girdiğiniz e-posta adresi veya parola hatalı");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(config.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.GivenName, $"{user.Firstname} {user.Lastname}")
                    }),
                    Expires = DateTime.UtcNow.AddDays(config.TokenExpireDay),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                user.LastLoginDate = DateTime.Now;
                user.LastLoginIp = accessor.HttpContext.Connection.RemoteIpAddress.ToString();

                dbContext.SaveChanges();

                var result = new
                {
                    Id = user.Id,
                    Name = user.Email,
                    GivenName = $"{user.Firstname} {user.Lastname}",
                    Token = user.Token
                };
                return Redirect(returnUrl);
            }
            catch (Exception ex)
            {
                ModelState.SetModelValue("Code", new ValueProviderResult("", CultureInfo.InvariantCulture));
                ModelState.AddModelError("", ex.Message);
                return View(input);
            }
        }
    }
}