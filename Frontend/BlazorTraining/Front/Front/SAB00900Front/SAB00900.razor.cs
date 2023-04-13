using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using SAB00900Common.DTOs;
using SAB00900Model.ViewModels;

namespace SAB00900Front
{
    public partial class SAB00900 : R_Page
    {
        private SAB00900ViewModel ViewModel = new();
        private R_Conductor _conductorRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await ViewModel.GetCategories();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        #region Conductor
        public async Task Conductor_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00900DTO)eventArgs.Data;
                await ViewModel.GetProductById(loParam.ProductID);

                eventArgs.Result = ViewModel.Product;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public void Conductor_AfterAdd(R_AfterAddEventArgs eventArgs)
        {
            var loEntity = (SAB00900DTO)eventArgs.Data;

            loEntity.CategoryID = 1;
            loEntity.UnitsInStock = 20;
            loEntity.Discontinued = true;
            loEntity.UnitPrice = 0;

            ViewModel.ChosenOption = 1;
        }

        public void Conductor_Validation(R_ValidationEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00900DTO)eventArgs.Data;

                if (string.IsNullOrWhiteSpace(loData.ProductName))
                    loEx.Add("", "Please fill Product Name.");

                if (loData.UnitPrice == 0)
                    loEx.Add("", "Price cannot be 0.");
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            if (loEx.HasError)
                eventArgs.Cancel = true;

            loEx.ThrowExceptionIfErrors();
        }

        public async Task Conductor_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00900DTO)eventArgs.Data;
                await ViewModel.SaveProduct(loParam, eventArgs.ConductorMode);

                eventArgs.Result = ViewModel.Product;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task Conductor_AfterSave(R_AfterSaveEventArgs eventArgs)
        {
            var loData = (SAB00900DTO)eventArgs.Data;

            if (eventArgs.ConductorMode == R_eConductorMode.Add)
                await R_MessageBox.Show("", $"Add {loData.ProductID} success.", R_eMessageBoxButtonType.OK);
            else
                await R_MessageBox.Show("", $"Edit {loData.ProductID} success.", R_eMessageBoxButtonType.OK);
        }

        public async Task Conductor_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00900DTO)eventArgs.Data;
                await ViewModel.DeleteProduct(loParam.ProductID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public void Conductor_Display(R_DisplayEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Normal)
            {
                ViewModel.ChosenOption = ((SAB00900DTO)eventArgs.Data).Discontinued ? 1 : 2;
            }
        }

        public void Conductor_Saving(R_SavingEventArgs eventArgs)
        {
            ((SAB00900DTO)eventArgs.Data).Discontinued = ViewModel.ChosenOption == 1 ? true : false;
        }

        public async Task Conductor_AfterDelete()
        {
            await R_MessageBox.Show("", "Delete Success", R_eMessageBoxButtonType.OK);
        }

        public Task Conductor_BeforeAdd(R_BeforeAddEventArgs eventArgs)
        {
            //var loEx = new R_Exception();

            //try
            //{
            //    await ViewModel.GetProductList();
            //    var llCancel = ViewModel.ProductList.Count > 70;

            //    if (llCancel)
            //    {
            //        eventArgs.Cancel = llCancel;
            //        await R_MessageBox.Show("", "Cannot add more product.", R_eMessageBoxButtonType.OK);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    loEx.Add(ex);
            //}

            //loEx.ThrowExceptionIfErrors();

            return Task.CompletedTask;
        }

        public async Task Conductor_BeforeEdit(R_BeforeEditEventArgs eventArgs)
        {
            var loData = (SAB00900DTO)eventArgs.Data;

            if (loData.ProductID == 1)
            {
                eventArgs.Cancel = true;
                await R_MessageBox.Show("", "Cannot modify Product ID 1", R_eMessageBoxButtonType.OK);
            }
        }

        public async Task Conductor_BeforeDelete(R_BeforeDeleteEventArgs eventArgs)
        {
            var loData = (SAB00900DTO)eventArgs.Data;

            if (loData.ProductID == 1)
            {
                eventArgs.Cancel = true;
                await R_MessageBox.Show("", "Cannot delete Product ID 1", R_eMessageBoxButtonType.OK);
            }
        }

        public async Task Conductor_BeforeCancel(R_BeforeCancelEventArgs eventArgs)
        {
            var loResult = await R_MessageBox.Show("Confirmation", "Are you sure to cancel?", R_eMessageBoxButtonType.OKCancel);

            if (loResult == R_eMessageBoxResult.Cancel)
                eventArgs.Cancel = true;
        }

        public Task Conductor_CheckAdd(R_CheckAddEventArgs eventArgs)
        {
            //var loEx = new R_Exception();

            //try
            //{
            //    await ViewModel.GetProductList();
            //    var llCancel = ViewModel.ProductList.Count > 70;

            //    if (llCancel)
            //    {
            //        eventArgs.Allow = !llCancel;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    loEx.Add(ex);
            //}

            //loEx.ThrowExceptionIfErrors();

            return Task.CompletedTask;
        }

        public void Conductor_CheckEdit(R_CheckEditEventArgs eventArgs)
        {
            var loData = (SAB00900DTO)eventArgs.Data;

            if (loData.ProductID == 1)
            {
                eventArgs.Allow = true;
            }
        }

        public void Conductor_CheckDelete(R_CheckDeleteEventArgs eventArgs)
        {
            var loData = (SAB00900DTO)eventArgs.Data;

            if (loData.ProductID == 1)
            {
                eventArgs.Allow = true;
            }
        }

        private R_Button SetButtonRef;
        public void Conductor_SetAdd(R_SetEventArgs eventArgs)
        {
            //if (SetButtonRef != null)
            //    SetButtonRef.Enabled = !eventArgs.Enable;
        }

        public void Conductor_SetEdit(R_SetEventArgs eventArgs)
        {
            //if (SetButtonRef != null)
            //    SetButtonRef.Enabled = !eventArgs.Enable;
        }

        public void Conductor_SetHasData(R_SetEventArgs eventArgs)
        {
            //if (SetButtonRef != null)
            //    SetButtonRef.Enabled = !eventArgs.Enable;
        }

        public void Conductor_SetOther(R_SetEventArgs eventArgs)
        {
            //if (SetButtonRef != null)
            //    SetButtonRef.Enabled = !eventArgs.Enable;
        }
        #endregion

        #region Find
        public void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(ProductPage);
        }

        public async Task R_After_Open_Find(R_AfterOpenFindEventArgs eventArgs)
        {
            if (eventArgs.Result == null) return;

            var loData = (SAB00900DTO)eventArgs.Result;
            var loParam = new SAB00900DTO { ProductID = loData.ProductID };

            await _conductorRef.R_GetEntity(loParam);
        }

        public void FindModel(R_FindModelEventArgs eventArgs)
        {
            //var loData = (SAB00900DTO)eventArgs.Result;
            //if (loData.ProductID == 1)
            //    eventArgs.FindModel = R_BlazorFrontEnd.Controls.Enums.R_eFindModel.ViewOnly;

            //if (loData.ProductID == 2)
            //    eventArgs.FindModel = R_BlazorFrontEnd.Controls.Enums.R_eFindModel.NoDisplay;

            //if (loData.ProductID > 2)
            //    eventArgs.FindModel = R_BlazorFrontEnd.Controls.Enums.R_eFindModel.Normal;
        }
        #endregion
    }
}
