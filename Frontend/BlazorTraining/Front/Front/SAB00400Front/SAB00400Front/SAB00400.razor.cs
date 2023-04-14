using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls;
using SAB00400.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAB00400Common;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd;
using Microsoft.AspNetCore.Components;
using R_ContextFrontEnd;

namespace SAB00400Front
{
    public partial class SAB00400
    {
        private SAB00400ViewModel _viewModel = new SAB00400ViewModel();
        private R_Grid<SAB00400DTO> _gridRef;
        private R_ConductorGrid _conGridRegionRef;

        private SAB00410ViewModel _viewodelTerritory = new SAB00410ViewModel();
        private R_Conductor _conductorTerritorytRef;
        private R_Grid<SAB00410DTO> _gridTerritoryRef;

        public int _regionId;

        [Inject] private R_ContextHeader _contextHeader { get; set; }

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                //2 LIne on the bootom
                ////ini merupakan set dari context yang disetting dari depan (ini)
                //string abc= "INI MERUPAKAN CONTOH SET STREAMING CONTEXT DARI FRONT";
                //_contextHeader.R_Context.R_SetStreamingContext(ContextConstant.REGION_ID, abc);

                await _gridRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }
        private async Task GridRegion_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await _viewModel.GetRegionList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        #region Conductor REGION
        private async Task Grid_Display(R_DisplayEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Normal)
            {
                var loParam = (SAB00400DTO)eventArgs.Data;
                await _gridTerritoryRef.R_RefreshGrid(loParam);
            }
        }

        private async Task Grid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = (SAB00400DTO)eventArgs.Data;
               // var _regionId = 
                var loResult = await _viewModel.GetRegion(loParam.RegionId);

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
                // eventArgs.Result = await _viewModel.SaveCategory((SAB01300DTO)eventArgs.Data, (R_eConductorMode)eventArgs.ConductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
        #endregion

        #region Territory
        private async Task GridTerritory_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                _regionId = ((SAB00400DTO)eventArgs.Parameter).RegionId;
                await _viewodelTerritory.GetListTerritoryByRegionId(_regionId);
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
                var loParam = (SAB00400DTO)eventArgs.Data;
               // eventArgs.Result = await _viewodelTerritory.GetTerritoryById(loParam.RegionId);
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
