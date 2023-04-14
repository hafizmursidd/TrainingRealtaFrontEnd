using PublicLookupCommon.DTOs;
using PublicLookupModel.ViewModels;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;

namespace PublicLookupFront
{
    public partial class SAL00300
    {
        private SAL00300ViewModel _viewModel = new SAL00300ViewModel();
        private R_Grid<SAL00300DTO> GridRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await GridRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task R_ServiceGetListRecordAsync(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _viewModel.GetAllProductAsync();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task Button_OnClickAsync()
        {
            var loData = GridRef.GetCurrentData();
            await this.Close(true, loData);
        }
    }
}
