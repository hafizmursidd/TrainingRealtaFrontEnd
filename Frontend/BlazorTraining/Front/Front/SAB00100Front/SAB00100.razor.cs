using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front;

public partial class SAB00100
{
    private SAB00100ViewModel _viewModel = new SAB00100ViewModel();
    private R_Conductor _conductorRef;

    #region FIND

    private void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
    {
        // eventArgs.FindParameter = new SAB00100FindDTO();
        eventArgs.TargetPageType = typeof(SAB00110);
    }

    private async Task R_After_Open_FindAsync(R_AfterOpenFindEventArgs eventArgs)
    {
        var loData = eventArgs.Result;
        await _conductorRef.R_GetEntity(loData);
    }

    #endregion

    #region CONDUCTOR

    private async Task R_ServiceGetRecordAsync(R_ServiceGetRecordEventArgs eventArgs)
    {
        var loEx = new R_Exception();
        try
        {
            var loData = R_FrontUtility.ConvertObjectToObject<SAB00100DTO>(eventArgs.Data);
            await _viewModel.R_ServiceGetRecordAsync(loData.EmployeeID);
            eventArgs.Result = _viewModel.Employee;
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }

    private void R_Validation(R_ValidationEventArgs eventArgs)
    {
        var loEx = new R_Exception();
        try
        {
            _viewModel.R_SaveValidation((SAB00100DTO)eventArgs.Data);
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        eventArgs.Cancel = loEx.HasError;
        loEx.ThrowExceptionIfErrors();
    }
    

    private void R_AfterAdd(R_AfterAddEventArgs eventArgs)
    {
        var loDefault = (SAB00100DTO)eventArgs.Data;

        loDefault.Address = "Sentul";
        loDefault.City = "Bogor";
        loDefault.Country = "Indonesia";

    }

    private async Task R_ServiceSaveAsync(R_ServiceSaveEventArgs eventArgs)
    {
        var loEx = new R_Exception();
        try
        {
            await _viewModel.R_ServiceSaveAsync((SAB00100DTO)eventArgs.Data, (eCRUDMode)eventArgs.ConductorMode);
            eventArgs.Result = _viewModel.Employee;
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }
    
    
    private async Task R_AfterSaveAsync(R_AfterSaveEventArgs eventArgs)
    {
        var loData = (SAB00100DTO)eventArgs.Data;

        await R_MessageBox.Show("", $"Save {loData.EmployeeID} success.", R_eMessageBoxButtonType.OK);
    }

    private async Task R_ServiceDeleteAsync(R_ServiceDeleteEventArgs eventArgs)
    {
        var loEx = new R_Exception();
        try
        {
            await _viewModel.R_ServiceDeleteAsync((SAB00100DTO)eventArgs.Data);
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }

    #endregion
}