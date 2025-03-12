using AirPollutionPrediction.Client.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Application.Responses.Identity;
using AirPollutionPrediction.Shared.Constants.Storage;
using AirPollutionPrediction.Shared.Wrapper;
using AirPollutionPrediction.UI.Infrastructure.Extensions;
using AirPollutionPrediction.UI.Infrastructure.Routes;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;

namespace AirPollutionPrediction.Client.Managers.Identity.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IStringLocalizer<AuthenticationManager> _localizer;
        private readonly ILocalStorageService _localStorage;
        public AuthenticationManager(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            IStringLocalizer<AuthenticationManager> localizer, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localizer = localizer;
            _localStorage=localStorage;
        }

        public async Task<ClaimsPrincipal> CurrentUser()
        {
            AuthenticationState state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return state.User;
        }

        public async Task<IResult> Login(TokenRequest model)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(TokenEndpoints.Get, model);
            IResult<TokenResponse> result = await response.ToResult<TokenResponse>();
            if (result.Succeeded)
            {
                string token = result.Data.Token;
                string refreshToken = result.Data.RefreshToken;
                string userImageURL = result.Data.UserImageURL;
                try
                {
                    await _localStorage.SetItemAsStringAsync(StorageConstants.Local.RefreshToken, refreshToken);
                    await _localStorage.SetItemAsStringAsync(StorageConstants.Local.AuthToken, token);
                }
                catch (Exception)
                {

                }

                if (!string.IsNullOrEmpty(userImageURL))
                {
                    //await SecureStorage.SetAsync(StorageConstants.Local.UserImageURL, userImageURL);
                }

                await ((AirPollutionAuthenticationStateProvider)_authenticationStateProvider).StateChangedAsync();

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return await Result.SuccessAsync();
            }
            else
            {
                return await Result.FailAsync(result.Messages);
            }
        }

        public async Task<IResult> Logout()
        {
             await  _localStorage.ClearAsync();
            ((AirPollutionAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            return await Result.SuccessAsync();
        }

        public async Task<string> RefreshToken()
        {
            string token = await _localStorage.GetItemAsStringAsync(StorageConstants.Local.AuthToken);
            string refreshToken = await _localStorage.GetItemAsStringAsync(StorageConstants.Local.RefreshToken);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(TokenEndpoints.Refresh, new RefreshTokenRequest { Token = token, RefreshToken = refreshToken });

            IResult<TokenResponse> result = await response.ToResult<TokenResponse>();

            if (!result.Succeeded)
            {
                throw new ApplicationException(_localizer["Something went wrong during the refresh token action"]);
            }

            token = result.Data.Token;
            refreshToken = result.Data.RefreshToken;
            await _localStorage.SetItemAsStringAsync(StorageConstants.Local.AuthToken, token);
            await _localStorage.SetItemAsStringAsync(StorageConstants.Local.RefreshToken, refreshToken);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
        }

        public async Task<string> TryRefreshToken()
        {
            //check if token exists
            string availableToken = await _localStorage.GetItemAsStringAsync(StorageConstants.Local.RefreshToken);
            if (string.IsNullOrEmpty(availableToken))
            {
                return string.Empty;
            }

            AuthenticationState authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            ClaimsPrincipal user = authState.User;
            string exp = user.FindFirst(c => c.Type.Equals("exp"))?.Value;
            DateTimeOffset expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
            DateTime timeUTC = DateTime.UtcNow;
            TimeSpan diff = expTime - timeUTC;
            return diff.TotalMinutes <= 1 ? await RefreshToken() : string.Empty;
        }

        public async Task<string> TryForceRefreshToken()
        {
            return await RefreshToken();
        }
    }
}
