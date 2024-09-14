using MyLoginApp.ViewModels;
using MyLoginApp.Views;

namespace MyLoginApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
        }
    }
}
