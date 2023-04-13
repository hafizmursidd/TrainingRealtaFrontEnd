using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Back;
using SAB00400Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAB00400Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00410Controller : ControllerBase, ISAB00410
    {
        [HttpPost]
        public SAB00400ListDTO<SAB00410DTO> GetAllTerritory()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loRtn = null;

            try
            {
                var loCls = new SAB00410Cls();

                var loResult = loCls.GetAllTerritories();
                loRtn = new SAB00400ListDTO<SAB00410DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        [HttpPost]
        public SAB00400ListDTO<SAB00410DTO> GetAllTerritoryByRegion(int piTerritoryId)
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loRtn = null;

            try
            {
                var loCls = new SAB00410Cls();

                var loResult = loCls.GetTerritoryByRegion(piTerritoryId);
                loRtn = new SAB00400ListDTO<SAB00410DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00410DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB00410Cls();

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
        public R_ServiceGetRecordResultDTO<SAB00410DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00410DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB00410DTO>();

            try
            {
                var loCls = new SAB00410Cls();

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
        public R_ServiceSaveResultDTO<SAB00410DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00410DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB00410DTO>();

            try
            {
                var loCls = new SAB00410Cls();

                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
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
