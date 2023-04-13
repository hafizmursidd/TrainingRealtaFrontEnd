using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using SAB01300Common.DTOs;
using SAB01300Model.ViewModels;

namespace SAB01400Front
{
    public partial class SAB01400 : R_Page
    {
        private SAB01300ViewModel ViewModel = new SAB01300ViewModel();
        private R_Conductor _conductorRef;

        private SAB01310ViewModel ProductViewModel = new SAB01310ViewModel();
        private R_Conductor _conductorProductRef;
        private R_Grid<SAB01310DTO> _gridRef;

        protected override Task R_Init_From_Master(object poParameter)
        {
            return Task.CompletedTask;
        }

        #region Find
        private void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(SAB01410);
        }

        private async Task R_After_Open_Find(R_AfterOpenFindEventArgs eventArgs)
        {
            var loData = (SAB01300DTO)eventArgs.Result;
            var loParam = new SAB01300DTO { CategoryID = loData.CategoryID };
            await _conductorRef.R_GetEntity(loParam);
        }
        #endregion

        #region CONDUCTOR HEADER
        private async Task Conductor_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB01300DTO)eventArgs.Data;
                eventArgs.Result = await ViewModel.GetCategory(loParam.CategoryID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private void Conductor_Validation(R_ValidationEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB01300DTO)eventArgs.Data;

                if (string.IsNullOrWhiteSpace(loData.CategoryName))
                    loEx.Add("", "Please fill Category Name.");
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            if (loEx.HasError)
                eventArgs.Cancel = true;

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Conductor_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB01300DTO)eventArgs.Data;
                eventArgs.Result = await ViewModel.SaveCategory(loParam, eventArgs.ConductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Conductor_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB01300DTO)eventArgs.Data;
                await ViewModel.DeleteCategory(loParam.CategoryID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Conductor_Display(R_DisplayEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Normal)
            {
                var loParam = (SAB01300DTO)eventArgs.Data;
                await _gridRef.R_RefreshGrid(loParam);
            }
        }
        #endregion

        private async Task Grid_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
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

        #region CONDUCTOR GRID PRODUCT
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

        #region PREDEFINED
        private void PreDock_InstantiateDock(R_PredefinedDockEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(TestPredefined);
        }
        #endregion
    }
}
