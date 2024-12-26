using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Concrete;
using OtelRez.DAL.DbContexts;
using OtelRez.DAL.Repositories.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Extensions;

namespace OtelRez.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //builder.Services.AddSession();//TODO:Burasini nerede kullaniyorsunuz
            builder.Services.AddDistributedMemoryCache(); 

            #region DbContext Registiration
            var constr = builder.Configuration.GetConnectionString("OtelRez");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(constr));
            #endregion

            #region Notify Service Configuration
            builder.Services.AddNotyf(p =>
            {
                p.Position = NotyfPosition.BottomRight;
                p.DurationInSeconds = 7;
                p.IsDismissable = true;
            });
            #endregion

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "OtelRez";
                options.LoginPath = "/Hesap/Giris";
                options.LogoutPath = "/Hesap/Cikis";
                options.AccessDeniedPath = "/Hesap/ErisimHatasý";
                options.Cookie.HttpOnly = true; //Taray?c?daki di?er scriptler okuyamas?n diye güvenlik 
                options.Cookie.SameSite = SameSiteMode.Strict; //Ba?ka taray?c?lar taraf?ndan ula??lamas?n diye güvenlik önlemi
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10); //
                options.SlidingExpiration = true; //Herhangi sitede bir hareket oldu?unda süreyi 10 dk uzatýr

            });

            builder.Services.AddOtelService();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNotyf();
            app.UseRouting();
            //app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
