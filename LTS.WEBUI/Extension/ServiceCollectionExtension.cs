using lts.Data.Concrete.Context;
using lts.DTOS.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LTS.WEBUI.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection IdentityServerAyarlari(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<myDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("LTSIdentityDbContext")));


            services.AddIdentity<HesapUser, IdentityRole>().AddEntityFrameworkStores<myDataContext>().
            AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSTUÜVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });

            return services;
        }

        public static IServiceCollection CookieAyarlari(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "UyeCookie";
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(40);
            });

            return services;
        }
    }
}
