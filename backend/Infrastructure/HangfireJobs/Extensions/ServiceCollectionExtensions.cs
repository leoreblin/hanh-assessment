using Hangfire;
using HangfireJobs.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireJobs.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHangfireJobs(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config =>
            config.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));

        services.AddHangfireServer();

        services.AddTransient<DogBreedsUpsertJob>();

        return services;
    }
}
