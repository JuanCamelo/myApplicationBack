using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationServices.Automapper
{
    public static class DependencyInjeccionProfileMapper
    {
        public static IServiceCollection AddDependencyInjeccionMapper(this IServiceCollection service)
        {
            _ = service ?? throw new ArgumentNullException(nameof(service));
            return service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
