using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.IdentityModels;
using System;

namespace Stepre
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMvc().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddDbContext<AppDbContext>(
                    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                    {
                        builder.MigrationsAssembly("Stepre");
                    }));

            //builder.Services.AddIdentity<User, IdentityRole>(options =>
            //{
            //    options.Lockout.MaxFailedAccessAttempts = 2;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;

            //    options.User.RequireUniqueEmail = true;
            //}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }
}