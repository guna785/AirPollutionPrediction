using AirPollutionPrediction.Infrastructure.Repositories;
using AirPollutionPrediction.Infrastructure.Services.Storage;
using AirPollutionPrediction.Infrastructure.Services.Storage.Provider;
using Microsoft.Extensions.DependencyInjection;
using AirPollutionPrediction.Application.Interfaces.Repositories;
using AirPollutionPrediction.Application.Interfaces.Serialization.Serializers;
using AirPollutionPrediction.Application.Interfaces.Services.Storage;
using AirPollutionPrediction.Application.Interfaces.Services.Storage.Provider;
using AirPollutionPrediction.Application.Serialization.JsonConverters;
using AirPollutionPrediction.Application.Serialization.Options;
using AirPollutionPrediction.Application.Serialization.Serializers;
using System.Reflection;

namespace AirPollutionPrediction.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void InfrastructureMappings(this IServiceCollection services)
        {
            _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
            .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))

                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }


        public static IServiceCollection AddServerStorage(this IServiceCollection services)
        {
            return AddServerStorage(services, null!);
        }

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions> configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                .AddScoped<IStorageProvider, ServerStorageProvider>()
                .AddScoped<IServerStorageService, ServerStorageService>()
                .AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                    {
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                    }
                });
        }
    }
}
