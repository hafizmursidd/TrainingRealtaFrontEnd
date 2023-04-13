using System;
using ContextCommon;
using R_APIClient;
using R_ContextEnumAndInterface;
using R_ContextFrontEnd;

namespace ContextConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static HttpClient loHttpClient = null;
        static R_ContextHeader loContextHeader;

        static void Main(string[] args)
        {
            loHttpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5097/")
            };
            loContextHeader = new R_ContextHeader();
            loContextHeader.R_Context._SetInternalContext(R_InternalContextVarEnumerator.COMPANY_ID, "GOA");

            R_HTTPClient.R_CreateInstanceWithName("DEFAULT", loHttpClient, loContextHeader);
            
            Task.Run(() => GetSalesAsync());
            // Task.Run(() => GetOrderAsync());
            Console.ReadKey();
        }

        private static async Task GetSalesAsync()
        {
            ProgramContextDTO loProgramContext;
            GetSalesListContextDTO loGetSalesListContextDTO;
            List<SalesStreamDTO> loSalesList;
            NotifySales loNotifySales;
            // R_HTTPClient loClient;

            try
            {
                //siapkan rogram context
                loProgramContext = new ProgramContextDTO()
                {
                    DepartmentId = "RnD"
                };
                loContextHeader.R_Context.R_SetContext(ContextConstant.PROGRAM_CONTEXT, loProgramContext);

                //siapkan stream context
                loGetSalesListContextDTO = new GetSalesListContextDTO()
                {
                    SalesCount = 10
                };
                loContextHeader.R_Context.R_SetStreamingContext(ContextConstant.SALES_STREAM_CONTEXT, loGetSalesListContextDTO);

                loNotifySales = new NotifySales();
                loSalesList = await R_HTTPClientWrapper.R_APIRequestStreamingObject<SalesStreamDTO>("api/Context", nameof(IContextProgram.GetSalesList), plSendWithContext: true, plSendWithToken: false, poNotify:loNotifySales);
                
                // loSalesList = await R_HTTPClientWrapper.R_APIRequestStreamingObject<SalesStreamDTO>("api/Context", nameof(IContextProgram.GetSalesList), plSendWithContext: true, plSendWithToken: false, poNotify:null);
                // foreach (SalesStreamDTO item in loSalesList)
                // {
                //     Console.WriteLine($"Sales ID: {item.SalesId}, Sales Name: {item.SalesName}");
                // }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        private static async Task GetOrderAsync()
        {
            ProgramContextDTO loProgramContext;
            GetOrderListContextDTO loGetOrderListContextDTO;
            List<OrderStreamDTO> loOrderList;
            // R_HTTPClient loClient;

            try
            {
                //siapkan rogram context
                loProgramContext = new ProgramContextDTO()
                {
                    DepartmentId = "RnD"
                };
                loContextHeader.R_Context.R_SetContext(ContextConstant.PROGRAM_CONTEXT, loProgramContext);

                //siapkan stream context
                loGetOrderListContextDTO = new GetOrderListContextDTO()
                {
                    SalesId = "S-1",
                    OrderCount = 10
                };
                loContextHeader.R_Context.R_SetStreamingContext(ContextConstant.ORDER_STREAM_CONTEXT, loGetOrderListContextDTO);

                loOrderList = await R_HTTPClientWrapper.R_APIRequestStreamingObject<OrderStreamDTO>("api/Context", nameof(IContextProgram.GetOrderList), plSendWithContext: true, plSendWithToken: false);
                foreach (OrderStreamDTO item in loOrderList)
                {
                    Console.WriteLine($"Sales ID: {item.SalesId}, Order ID: {item.OrderId}, Order Date: {item.OrderDate}");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}