using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;
using SAB01300Back;
using SAB01300Common;
using SAB01300Common.DTOs;

namespace SAB01300Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB01300Controller : ControllerBase, ISAB01300
    {
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB01300DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB01300Cls();

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
        public R_ServiceGetRecordResultDTO<SAB01300DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB01300DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB01300DTO>();

            try
            {
                var loCls = new SAB01300Cls();

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
        public R_ServiceSaveResultDTO<SAB01300DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB01300DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB01300DTO>();

            try
            {
                var loCls = new SAB01300Cls();

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
        public SAB01300ListDTO<SAB01300DTO> GetAllCategory()
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01300DTO> loRtn = null;

            try
            {
                var loCls = new SAB01300Cls();

                var loResult = loCls.GetCategories();
                loRtn = new SAB01300ListDTO<SAB01300DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public IAsyncEnumerable<SAB01300DTO> GetAllCategoryStream()
        {
            var loEx = new R_Exception();
            IAsyncEnumerable<SAB01300DTO> loRtn = null;

            try
            {
                var loCls = new SAB01300Cls();

                var loResult = loCls.GetCategories();

                loRtn = GetCategoryStream(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

      
        private async IAsyncEnumerable<SAB01300DTO> GetCategoryStream(List<SAB01300DTO> poParameter)
        {
            foreach (SAB01300DTO item in poParameter)
            {
                await Task.Delay(10);
                yield return item;
            }
        }
    }
}