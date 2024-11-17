using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService localStorageService;
    private readonly HttpClient http;
    private bool isInitialized = false;
    private bool isPrerendering = true; // Flag to handle prerendering state

    public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient http)
    {
        this.localStorageService = localStorageService;
        this.http = http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Nếu chưa khởi tạo hoặc đang prerendering, trả về một AuthenticationState mặc định
        if (!isInitialized || isPrerendering)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        string authToken = await localStorageService.GetItemAsStringAsync("authToken");
        var identity = new ClaimsIdentity();
        http.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty(authToken))
        {
            identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
        }

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public void NotifyPrerenderCompleted()
    {
        isPrerendering = false;
    }

    public void InitializeAuthenticationStateAsync()
    {
        isInitialized = true;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }
}
