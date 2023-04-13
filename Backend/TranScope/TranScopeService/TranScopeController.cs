using Microsoft.AspNetCore.Mvc;
using R_Common;
using TranScopeBack;
using TranScopeCommon;

namespace TranScopeService;

[Route("api/[controller]/[action]")]
[ApiController]
public class TranScopeController : ControllerBase, ITranScope
{
    [HttpPost]
    public TranScopeResultDTO ProcessWithoutTransaction(int poProcessRecordCount)
    {
        R_Exception loException = new R_Exception();
        TranScopeCls loCls;
        TranScopeResultDTO loRtn = null;

        try
        {
            loCls = new TranScopeCls();
            loRtn = new TranScopeResultDTO();
            loRtn.data = loCls.ProcessWithoutTransactionDB(poProcessRecordCount);
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        
        EndBlock:
        loException.ThrowExceptionIfErrors();
        
        return loRtn;
    }
    
    [HttpPost]
    public TranScopeResultDTO ProcessAllWithTransaction(int poProcessRecordCount)
    {
        R_Exception loException = new R_Exception();
        TranScopeCls loCls;
        TranScopeResultDTO loRtn = null;

        try
        {
            loCls = new TranScopeCls();
            loRtn = new TranScopeResultDTO();
            loRtn.data = loCls.ProcessAllWithTransactionDB(poProcessRecordCount);
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        
        EndBlock:
        loException.ThrowExceptionIfErrors();
        
        return loRtn;
    }
    
    [HttpPost]
    public TranScopeResultDTO ProcessEachTransaction(int poProcessRecordCount)
    {
        R_Exception loException = new R_Exception();
        TranScopeCls loCls;
        TranScopeResultDTO loRtn = null;

        try
        {
            loCls = new TranScopeCls();
            loRtn = new TranScopeResultDTO();
            loRtn.data = loCls.ProcessEachTransactionDB(poProcessRecordCount);
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        
        EndBlock:
        loException.ThrowExceptionIfErrors();
        
        return loRtn;
    }
}