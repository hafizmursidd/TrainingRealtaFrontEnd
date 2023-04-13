using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB01300Model
{
    public class SAB01300Model
    {
        private SAB01300Client _SAB01300clientWrapper = null;
        private SAB01310Client _SAB01310clientWrapper = null;

        public SAB01300Model()
        {
            _SAB01300clientWrapper = new SAB01300Client();
            _SAB01310clientWrapper = new SAB01310Client();
        }

        #region SAB01300
        public async Task<SAB01300DTO> GetCategoryAsync(SAB01300DTO poParam)
        {
            var loEx = new R_Exception();
            SAB01300DTO loResult = null;

            try
            {
                loResult = await _SAB01300clientWrapper.R_ServiceGetRecordAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB01300DTO> SaveCategoryAsync(SAB01300DTO poParam, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();
            SAB01300DTO loResult = null;

            try
            {
                loResult = await _SAB01300clientWrapper.R_ServiceSaveAsync(poParam, poCRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteCategoryAsync(SAB01300DTO poParam)
        {
            var loEx = new R_Exception();

            try
            {
                await _SAB01300clientWrapper.R_ServiceDeleteAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<List<SAB01300DTO>> GetCategoryListAsync()
        {
            var loEx = new R_Exception();
            List<SAB01300DTO> loResult = null;

            try
            {
                var loCategories = await _SAB01300clientWrapper.GetAllCategoryAsync();
                loResult = loCategories.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
        #endregion

        #region SAB01310
        public async Task<SAB01310DTO> GetProduct(SAB01310DTO poParam)
        {
            var loEx = new R_Exception();
            SAB01310DTO loResult = null;

            try
            {
                loResult = await _SAB01310clientWrapper.R_ServiceGetRecordAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB01310DTO> SaveProduct(SAB01310DTO poParam, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();
            SAB01310DTO loResult = null;

            try
            {
                loResult = await _SAB01310clientWrapper.R_ServiceSaveAsync(poParam, poCRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteProduct(SAB01310DTO poParam)
        {
            var loEx = new R_Exception();

            try
            {
                await _SAB01310clientWrapper.R_ServiceDeleteAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<List<SAB01310DTO>> GetProductList()
        {
            var loEx = new R_Exception();
            List<SAB01310DTO> loResult = null;

            try
            {
                var loProducts = await _SAB01310clientWrapper.GetAllProductAsync();
                loResult = loProducts.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<List<SAB01310DTO>> GetProductListByCategory(int piCategoryId)
        {
            var loEx = new R_Exception();
            List<SAB01310DTO> loResult = null;

            try
            {
                var loProducts = await _SAB01310clientWrapper.GetAllProductByCategoryAsync(piCategoryId);
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
