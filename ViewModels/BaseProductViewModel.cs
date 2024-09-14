using CommunityToolkit.Mvvm.ComponentModel;
using MyLoginApp.Models;

namespace MyLoginApp.ViewModels;

public partial class BaseProductViewModel : BaseViewModel
{
    [ObservableProperty]
    ProductInfo? _productInfo;

    public INavigation? Navigation { get; set; }
}
