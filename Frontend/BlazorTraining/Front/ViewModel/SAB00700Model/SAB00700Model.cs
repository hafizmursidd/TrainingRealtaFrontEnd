using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00700Common;
using SAB00700Common.DTOs;
using System;
using System.Threading.Tasks;

namespace SAB00700Model
{
    public class SAB00700Model : R_BusinessObjectServiceClientBase<SAB00700DTO>, ISAB00700
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00700";

        public SAB00700Model(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = false) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        #region GetAllCategory
        public SAB00700ListDTO GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00700ListDTO> GetAllCategoryAsync()
        {
            var loEx = new R_Exception();
            SAB00700ListDTO loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00700ListDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00700.GetAllCategory),
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