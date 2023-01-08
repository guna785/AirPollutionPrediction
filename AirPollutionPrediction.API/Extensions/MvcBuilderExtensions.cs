using FluentValidation.AspNetCore;
using AirPollutionPrediction.Application.Configurations;

namespace AirPollutionPrediction.API.Extensions
{
    internal static class MvcBuilderExtensions
    {
        internal static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            _ = builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppConfiguration>());
            return builder;
        }


    }
}
