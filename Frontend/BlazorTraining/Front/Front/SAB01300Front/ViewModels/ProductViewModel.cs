using ProductCommon.DTOs;
using ProductModels;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using System.Collections.ObjectModel;

namespace SAB01300Front.ViewModels
{
    public class ProductViewModel : R_ViewModel<ProductDTO>
    {
        private ProductModel _productModel = null;

        public ObservableCollection<ProductDTO> ProductList { get; set; } = new();

        public ProductViewModel()
        {
            _productModel = new();
        }

        public async Task GetProductByCategory(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _productModel.GetProductListByCategory(piCategoryId);
                ProductList = new ObservableCollection<ProductDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<ProductDTO> GetProductById(int piProductId)
        {
            var loEx = new R_Exception();
            ProductDTO loResult = null;

            try
            {
                var loParam = new ProductDTO { ProductID = piProductId };
                loResult = await _productModel.GetProduct(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<ProductDTO> SaveProduct(ProductDTO poNewEntity, R_eConductorMode peConductorMode)
        {
            var loEx = new R_Exception();
            ProductDTO loResult = null;

            try
            {
                loResult = await _productModel.SaveProduct(poNewEntity, (eCRUDMode)peConductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteProduct(int productId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new ProductDTO { ProductID = productId };
                await _productModel.DeleteProduct(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
