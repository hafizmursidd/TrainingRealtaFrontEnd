using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00900Back;
using SAB00900Common;
using SAB00900Common.DTOs;

namespace SAB00900Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00900Controller : ControllerBase, ISAB00900
    {
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00900DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB00900Cls();

                loCls.R_Delete(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceGetRecordResultDTO<SAB00900DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00900DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB00900DTO>();

            try
            {
                var loCls = new SAB00900Cls();

                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<SAB00900DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00900DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB00900DTO>();

            try
            {
                var loCls = new SAB00900Cls();

                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SAB00900ListDTO<SAB00900CategoryDTO> GetAllCategory()
        {
            var loEx = new R_Exception();
            SAB00900ListDTO<SAB00900CategoryDTO> loRtn = null;

            try
            {
                var loCls = new SAB00900Cls();

                var loResult = loCls.GetAllCategory();
                loRtn = new SAB00900ListDTO<SAB00900CategoryDTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SAB00900ListDTO<SAB00900DTO> GetAllProduct()
        {
            var loEx = new R_Exception();
            SAB00900ListDTO<SAB00900DTO> loRtn = null;

            try
            {
                var loCls = new SAB00900Cls();

                var loResult = loCls.GetAllProduct();
                loRtn = new SAB00900ListDTO<SAB00900DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
    }
}