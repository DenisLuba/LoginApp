using CommunityToolkit.Mvvm.Input;

namespace MyLoginApp.ViewModels;

public partial class AppShellViewModel : BaseViewModel
{
    [RelayCommand]
    async Task SignOut()
    {
        if (Preferences.ContainsKey(nameof(App.userInfo)))
            Preferences.Remove(nameof(App.userInfo));

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
