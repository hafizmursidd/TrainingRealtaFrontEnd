using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00900Common;
using SAB00900Common.DTOs;
using System;
using System.Threading.Tasks;

namespace SAB00900Model
{
    public class SAB00900Model : R_BusinessObjectServiceClientBase<SAB00900DTO>, ISAB00900
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00900";

        public SAB00900Model(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = false)
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        #region GetAllProduct

        public SAB00900ListDTO<SAB00900DTO> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00900ListDTO<SAB00900DTO>> GetAllProductAsync()
        {
            var loEx = new R_Exception();
            SAB00900ListDTO<SAB00900DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00900ListDTO<SAB00900DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00900.GetAllProduct),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        #endregion

        #region GetAllCategory

        public SAB00900ListDTO<SAB00900CategoryDTO> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00900ListDTO<SAB00900CategoryDTO>> GetAllCategoryAsync()
        {
            var loEx = new R_Exception();
            SAB00900ListDTO<SAB00900CategoryDTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00900ListDTO<SAB00900CategoryDTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00900.GetAllCategory),
                    _SendWithContext,
                    _SendWithToken);
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