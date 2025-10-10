using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoryViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private readonly IFileSaverService _fileSaverService;
        private readonly IProductCategoryService _productCategoryService;
        private string searchText = "";
        public ObservableCollection<Product> CategoryItemList { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];

        [ObservableProperty]
        Category category = new(0, "None");
        [ObservableProperty]
        string myMessage;


        public ProductCategoryViewModel(IGroceryListItemsService groceryListItemsService, IProductService productService, IFileSaverService fileSaverService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _fileSaverService = fileSaverService;
            _productCategoryService = productCategoryService;
            
            // Don't call GetAvailableProducts() here - wait for a valid category to be set
        }

        private void Load(int id)
        {
            //load product in category
            List<ProductCategory> categoryProducts = _productCategoryService.GetAll().Where(pc => pc.CategoryId == id).ToList();

            CategoryItemList.Clear();

            foreach (ProductCategory pc in categoryProducts)
            {
                Product? p = _productService.Get(pc.ProductId);
                if (p != null) CategoryItemList.Add(p);
            }

        }

        private void GetAvailableProducts()
        {
            // Don't load anything if no valid category is set
            if (category == null || category.Id <= 0)
            {
                AvailableProducts.Clear();
                return;
            }

            List<ProductCategory> categoryProducts = _productCategoryService.GetAll().Where(pc => pc.CategoryId == category.Id).ToList();

            AvailableProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (categoryProducts.FirstOrDefault(cp => cp.ProductId == p.Id) == null && (searchText == "" || p.Name.ToLower().Contains(searchText.ToLower())))
                    AvailableProducts.Add(p);
        }

        partial void OnCategoryChanged(Category value)
        {
            if (value != null)
            {
                Load(value.Id);
                GetAvailableProducts(); // Load available products after category is set
            }
        }

        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (product == null) return;
            ProductCategory _productcategory = new(0, "", product.Id, Category.Id);

            _productCategoryService.Add(_productcategory);
            CategoryItemList.Add(product);
            AvailableProducts.Remove(product);
            GetAvailableProducts();
        }


        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            GetAvailableProducts();
        }


    }
}
