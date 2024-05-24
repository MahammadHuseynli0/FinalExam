
using Exam.Business.Services.Abstracts;
using Exam.Business.Services.Concretes;
using Exam.Core.Models;
using Exam.Core.RepositoryAbstracts;
using Exam.Data.DAL;
using Exam.Data.RepositoryConcretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });
        builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.Password.RequireNonAlphanumeric = true;
        }


        ).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        builder.Services.AddScoped<IChefRepository, ChefRepository>();
        builder.Services.AddScoped<IChefService, ChefService>();






        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();


        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
      );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
