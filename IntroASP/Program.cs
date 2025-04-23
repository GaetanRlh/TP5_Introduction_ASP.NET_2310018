using IntroASP.DataAccessLayer;
using Microsoft.Extensions.FileProviders;

namespace IntroASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            DAL.ConnectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddControllersWithViews();


            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Reservation}/{action=Reservation}");

            app.Run();
        }
    }
}
