using CadFunc.Domain.Interfaces;
using CadFunc.Infra.Data.Context;
using CadFunc.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CadFunc.Application.Interfaces;
using CadFunc.Application.Services;
using CadFunc.Application.Mappings;

namespace CadFunc.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //registro dos repositorios
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //registro dos servicos
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
