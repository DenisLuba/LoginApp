using MyLoginApp.Models;
using MyLoginApp.ViewModels;

namespace MyLoginApp.Views;

public partial class AddProductPage : ContentPage
{
	public ProductInfo? ProductInfo { get; set; }

	public AddProductPage()
	{
		InitializeComponent();
		BindingContext = new AddProductPageViewModel();
	}

    public AddProductPage(ProductInfo? productInfo) : this()
    {
		if (productInfo is not null && BindingContext is AddProductPageViewModel viewModel)
		{
			viewModel.ProductInfo = productInfo;
		}
    }
}