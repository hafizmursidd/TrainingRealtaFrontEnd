using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00400Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB00400
{
    public class SAB00400Model
    {
        private SAB00400Client _SAB0400clientWrapper = null;
        private SAB00410Client _SAB00410clientWrapper = null;

        public SAB00400Model()
        {
            _SAB0400clientWrapper = new SAB00400Client();
            _SAB00410clientWrapper = new SAB00410Client();
        }

        public async Task<SAB00400DTO> GetRegionAsync(SAB00400DTO poParam)
        {
            var loEx = new R_Exception();
            SAB00400DTO loResult = null;

            try
            {
                loResult = await _SAB0400clientWrapper.R_ServiceGetRecordAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
        public async Task<SAB00400DTO> SaveRegionAsync(SAB00400DTO poParam, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();
            SAB00400DTO loResult = null;

            try
            {
                loResult = await _SAB0400clientWrapper.R_ServiceSaveAsync(poParam, poCRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteRegionAsync(SAB00400DTO poParam)
        {
            var loEx = new R_Exception();

            try
            {
                await _SAB0400clientWrapper.R_ServiceDeleteAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<List<SAB00400DTO>> GetRegionListAsync()
        {
            var loEx = new R_Exception();
            List<SAB00400DTO> loResult = null;

            try
            {
                var loRegion = await _SAB0400clientWrapper.GetAllRegionAsync();
                loResult = loRegion.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        #region SAB00410
        public async Task<SAB00410DTO> GetTerritory(SAB00410DTO poParam)
        {
            var loEx = new R_Exception();
            SAB00410DTO loResult = null;

            try
            {
                //loResult = await _SAB00410clientWrapper.GetAllTerritoryByRegionAsync(poParam.RegionId);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<List<SAB00410DTO>> GetRegionList()
        {
            var loEx = new R_Exception();
            List<SAB00410DTO> loResult = null;

            try
            {
                var loRegion = await _SAB00410clientWrapper.GetAllTerritoryAsync();
                loResult = loRegion.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<List<SAB00410DTO>> GetTerritoryListByRegionId(int piRegionId)
        {
            var loEx = new R_Exception();
            List<SAB00410DTO> loResult = null;

            try
            {
                var loProducts = await _SAB00410clientWrapper.GetAllTerritoryByRegionIdAsync(piRegionId);
                loResult = loProducts.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        #endregion
    }
}
