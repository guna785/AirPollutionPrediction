using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using AirPollutionPrediction.Shared.Constants.Application;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AirPollutionPrediction.MAUI.Extensions
{
    public static class HubExtensions
    {
        public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager)
        {

            /* Unmerged change from project 'AirPollutionPrediction.MAUI (net6.0-maccatalyst)'
            Before:
                        if (hubConnection == null)
                        {
                            hubConnection = new HubConnectionBuilder()
            After:
                        hubConnection ??= new HubConnectionBuilder()
            */

            /* Unmerged change from project 'AirPollutionPrediction.MAUI (net6.0-ios)'
            Before:
                        if (hubConnection == null)
                        {
                            hubConnection = new HubConnectionBuilder()
            After:
                        hubConnection ??= new HubConnectionBuilder()
            */

            /* Unmerged change from project 'AirPollutionPrediction.MAUI (net6.0-windows10.0.19041.0)'
            Before:
                        if (hubConnection == null)
                        {
                            hubConnection = new HubConnectionBuilder()
            After:
                        hubConnection ??= new HubConnectionBuilder()
            */
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("AirPollutionPrediction.MAUI.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();
            hubConnection ??= new HubConnectionBuilder()
                                  .WithUrl($"{config.GetSection("HostUrl").Value}{ApplicationConstants.SignalR.HubUrl}", options =>
                                  {
                                      options.AccessTokenProvider = async () => await SecureStorage.GetAsync("authToken");
                                  })
                                  .WithAutomaticReconnect()
                                  .Build();
            return hubConnection;
        }
        //public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager)
        //{
        //    if (hubConnection == null)
        //    {
        //        hubConnection = new HubConnectionBuilder()
        //                          .WithUrl(navigationManager.ToAbsoluteUri(ApplicationConstants.SignalR.HubUrl))
        //                          .Build();
        //    }
        //    return hubConnection;
        //}
    }
}
