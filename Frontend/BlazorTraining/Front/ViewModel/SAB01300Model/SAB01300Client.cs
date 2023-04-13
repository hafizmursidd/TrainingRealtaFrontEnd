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
    public class SAB01300Client : R_BusinessObjectServiceClientBase<SAB01300DTO>, ISAB01300
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB01300";

        public SAB01300Client(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        #region GetAllCategory
        public SAB01300ListDTO<SAB01300DTO> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB01300ListDTO<SAB01300DTO>> GetAllCategoryAsync()
        {
            var loEx = new R_Exception();
            SAB01300ListDTO<SAB01300DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB01300ListDTO<SAB01300DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB01300.GetAllCategory),
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

        public IAsyncEnumerable<SAB01300DTO> GetAllCategoryStream()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
