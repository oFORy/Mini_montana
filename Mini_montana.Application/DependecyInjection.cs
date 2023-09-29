using Microsoft.Extensions.DependencyInjection;
using Mini_montana.Application.Services.Alldata.Commands;
using Mini_montana.Application.Services.Alldata.Queries;

namespace Mini_montana.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddScoped<IAlldataQueryService, AlldataQueryService>()
                .AddScoped<IAlldataCommandService, AlldataCommandService>()
                ;
            return services;
        }
    }
}
