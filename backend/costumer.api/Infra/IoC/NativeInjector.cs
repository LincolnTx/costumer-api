using costumer.api.Application.Exceptions;
using costumer.api.Infra.Data.Repositories.Costumer;
using costumer.api.Infra.Data.Repositories.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace costumer.api.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterData(services);
            RegisterExceptionHandler(services);
        }

        public static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<ICustomerRespository, CustomerRepository>();
        }

        public static void RegisterExceptionHandler(IServiceCollection services)
        {
            services.AddScoped<ExceptionNotificationHandler>();
        }
    }
}
