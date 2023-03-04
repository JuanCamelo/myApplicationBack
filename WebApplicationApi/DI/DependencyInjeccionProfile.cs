using ApplicationDomian.Models;
using ApplicationDomian.Repository;
using ApplicationDomian.Repository.Contact;
using ApplicationServices.Services;
using ApplicationServices.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationApi.DI
{
    public static class DependencyInjeccionProfile
    {
        public static IServiceCollection AddDependencyInjeccion(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));

            service.AddTransient<IUserApplicationServices, UserApplicationServices>();
            service.AddScoped(typeof(IApplicationDomainRepository<>), typeof(ApplicationDomainRepository<>));

            return service;
        }


        public static IServiceCollection AddServicesContext(this IServiceCollection service, IConfiguration configuration)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));

            service.AddDbContext<MyApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetSection("ConnectionStrings").Value));

            return service;
        }
    }
}
