using costumer.api.Application.Exceptions;
using costumer.api.Application.Identity;
using costumer.api.Infra.Data.Confuguration;
using costumer.api.Infra.Data.Repositories.Costumer;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Infra.Data.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

namespace costumer.api.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterData(services);
            RegisterExceptionHandler(services);
            AddServices(services);
        }

        public static void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<ICustomerRespository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterExceptionHandler(IServiceCollection services)
        {
            services.AddScoped<ExceptionNotificationHandler>();
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
