using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Back;
using SAB00400Common;

namespace SAB00400Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00400Controller : ControllerBase, ISAB00400
    {

        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00400DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB00400Cls();

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
        public R_ServiceGetRecordResultDTO<SAB00400DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00400DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB00400DTO>();

            try
            {
                var loCls = new SAB00400Cls();

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
        public R_ServiceSaveResultDTO<SAB00400DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00400DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB00400DTO>();

            try
            {
                var loCls = new SAB00400Cls();

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
        public SAB00400ListDTO<SAB00400DTO> GetAllRegion()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00400DTO> loRtn = null;

            try
            {
                var loCls = new SAB00400Cls();

                //ini merupakan context dari streaming yang didapatkan dari FRONT
                //var getContext = R_Utility.R_GetStreamingContext<string>(ContextConstant.REGION_ID);
               
                var loResult = loCls.GetRegion();
                loRtn = new SAB00400ListDTO<SAB00400DTO> { Data = loResult };
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