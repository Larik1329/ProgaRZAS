using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace kakoyzheyadebil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (login is not null)
            {
                if (login.Equals("admin", StringComparison.CurrentCultureIgnoreCase) && password.Equals("admin"))
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.Role,"Admin")};

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return Ok();
                }
                else if (login.Equals("user", StringComparison.CurrentCultureIgnoreCase) && password.Equals("user"))
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, login),
                    new Claim(ClaimTypes.Role,"User")};

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}