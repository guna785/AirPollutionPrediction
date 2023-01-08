using AirPollutionPrediction.Application.Interfaces.Serialization.Serializers;
using AirPollutionPrediction.Application.Serialization.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AirPollutionPrediction.Application.Serialization.Serializers
{
    public class SystemTextJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerOptions _options;

        public SystemTextJsonSerializer(IOptions<SystemTextJsonOptions> options)
        {
            _options = options.Value.JsonSerializerOptions;
        }

        public T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data, _options)!;
        }

        public string Serialize<T>(T data)
        {
            return JsonSerializer.Serialize(data, _options);
        }
    }
}
