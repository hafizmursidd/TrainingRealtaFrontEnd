using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB01300Common;
using SAB01300Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB01300Model
{
    public class SAB01310Client : R_BusinessObjectServiceClientBase<SAB01310DTO>, ISAB01310
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB01310";

        public SAB01310Client(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true)
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        #region GetAllProduct
        public SAB01300ListDTO<SAB01310DTO> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB01300ListDTO<SAB01310DTO>> GetAllProductAsync()
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01310DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB01300ListDTO<SAB01310DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB01310.GetAllProduct),
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

        #region GetAllProductByCategory
        public SAB01300ListDTO<SAB01310DTO> GetAllProductByCategory(int piCategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<SAB01300ListDTO<SAB01310DTO>> GetAllProductByCategoryAsync(int piCategoryId)
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01310DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB01300ListDTO<SAB01310DTO>, int>(
                    _RequestServiceEndPoint,
                    nameof(ISAB01310.GetAllProductByCategory),
                    piCategoryId,
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

        public IAsyncEnumerable<SAB01310DTO> GetAllProductByCategoryStream()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<SAB01310DTO> GetAllProductStream()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
