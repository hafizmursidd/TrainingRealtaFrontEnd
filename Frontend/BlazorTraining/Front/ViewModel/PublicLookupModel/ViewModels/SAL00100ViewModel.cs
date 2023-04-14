using PublicLookupCommon.DTOs;
using R_BlazorFrontEnd.Exceptions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PublicLookupModel.ViewModels
{
    public class SAL00100ViewModel
    {
        private PublicLookupModel _model = new PublicLookupModel();

        public ObservableCollection<SAL00100DTO> EmployeeList = new ObservableCollection<SAL00100DTO>();

        public async Task GetAllEmployeeAsync()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllEmployeeAsync();

                EmployeeList = new ObservableCollection<SAL00100DTO>(loResult.Data);
            }
            catch (System.Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
