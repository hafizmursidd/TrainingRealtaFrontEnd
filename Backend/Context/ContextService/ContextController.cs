using ContextBack;
using ContextCommon;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;

namespace ContextService;

[Route("api/[controller]/[action]")]
[ApiController]
public class ContextController : ControllerBase, IContextProgram
{
    [HttpPost]
    public IAsyncEnumerable<SalesStreamDTO> GetSalesList()
    {
        R_Exception loException = new R_Exception();
        ProgramContextDTO loProgramContext;
        GetSalesListContextDTO loContextParameter;
        GetSalesListDbParameterDTO loBackParameter = null;

        try
        {
            loProgramContext = R_Utility.R_GetContext<ProgramContextDTO>(ContextConstant.PROGRAM_CONTEXT);
            loContextParameter =
                R_Utility.R_GetStreamingContext<GetSalesListContextDTO>(ContextConstant.SALES_STREAM_CONTEXT);

            loBackParameter = new GetSalesListDbParameterDTO();
            loBackParameter.CompanyId = R_BackGlobalVar.COMPANY_ID;
            loBackParameter.DepartmentId = loProgramContext.DepartmentId;
            loBackParameter.SalesCount = loContextParameter.SalesCount;
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();

        return GetSalesList(loBackParameter);
    }

    private async IAsyncEnumerable<SalesStreamDTO> GetSalesList(GetSalesListDbParameterDTO poParameter)
    {
        ContextCls loCls = new ContextCls();
        List<SalesStreamDTO> loSalesList = loCls.GetSalesListDb(poParameter);
        foreach (SalesStreamDTO item in loSalesList)
        {
            await Task.Delay(1000);
            yield return item;
        }
    }

    [HttpPost]
    public IAsyncEnumerable<OrderStreamDTO> GetOrderList()
    {
        R_Exception loException = new R_Exception();
        ProgramContextDTO loProgramContext;
        GetOrderListContextDTO loContextParameter;
        GetOrderListDbParameterDTO loBackParameter = null;

        try
        {
            loProgramContext = R_Utility.R_GetContext<ProgramContextDTO>(ContextConstant.PROGRAM_CONTEXT);
            loContextParameter = R_Utility.R_GetStreamingContext<GetOrderListContextDTO>(ContextConstant.ORDER_STREAM_CONTEXT);
            
            loBackParameter = new GetOrderListDbParameterDTO();
            loBackParameter.CompanyId = R_BackGlobalVar.COMPANY_ID;
            loBackParameter.DepartmentId = loProgramContext.DepartmentId;
            loBackParameter.SalesId = loContextParameter.SalesId;
            loBackParameter.OrderCount = loContextParameter.OrderCount;
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();

        return GetOrderList(loBackParameter);
    }

    private async IAsyncEnumerable<OrderStreamDTO> GetOrderList(GetOrderListDbParameterDTO poParameter)
    {
        ContextCls loCls = new ContextCls();
        List<OrderStreamDTO> loOrderList = loCls.GetOrderListDb(poParameter);
        foreach (OrderStreamDTO item in loOrderList)
        {
            await Task.Delay(1000);
            yield return item;
        }
    }
}