using BusinessLogic.Contracts;
using BusinessLogic.Helpers;
using BusinessLogic.Services;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.EntityModels;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace TasklySolution.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //config context
            builder.Services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("testConn"));
            });

            //mapper
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            //repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //servises
            builder.Services.AddScoped<UserManager<UserEntity>>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IPriorityService, PriorityService>();
            builder.Services.AddScoped<IQuotesService, QuotesService>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TaskDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tasks}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
