using MyLoginApp.Models;
using MyLoginApp.Services.ProductService;

namespace MyLoginApp
{
    public partial class App : Application
    {
        public static UserInfo? userInfo;
        static ProductService? _productService;

        public static ProductService? ProductService
        {
            get
            {
                if (_productService == null)
                {
                    _productService = new ProductService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductDB.db3"));
                }
                return _productService;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
