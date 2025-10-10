using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class CategoryViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        private readonly ICategoryService _CategoryService;
        [ObservableProperty]
        Client client;

        public CategoryViewModel(ICategoryService CategoryService, GlobalViewModel global) 
        {
            Title = "catogorieen";
            _CategoryService = CategoryService;
            Categories = new ObservableCollection<Category>();
            LoadCategories();
            Client = global.Client;
        }

        private void LoadCategories()
        {
            Categories.Clear();
            var categories = _CategoryService.GetAll();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        [RelayCommand]
        public async Task SelectCategory(Category Category)
        {
            Dictionary<string, object> paramater = new() { { nameof(Category), Category } };
            await Shell.Current.GoToAsync($"{nameof(Views.ProductCategoryView)}?Titel={Category.Name}", true, paramater);
        }

        [RelayCommand]
        public async Task ShowBoughtProducts()
        {
            if (Client.Role == Role.Admin) await Shell.Current.GoToAsync(nameof(BoughtProductsView), true);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            LoadCategories();
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Categories.Clear();
        }
    }
}
