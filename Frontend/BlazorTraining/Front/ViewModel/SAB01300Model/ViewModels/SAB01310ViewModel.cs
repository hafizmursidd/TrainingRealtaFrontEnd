using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB01300Model.ViewModels
{
    public class SAB01310ViewModel : R_ViewModel<SAB01310DTO>
    {
        private SAB01300Model _SAB01300Model = null;

        public ObservableCollection<SAB01310DTO> ProductList { get; set; } = new ObservableCollection<SAB01310DTO>();

        public SAB01310ViewModel()
        {
            _SAB01300Model = new SAB01300Model();
        }

        public async Task GetProductByCategory(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB01300Model.GetProductListByCategory(piCategoryId);
                ProductList = new ObservableCollection<SAB01310DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<SAB01310DTO> GetProductById(int piProductId)
        {
            var loEx = new R_Exception();
            SAB01310DTO loResult = null;

            try
            {
                var loParam = new SAB01310DTO { ProductID = piProductId };
                loResult = await _SAB01300Model.GetProduct(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB01310DTO> SaveProduct(SAB01310DTO poNewEntity, R_eConductorMode peConductorMode)
        {
            var loEx = new R_Exception();
            SAB01310DTO loResult = null;

            try
            {
                loResult = await _SAB01300Model.SaveProduct(poNewEntity, (eCRUDMode)peConductorMode);
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
                var loParam = new SAB01310DTO { ProductID = productId };
                await _SAB01300Model.DeleteProduct(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
