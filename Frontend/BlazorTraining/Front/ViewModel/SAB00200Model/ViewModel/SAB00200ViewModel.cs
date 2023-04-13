using System.Collections.ObjectModel;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using SAB00100Common.DTOs;

namespace SAB00200Model
{
    public class SAB00200ViewModel : R_ViewModel<SAB00100DTO>
    {
        private SAB00200Model _model = new SAB00200Model();

        public ObservableCollection<SAB00100DTO> EmployeeList = new ObservableCollection<SAB00100DTO>();

        public async Task GetAllEmployeeAsync()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllEmployeeOriginalAsync();

                EmployeeList = new ObservableCollection<SAB00100DTO>(loResult.Data);
            }
            catch (System.Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}