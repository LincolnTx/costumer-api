using costumer.api.Application.Exceptions;
using costumer.api.Application.Identity;
using costumer.api.Application.RequestHandlers.CustomerHandlers;
using costumer.api.Application.RequestHandlers.CustumerHandlerContracts;
using costumer.api.Infra.Data.Confuguration;
using costumer.api.Infra.Data.Repositories;
using costumer.api.Infra.Data.Repositories.Costumer;
using costumer.api.Infra.Data.Repositories.Customer;
using costumer.api.Infra.Data.Repositories.User;
using costumer.api.Infra.SeedWork;
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
            RegisterHandlers(services);
        }

        public static void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<ICustomerRespository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterExceptionHandler(IServiceCollection services)
        {
            services.AddScoped<ExceptionNotificationHandler>();
        }

        public static void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<ICreateCustumerRequestHandler, CreateCustumerRequestHandler>();
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
