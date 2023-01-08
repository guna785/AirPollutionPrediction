using AirPollutionPrediction.Application.Interfaces.Serialization.Options;
using System.Text.Json;

namespace AirPollutionPrediction.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}
