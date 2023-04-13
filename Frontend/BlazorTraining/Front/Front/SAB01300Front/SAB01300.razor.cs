using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using SAB01300Common.DTOs;
using SAB01300Model.ViewModels;

namespace SAB01300Front
{
    public partial class SAB01300 : R_Page
    {
        private SAB01300ViewModel ViewModel = new();
        private R_Grid<SAB01300DTO> _gridRef;
        private R_ConductorGrid _conGridCategoryRef;

        private SAB01310ViewModel ProductViewModel = new SAB01310ViewModel();
        private R_Conductor _conductorProductRef;
        private R_Grid<SAB01310DTO> _gridProductRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task GridCategory_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await ViewModel.GetCategoryList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        #region Conductor Category
        private async Task Grid_Display(R_DisplayEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Normal)
            {
                var loParam = (SAB01300DTO)eventArgs.Data;
                await _gridProductRef.R_RefreshGrid(loParam);
            }
        }

        private async Task Grid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB01300DTO)eventArgs.Data;
                var loResult = await ViewModel.GetCategory(loParam.CategoryID);

                eventArgs.Result = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                eventArgs.Result = await ViewModel.SaveCategory((SAB01300DTO)eventArgs.Data, (R_eConductorMode)eventArgs.ConductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB01300DTO)eventArgs.Data;
                await ViewModel.DeleteCategory(loData.CategoryID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Conductor Product
        private async Task GridProduct_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var liParam = ((SAB01300DTO)eventArgs.Parameter).CategoryID;
                await ProductViewModel.GetProductByCategory(liParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task ConductorProduct_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB01310DTO)eventArgs.Data;
                eventArgs.Result = await ProductViewModel.GetProductById(loParam.ProductID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        #endregion
    }
}
