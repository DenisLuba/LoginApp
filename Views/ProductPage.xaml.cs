using MyLoginApp.ViewModels;
using CommunityToolkit.Mvvm.Input;
namespace MyLoginApp.Views;

public partial class ProductPage : ContentPage
{
    ProductPageViewModel productPageViewModel;
	public ProductPage()
	{
		InitializeComponent();
        BindingContext =  productPageViewModel = new ProductPageViewModel(Navigation);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        productPageViewModel.OnAppearing();
    }
}