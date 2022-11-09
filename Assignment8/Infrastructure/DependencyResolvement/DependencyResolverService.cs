using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolvement;

public static class DependencyResolverService
{

    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
    }

}