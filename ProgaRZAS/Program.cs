using ProgaRZAS.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using kakoyzheyadebil.Domain;

namespace ProgaRZAS
{
    public class Program
    {
        public int pubid;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ÂàíappDbContext>();
            var app = builder.Build();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}