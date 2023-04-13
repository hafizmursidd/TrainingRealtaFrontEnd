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
    public class SAB01310Controller : ControllerBase, ISAB01310
    {
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB01310DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB01310Cls();

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
        public R_ServiceGetRecordResultDTO<SAB01310DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB01310DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB01310DTO>();

            try
            {
                var loCls = new SAB01310Cls();

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
        public R_ServiceSaveResultDTO<SAB01310DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB01310DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB01310DTO>();

            try
            {
                var loCls = new SAB01310Cls();

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
        public SAB01300ListDTO<SAB01310DTO> GetAllProduct()
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01310DTO> loRtn = null;

            try
            {
                var loCls = new SAB01310Cls();

                var loResult = loCls.GetAllProduct();
                loRtn = new SAB01300ListDTO<SAB01310DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SAB01300ListDTO<SAB01310DTO> GetAllProductByCategory([FromBody] int piCategoryId)
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01310DTO> loRtn = null;

            try
            {
                var loCls = new SAB01310Cls();

                var loResult = loCls.GetAllProductByCategory(piCategoryId);
                loRtn = new SAB01300ListDTO<SAB01310DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public IAsyncEnumerable<SAB01310DTO> GetAllProductStream()
        {
            var loEx = new R_Exception();
            IAsyncEnumerable<SAB01310DTO> loRtn = null;

            try
            {
                var loCls = new SAB01310Cls();

                var loResult = loCls.GetAllProduct();

                loRtn = GetProductStream(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        [HttpPost]
        public IAsyncEnumerable<SAB01310DTO> GetAllProductByCategoryStream()
        {
            var loEx = new R_Exception();
            IAsyncEnumerable<SAB01310DTO> loRtn = null;

            try
            {
                var liCategoryId = R_Utility.R_GetStreamingContext<int>(ContextConstant.CATEGORY_ID);
                var loCls = new SAB01310Cls();

                var loResult = loCls.GetAllProductByCategory(liCategoryId);

                loRtn = GetProductStream(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        private async IAsyncEnumerable<SAB01310DTO> GetProductStream(List<SAB01310DTO> poParameter)
        {
            foreach (SAB01310DTO item in poParameter)
            {
                await Task.Delay(10);
                yield return item;
            }
        }
    }
}
