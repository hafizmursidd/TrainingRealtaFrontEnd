using PublicLookupCommon.DTOs;
using R_BlazorFrontEnd.Exceptions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PublicLookupModel.ViewModels
{
    public class SAL00300ViewModel
    {
        private PublicLookupModel _model = new PublicLookupModel();

        public ObservableCollection<SAL00300DTO> ProductList = new ObservableCollection<SAL00300DTO>();

        public async Task GetAllProductAsync()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllProductAsync();

                ProductList = new ObservableCollection<SAL00300DTO>(loResult.Data);
            }
            catch (System.Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
