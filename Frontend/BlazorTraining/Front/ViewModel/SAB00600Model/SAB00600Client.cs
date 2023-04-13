using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00600Common;
using SAB00600Common.DTOs;
using System;
using System.Threading.Tasks;

namespace SAB00600Model
{
    public class SAB00600Client : R_BusinessObjectServiceClientBase<SAB00600DTO>, ISAB00600
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00600";

        public SAB00600Client(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        #region GetAllCustomer
        public SAB00600ListDTO GetAllCustomer()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SAB00600ListDTO> GetAllCustomerAsync()
        {
            var loEx = new R_Exception();
            SAB00600ListDTO loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00600ListDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00600.GetAllCustomer),
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
