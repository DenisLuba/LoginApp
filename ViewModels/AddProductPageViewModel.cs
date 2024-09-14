using CommunityToolkit.Mvvm.Input;
using MyLoginApp.Models;

namespace MyLoginApp.ViewModels;

public partial class AddProductPageViewModel : BaseProductViewModel
{
    public AddProductPageViewModel()
    {
        ProductInfo = new ProductInfo();
    }

    [RelayCommand]
    public async Task SaveProduct()
    {
        ProductInfo? product = ProductInfo;
        if (product is not null && App.ProductService is not null)
            await App.ProductService.AddUpdateProductAsync(product);

        await Shell.Current.GoToAsync(".."); // назад
    }

    [RelayCommand]
    public async Task Cancel()
    {
        await Shell.Current.GoToAsync(".."); // назад
    }
}
