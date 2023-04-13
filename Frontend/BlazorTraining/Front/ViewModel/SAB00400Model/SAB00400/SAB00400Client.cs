using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00400Common;
using System.Threading.Tasks;
using System;

namespace SAB00400
{
    public class SAB00400Client : R_BusinessObjectServiceClientBase<SAB00400DTO>, ISAB00400
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB01300";
        public SAB00400Client(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00400ListDTO<SAB00400DTO> GetAllRegion()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SAB00400ListDTO<SAB00400DTO>> GetAllRegionAsync()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00400DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00400DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00400.GetAllRegion),
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
    }
}
