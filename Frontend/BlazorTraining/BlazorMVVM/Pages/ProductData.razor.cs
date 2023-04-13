using BlazorMVVM.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorMVVM.Pages
{
    public partial class ProductData
    {
        [Inject] public ProductDataViewModel ProductDataViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ProductDataViewModel.GetProductsAsync();
        }

        public void SaveProduct()
        {
            ProductDataViewModel.SaveProduct(ProductDataViewModel.Product);
        }
    }
}
