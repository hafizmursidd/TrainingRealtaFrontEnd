using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using SAB00100Common;
using SAB00100Common.DTOs;

namespace SAB00100Model
{
    public class SAB00100Model: R_BusinessObjectServiceClientBase<SAB00100DTO>, ISAB00100
    {
        private const string DEFAULT_HTTP = "R_DefaultServiceUrl";
        private const string DEFAULT_ENDPOINT = "api/SAB00100";
        
        public SAB00100Model(
            string pcHttpClientName = DEFAULT_HTTP, 
            string pcRequestServiceEndPoint = DEFAULT_ENDPOINT, 
            bool plSendWithContext = true, 
            bool plSendWithToken = true) 
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public SAB00100ListEmployeeOriginalDTO GetAllEmployeeOriginal()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00100ListEmployeeDTO> GetAllEmployeeAsync()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeDTO loResult = null;
            
            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00100ListEmployeeDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00100.GetAllEmployee),
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

        public IAsyncEnumerable<SAB00100DTO> GetAllEmployeeStream()
        {
            throw new NotImplementedException();
        }
    }
}