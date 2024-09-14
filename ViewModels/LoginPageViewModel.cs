using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyLoginApp.Services;
using MyLoginApp.Models;
using MyLoginApp.Views;
using Newtonsoft.Json;
using MyLoginApp.UserControl;

namespace MyLoginApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string? _userName;
        [ObservableProperty]
        public string? _password;

        readonly ILoginRepository loginRepository = new LoginService();

        [RelayCommand]
        public async Task Login()
        {
            if (string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(Password))
                return;

            UserInfo? userInfo = await loginRepository.Login(UserName!, Password!);

            if (userInfo == null) return;

            if (Preferences.ContainsKey(nameof(App.userInfo)))
                Preferences.Remove(nameof(App.userInfo));

            string userDetails = JsonConvert.SerializeObject(userInfo);
            Preferences.Set(nameof(App.userInfo), userDetails);

            App.userInfo = userInfo;

            Shell.Current.FlyoutHeader = new FlyoutHeaderControl();

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
