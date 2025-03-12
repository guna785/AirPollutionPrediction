using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using AirPollutionPrediction.Shared.Constants.Application;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Blazored.LocalStorage;

namespace AirPollutionPrediction.Client.Extensions
{
    public static class HubExtensions
    {
        public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager,ILocalStorageService localStorage)
        {

            /* Unmerged change from project 'AirPollutionPrediction.Client (net6.0-maccatalyst)'
            Before:
                        if (hubConnection == null)
                        {
                            hubConnection = new HubConnectionBuilder()
            After:
                        hubConnection ??= new HubConnectionBuilder()
            */

            /* Unmerged change from project 'AirPollutionPrediction.Client (net6.0-ios)'
            Before:
                        if (hubConnection == null)
                        {
                            hubConnection = new HubConnectionBuilder()
            After:
                        hubConnection ??= new HubConnectionBuilder()
            */

            /* Unmerged change from project 'AirPollutionPrediction.Client (net6.0-windows10.0.19041.0)'
            Before:
                        if (hubConnection == null)
                        {
                            hubConnection = new HubConnectionBuilder()
            After:
                        hubConnection ??= new HubConnectionBuilder()
            */
            //var a = Assembly.GetExecutingAssembly();
            //using var stream = a.GetManifestResourceStream("AirPollutionPrediction.Client.appsettings.json");

            //var config = new ConfigurationBuilder()
              //          .AddJsonStream(stream)
                //        .Build();
            hubConnection ??= new HubConnectionBuilder()
                                  .WithUrl($"{"http://localhost:5172"}{ApplicationConstants.SignalR.HubUrl}", options =>
                                  {
                                      options.AccessTokenProvider = async () => await localStorage.GetItemAsStringAsync("authToken");
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
