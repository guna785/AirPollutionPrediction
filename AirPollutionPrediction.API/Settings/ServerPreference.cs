using AirPollutionPrediction.Shared.Constants.Localization;
using AirPollutionPrediction.Shared.Settings;

namespace AirPollutionPrediction.API.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}
