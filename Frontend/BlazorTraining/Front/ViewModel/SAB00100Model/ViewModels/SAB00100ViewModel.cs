using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100FrontResources;

namespace SAB00100Model
{
    public class SAB00100ViewModel: R_ViewModel<SAB00100DTO>
    {
        private SAB00100Model _model = new SAB00100Model();
        
        public SAB00100DTO Employee = new SAB00100DTO();

        public async Task R_ServiceGetRecordAsync(int pnEmployeeId)
        {
            var loEx = new R_Exception();
            
            try
            {
                var loParam = new SAB00100DTO{EmployeeID = pnEmployeeId};
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);
                Employee = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            
            loEx.ThrowExceptionIfErrors();
        }

        public void R_SaveValidation(SAB00100DTO poEntity)
        {
            var loEx = new R_Exception();
            try
            {
                if (string.IsNullOrWhiteSpace(poEntity.FirstName))
                {
                    var loErr = R_FrontUtility.R_GetError(typeof(Resources_Dummy_Class), "PS001");
                    loEx.Add(loErr);
                }
                if (string.IsNullOrWhiteSpace(poEntity.LastName))
                {
                    var loErr = R_FrontUtility.R_GetError(typeof(Resources_Dummy_Class), "PS001");
                    loEx.Add(loErr);
                }
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task R_ServiceSaveAsync(SAB00100DTO poEntity, eCRUDMode peMode)
        {
            var loEx = new R_Exception();
            try
            {
                var loResult = await _model.R_ServiceSaveAsync(poEntity, peMode);
                Employee = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public async Task R_ServiceDeleteAsync(SAB00100DTO poEntity)
        {
            var loEx = new R_Exception();
            try
            {
                await _model.R_ServiceDeleteAsync(poEntity);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            
            loEx.ThrowExceptionIfErrors();
        }
    }
}