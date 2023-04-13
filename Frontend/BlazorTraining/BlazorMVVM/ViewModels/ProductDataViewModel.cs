using BlazorMVVM.DTOs;
using BlazorMVVM.Models;

namespace BlazorMVVM.ViewModels
{
    public class ProductDataViewModel
    {
        private readonly IProductModel _productModel;

        public List<Product> Products { get; private set; }

        public Product Product { get; private set; } = new();

        public ProductDataViewModel(IProductModel productModel)
        {
            _productModel = productModel;
        }

        public async Task GetProductsAsync()
        {
            Products = await _productModel.GetProductsAsync();
        }

        public void SetProduct(Product product)
        {
            Product = product;
        }

        public void SaveProduct(Product product)
        {
            if (_isAdd)
            {
                //TODO Validation
                Products.Add(product);
            }
            else
            {
                var loProduct = Products.FirstOrDefault(x => x.ProductID == product.ProductID);
                loProduct = product;
            }

            _isAdd = false;
        }

        private bool _isAdd = false;
        public bool IsAdd
        {
            get => _isAdd;
        }

        public void AddProduct()
        {
            Product = new Product();
            _isAdd = true;
        }

        public void DeleteProduct(Product product)
        {
            //TODO validation or confirmation
            var loProduct = Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (loProduct != null)
                Products.Remove(loProduct);
        }
    }
}
