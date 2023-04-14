using PublicLookupCommon.DTOs;
using R_BlazorFrontEnd.Exceptions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PublicLookupModel.ViewModels
{
    public class SAL00200ViewModel
    {
        private PublicLookupModel _model = new PublicLookupModel();

        public ObservableCollection<SAL00200DTO> CategoryList = new ObservableCollection<SAL00200DTO>();

        public async Task GetAllCategoryAsync()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllCategoryAsync();

                CategoryList = new ObservableCollection<SAL00200DTO>(loResult.Data);
            }
            catch (System.Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
