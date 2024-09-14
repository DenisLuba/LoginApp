using CommunityToolkit.Mvvm.Input;
using MyLoginApp.Models;
using MyLoginApp.Views;
using System.Collections.ObjectModel;

namespace MyLoginApp.ViewModels;

public partial class ProductPageViewModel : BaseProductViewModel
{
    public ObservableCollection<ProductInfo> productList { get; }

    public ProductPageViewModel(INavigation navigation)
    {
        productList = new ObservableCollection<ProductInfo>();
        Navigation = navigation;
    }

    [RelayCommand]
    async Task AddProduct()
    {
        await Shell.Current.GoToAsync(nameof(AddProductPage));
    }

    public void OnAppearing()
    {
        IsBusy = true;
    }

    [RelayCommand]
    async Task LoadProduct()
    {
        IsBusy = true;

        try
        {
            productList.Clear();
            if (App.ProductService is null) return;
            var prodList = await App.ProductService.GetProductsAsync();
            foreach (var item in prodList)
            {
                productList.Add(item);
            }
        }
        catch (Exception)
        {

        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task ProductTappedDelete(ProductInfo? productInfo)
    {
        if (productInfo is null || App.ProductService is null) return;

        await App.ProductService.DeleteProductAsync(productInfo.ProductId);
        await LoadProduct();
        OnAppearing();
    }

    [RelayCommand]
    async Task ProductTappedEdit(ProductInfo? productInfo)
    {
        if (productInfo is null || App.ProductService is null || Navigation is null) return;

        await Navigation.PushAsync(new AddProductPage(productInfo));
    }
}
