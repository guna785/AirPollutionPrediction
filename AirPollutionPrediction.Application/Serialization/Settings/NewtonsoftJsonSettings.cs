using AirPollutionPrediction.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace AirPollutionPrediction.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}
