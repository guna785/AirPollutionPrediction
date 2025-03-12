using Microsoft.Extensions.Localization;
using MudBlazor;
using AirPollutionPrediction.Shared.Constants.Storage;
using AirPollutionPrediction.Shared.Settings;
using AirPollutionPrediction.Shared.Wrapper;
using AirPollutionPrediction.UI.Infrastructure.Settings;
using Blazored.LocalStorage;

namespace AirPollutionPrediction.Client.Managers.Preferences
{
    public class ClientPreferenceManager : IClientPreferenceManager
    {

        private readonly IStringLocalizer<ClientPreferenceManager> _localizer;
        private readonly ILocalStorageService _localStorage;
        public ClientPreferenceManager(
            IStringLocalizer<ClientPreferenceManager> localizer,ILocalStorageService localStorage)
        {
            _localizer = localizer;
            _localStorage = localStorage;
        }

        public async Task<bool> ToggleDarkModeAsync()
        {
            ClientPreference preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.IsDarkMode = !preference.IsDarkMode;
                await SetPreference(preference);
                return !preference.IsDarkMode;
            }

            return false;
        }
        public async Task<bool> ToggleLayoutDirection()
        {
            ClientPreference preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.IsRTL = !preference.IsRTL;
                await SetPreference(preference);
                return preference.IsRTL;
            }
            return false;
        }

        public async Task<IResult> ChangeLanguageAsync(string languageCode)
        {
            ClientPreference preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.LanguageCode = languageCode;
                await SetPreference(preference);
                return new Result
                {
                    Succeeded = true,
                    Messages = new List<string> { _localizer["Client Language has been changed"] }
                };
            }

            return new Result
            {
                Succeeded = false,
                Messages = new List<string> { _localizer["Failed to get client preferences"] }
            };
        }

        public async Task<MudTheme> GetCurrentThemeAsync()
        {
            ClientPreference preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                if (preference.IsDarkMode == true)
                {
                    return AirPollutionTheme.DefaultTheme;
                }
            }
            return AirPollutionTheme.DefaultTheme;
        }
        public async Task<bool> IsRTL()
        {
            ClientPreference preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                if (preference.IsDarkMode == true)
                {
                    return false;
                }
            }
            return preference.IsRTL;
        }

        public async Task<IPreference> GetPreference()
        {
            string pref = await _localStorage.GetItemAsStringAsync(StorageConstants.Local.Preference);
            if (!string.IsNullOrEmpty(pref))
            {
                ClientPreference obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ClientPreference>(pref);
                return obj;
            }
            else
            {
                return new ClientPreference();
            }
        }

        public async Task SetPreference(IPreference preference)
        {
            string obj = Newtonsoft.Json.JsonConvert.SerializeObject(preference as ClientPreference);

            await _localStorage.SetItemAsStringAsync(StorageConstants.Local.Preference, obj);
        }
    }
}
