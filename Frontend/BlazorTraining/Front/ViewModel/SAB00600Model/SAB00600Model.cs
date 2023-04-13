using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00600Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB00600Model
{
    public class SAB00600Model
    {
        private SAB00600Client _clientWrapper = null;

        public SAB00600Model()
        {
            _clientWrapper = new SAB00600Client();
        }

        public async Task<SAB00600DTO> GetCustomerAsync(SAB00600DTO poParam)
        {
            var loEx = new R_Exception();
            SAB00600DTO loResult = null;

            try
            {
                loResult = await _clientWrapper.R_ServiceGetRecordAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB00600DTO> SaveCustomerAsync(SAB00600DTO poParam, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();
            SAB00600DTO loResult = null;

            try
            {
                loResult = await _clientWrapper.R_ServiceSaveAsync(poParam, poCRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteCustomerAsync(SAB00600DTO poParam)
        {
            var loEx = new R_Exception();

            try
            {
                await _clientWrapper.R_ServiceDeleteAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<List<SAB00600DTO>> GetCustomerListAsync()
        {
            var loEx = new R_Exception();
            List<SAB00600DTO> loResult = null;

            try
            {
                var loCategories = await _clientWrapper.GetAllCustomerAsync();
                loResult = loCategories.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
    }
}
