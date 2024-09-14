using MyLoginApp.Models;
using System.Net.Http.Json;

namespace MyLoginApp.Services;

public class LoginService : ILoginRepository
{
    const string serverAddress = "https://dummyjson.com/auth/login";

    public async Task<UserInfo?> Login(string _username, string _password)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var client = new HttpClient();
                JsonContent content = JsonContent.Create(new { username = _username, password = _password });
                using var response = await client.PostAsync(serverAddress, content);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<UserInfo>();
            }
            return null;
        }
        catch (Exception ex) 
        {
            throw ex.InnerException ?? new Exception();
        }
    }
}
