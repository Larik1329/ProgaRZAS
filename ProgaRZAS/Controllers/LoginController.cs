using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgaRZAS.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;

namespace ProgaRZAS.Controllers
{
    [Route("Account/[action]")]
    public class LoginController : Controller
    {
        [HttpGet(Name = "Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (login is not null && password is not null)
            {
                if (login.Equals("admin", StringComparison.CurrentCultureIgnoreCase) && password.Equals("admin"))
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.Role,"Admin")};

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                }
                else if (login.Equals("user", StringComparison.CurrentCultureIgnoreCase) && password.Equals("user"))
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.Role,"User")};

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                }

                var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
                if (returnUrl.IsNullOrEmpty())
                {
                    returnUrl = "/Personel/Index";
                }

                return Redirect(returnUrl);
            }
            ViewData["Error"] = "Ошибка, неверные креды";
            return View();
        }

        [HttpGet(Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet(Name = "AccessDenied")]
        public IActionResult AccessDenied()
        {
            var returnUrl = "/Personel/Index";

            ViewData["Return"] = returnUrl;
            return View();
        }
    }
}