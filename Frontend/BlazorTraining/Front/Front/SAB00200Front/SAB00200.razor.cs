using BlazorClientHelper;
using Microsoft.AspNetCore.Components;
using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;
using SAB00100Common.DTOs;
using SAB00200Model;

namespace SAB00200Front;

public partial class SAB00200
{
    private SAB00200ViewModel EmployeeViewModel = new();

    private R_ConductorGrid _conGridEmployeeRef;

    private R_Grid<SAB00100DTO> _gridRef;
    [Inject] private IClientHelper _clientHelper { get; set; }

    protected override async Task R_Init_From_Master(object poParameter)
    {
        var loEx = new R_Exception();
    
        try
        {
            var lcCompanyId = _clientHelper.CompanyId;
            var lcUserId = _clientHelper.UserId;
    
            await _gridRef.R_RefreshGrid(null);
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }
    
        loEx.ThrowExceptionIfErrors();
    }

    private async Task Grid_R_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
    {
        var loEx = new R_Exception();

        try
        {
            await EmployeeViewModel.GetAllEmployeeAsync();
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }

    private void Grid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
    {

    }

    private void Grid_Validation(R_ValidationEventArgs eventArgs)
    {

    }

    private void Grid_ServiceSave(R_ServiceSaveEventArgs eventArgs)
    {

    }

    private void Grid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
    {

    }

    private void Grid_AfterDelete()
    {

    }
}