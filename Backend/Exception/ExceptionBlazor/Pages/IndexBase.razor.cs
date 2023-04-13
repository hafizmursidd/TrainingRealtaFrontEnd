using Microsoft.AspNetCore.Components;
using System;
using ExceptionCommon;
using R_APIClient;
using R_APICommonDTO;

namespace ExceptionBlazor.Pages
{
    public class IndexBase : ComponentBase, R_INotify<CustomerStreamDTO>
    {
        public List<CustomerStreamDTO> customers = new List<CustomerStreamDTO>();
        public string lcStatusMessage = "";
        public string lcCustomerCount = "5";

        public void Notify(CustomerStreamDTO poEntity)
        {
            customers.Add(poEntity);
            StateHasChanged();
        }

        public async Task StreamCustomer()
        {
            R_HTTPClient httpClient;
            GetCustomersParameterDTO loParameter;
            try
            {
                lcStatusMessage = "";
                customers = new List<CustomerStreamDTO>();
                StateHasChanged();

                loParameter = new GetCustomersParameterDTO();
                loParameter.CustomerCount = int.Parse(lcCustomerCount);

                httpClient = R_HTTPClient.R_GetInstanceWithName("DEFAULT");

                // customers = await R_HTTPClientWrapper.R_APIRequestStreamingObject<CustomerStreamDTO, GetCustomersParameterDTO>("api/Exception", nameof(ICustomer.GetCustomersList), loParameter, plSendWithContext: false, plSendWithToken: false);

                _ = await R_HTTPClientWrapper.R_APIRequestStreamingObject<CustomerStreamDTO, GetCustomersParameterDTO>("api/Exception", nameof(ICustomer.GetCustomersList), loParameter, plSendWithContext: false, plSendWithToken: false, poNotify:this);


                //_ = await httpClient.R_APIRequestStreamingObject<Person>(pcRequest: "api/HugeData/GetAsyncPerson",
                //                                                 peAPIMethod: R_HTTPClient.E_APIMethod.GET_MODE,
                //                                                 poQueryString: loParameters,
                //                                                 plSendWithContext: false, poNotify: this);

                StateHasChanged();
            }
            catch (Exception ex)
            {
                var exceptions = ex as R_IException;
                lcStatusMessage = exceptions.ErrorList.First().ErrDescp;
                StateHasChanged();

            }

        }

    }
}
