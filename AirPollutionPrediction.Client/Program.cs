using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AirPollutionPrediction.Client;
using AirPollutionPrediction.Client.Managers.Preferences;
using AirPollutionPrediction.Shared.Constants.Localization;
using AirPollutionPrediction.UI.Infrastructure.Settings;
using System.Globalization;
using AirPollutionPrediction.Client.Extensions;

var builder = WebAssemblyHostBuilder
                         .CreateDefault(args)
                         .AddRootComponents()
                         .AddClientServices();
var host = builder.Build();
var storageService = host.Services.GetRequiredService<ClientPreferenceManager>();
if (storageService != null)
{
    CultureInfo culture;
    var preference = await storageService.GetPreference() as ClientPreference;
    if (preference != null)
        culture = new CultureInfo(preference.LanguageCode);
    else
        culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US");
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}

await builder.Build().RunAsync();
