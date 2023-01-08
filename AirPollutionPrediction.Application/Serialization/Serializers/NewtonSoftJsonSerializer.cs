using AirPollutionPrediction.Application.Interfaces.Serialization.Serializers;
using AirPollutionPrediction.Application.Serialization.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AirPollutionPrediction.Application.Serialization.Serializers
{
    public class NewtonSoftJsonSerializer : IJsonSerializer
    {
        private readonly JsonSerializerSettings _settings;

        public NewtonSoftJsonSerializer(IOptions<NewtonsoftJsonSettings> settings)
        {
            _settings = settings.Value.JsonSerializerSettings;
        }

        public T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text, _settings)!;
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }
    }
}
