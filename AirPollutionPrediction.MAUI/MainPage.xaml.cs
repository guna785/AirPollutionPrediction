using Microsoft.AspNetCore.Components.WebView.Maui;
using AirPollutionPrediction.Shared.Constants.Storage;
using Plugin.Fingerprint.Abstractions;

namespace AirPollutionPrediction.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage(IFingerprint fingerprint)
        {
            InitializeComponent();

        }


    }
}