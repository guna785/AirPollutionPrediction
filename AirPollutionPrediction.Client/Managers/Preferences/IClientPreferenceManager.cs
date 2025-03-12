using MudBlazor;
using AirPollutionPrediction.Shared.Managers;

namespace AirPollutionPrediction.Client.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();
    }
}
