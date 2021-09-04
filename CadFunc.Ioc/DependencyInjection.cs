using CadFunc.Domain.Interfaces;
using CadFunc.Infra.Data.Context;
using CadFunc.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CadFunc.Application.Interfaces;
using CadFunc.Application.Services;
using CadFunc.Application.Mappings;
using CadFunc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using CadFunc.Domain.Account;

namespace CadFunc.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //registro identiy
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //cookies
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            //registro 
            services.AddScoped<IAuthenticate, AutheticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //registro dos repositorios
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //registro dos servicos
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
