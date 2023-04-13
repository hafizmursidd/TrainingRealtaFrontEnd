using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00100Back;
using SAB00100Common;
using SAB00100Common.DTOs;

namespace SAB00100Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00100Controller : ControllerBase, ISAB00100
    {
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00100DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB00100Cls();

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
        public R_ServiceGetRecordResultDTO<SAB00100DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00100DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB00100DTO>();

            try
            {
                var loCls = new SAB00100Cls();

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
        public R_ServiceSaveResultDTO<SAB00100DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00100DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB00100DTO>();

            try
            {
                var loCls = new SAB00100Cls();

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
        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeDTO loRtn = null;

            try
            {
                var loCls = new SAB00100Cls();

                var loResult = loCls.GetAllEmployee();
                var loConvert = R_Utility.R_ConvertCollectionToCollection<SAB00100DTO, SAB00100GridDTO>(loResult).ToList();
                loRtn = new SAB00100ListEmployeeDTO { Data = loConvert };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SAB00100ListEmployeeOriginalDTO GetAllEmployeeOriginal()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeOriginalDTO loRtn = null;

            try
            {
                var lcCompId = R_BackGlobalVar.COMPANY_ID;
                var lcUserId = R_BackGlobalVar.USER_ID;
                // var lcCulture = R_BackGlobalVar.CULTURE_MENU;

                var loCls = new SAB00100Cls();

                var loResult = loCls.GetAllEmployee();
                loRtn = new SAB00100ListEmployeeOriginalDTO { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public IAsyncEnumerable<SAB00100DTO> GetAllEmployeeStream()
        {
            var loEx = new R_Exception();
            IAsyncEnumerable<SAB00100DTO> loRtn = null;

            try
            {
                var loCls = new SAB00100Cls();

                var loResult = loCls.GetAllEmployee();

                loRtn = GetEmployeeStream(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        private async IAsyncEnumerable<SAB00100DTO> GetEmployeeStream(List<SAB00100DTO> poParameter)
        {
            foreach (SAB00100DTO item in poParameter)
            {
                await Task.Delay(10);
                yield return item;
            }
        }

    }
}