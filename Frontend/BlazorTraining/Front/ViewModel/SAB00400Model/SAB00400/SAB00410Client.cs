using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00400Common;
using System.Threading.Tasks;
using System;

namespace SAB00400
{
    public class SAB00410Client : R_BusinessObjectServiceClientBase<SAB00410DTO>, ISAB00410
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00410";

        public SAB00410Client(string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = false)
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00400ListDTO<SAB00410DTO> GetAllTerritory()
        {
            throw new System.NotImplementedException();
        }

        public async Task<SAB00400ListDTO<SAB00410DTO>> GetAllTerritoryAsync()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00410DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritory),
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

        public SAB00400ListDTO<SAB00410DTO> GetAllTerritoryByRegion(int piTerritoryId)
        {
            throw new System.NotImplementedException();
        }
        public async Task<SAB00400ListDTO<SAB00410DTO>> GetAllTerritoryByRegionIdAsync(int piCategoryId)
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00410DTO>, int>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritoryByRegion),
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
    }
}
