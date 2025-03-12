using AirPollutionPrediction.Shared.Constants.Storage;
using Blazored.LocalStorage;
using System.Net;
using System.Net.Http.Headers;

namespace AirPollutionPrediction.Client.Authentication
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly ILocalStorageService SecureStorage;
        public AuthenticationHeaderHandler(ILocalStorageService _SecureStorage)
        {
            this.SecureStorage = _SecureStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            if (request.Headers.Authorization?.Scheme != "Bearer")
            {
                string savedToken = await SecureStorage.GetItemAsStringAsync(StorageConstants.Local.AuthToken);

                if (!string.IsNullOrWhiteSpace(savedToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

}
