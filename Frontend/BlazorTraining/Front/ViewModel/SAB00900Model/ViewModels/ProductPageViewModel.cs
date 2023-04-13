using R_BlazorFrontEnd.Exceptions;
using SAB00900Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00900Model.ViewModels
{
    public class ProductPageViewModel
    {
        private SAB00900Model _model = new SAB00900Model();

        public ObservableCollection<SAB00900DTO> ProductList = new ObservableCollection<SAB00900DTO>();

        public async Task GetProductList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllProductAsync();
                ProductList = new ObservableCollection<SAB00900DTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
