using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front;

public partial class SAB00110
{
    
    private SAB00110ViewModel _viewModel = new SAB00110ViewModel();
    private R_Grid<SAB00100GridDTO> GridRef;

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

        // return 
    }

    private async Task R_ServiceGetListRecord(R_ServiceGetListRecordEventArgs poEventArgs)
    {
        var loEx = new R_Exception();
        try
        {
            await _viewModel.GetAllEmployeeAsync();
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }
        loEx.ThrowExceptionIfErrors();
    }

    private async Task Button_OnClickAsync()
    {
        var loData = GridRef.GetCurrentData();
        await this.Close(true, loData);
    }
}