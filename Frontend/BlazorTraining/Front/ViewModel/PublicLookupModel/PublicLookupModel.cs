using PublicLookupCommon;
using PublicLookupCommon.DTOs;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using System;
using System.Threading.Tasks;

namespace PublicLookupModel
{
    public class PublicLookupModel : IPublicLookup
    {
        private const string DEFAULT_HTTP = "R_DefaultServiceUrl";
        private const string DEFAULT_ENDPOINT = "api/PublicLookup";

        #region GetAllEmployee
        public SALGenericListDTO<SAL00100DTO> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<SALGenericListDTO<SAL00100DTO>> GetAllEmployeeAsync()
        {
            var loEx = new R_Exception();
            SALGenericListDTO<SAL00100DTO> loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SALGenericListDTO<SAL00100DTO>>(
                    DEFAULT_ENDPOINT,
                    nameof(IPublicLookup.GetAllEmployee),
                    true,
                    false);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        #endregion

        #region GetAllCategory
        public SALGenericListDTO<SAL00200DTO> GetAllCategory()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SALGenericListDTO<SAL00200DTO>> GetAllCategoryAsync()
        {
            var loEx = new R_Exception();
            SALGenericListDTO<SAL00200DTO> loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SALGenericListDTO<SAL00200DTO>>(
                    DEFAULT_ENDPOINT,
                    nameof(IPublicLookup.GetAllCategory),
                    true,
                    false);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        #endregion

        #region GetAllProduct
        public SALGenericListDTO<SAL00300DTO> GetAllProduct()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SALGenericListDTO<SAL00300DTO>> GetAllProductAsync()
        {
            var loEx = new R_Exception();
            SALGenericListDTO<SAL00300DTO> loRtn = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SALGenericListDTO<SAL00300DTO>>(
                    DEFAULT_ENDPOINT,
                    nameof(IPublicLookup.GetAllProduct),
                    true,
                    false);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        #endregion
    }
}
