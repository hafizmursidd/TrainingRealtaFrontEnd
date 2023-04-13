using CRUDBack;
using CRUDCommon;
using Microsoft.AspNetCore.Mvc;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

namespace CRUDService;

[Route("api/[controller]/[action]")]
[ApiController]
public class CRUDController : ControllerBase, ICRUD
{
    [HttpPost]
    public IAsyncEnumerable<CustomerStreamDTO> CustomerList()
    {
        R_Exception loException = new R_Exception();
        CustomerListDBParameterDTO loDbPar;
        List<CustomerStreamDTO> loRtnTmp;
        CRUDCls loCls;
        IAsyncEnumerable<CustomerStreamDTO> loRtn =null;

        try
        {
            loDbPar = new CustomerListDBParameterDTO();
            loDbPar.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;

            loCls = new CRUDCls();
            loRtnTmp = loCls.CustomerListDb(loDbPar);

            loRtn = GetCustomerStream(loRtnTmp);
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
    public R_ServiceGetRecordResultDTO<CustomerDTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<CustomerDTO> poParameter)
    {
        R_Exception loException = new R_Exception();
        R_ServiceGetRecordResultDTO<CustomerDTO> loRtn = null;        
        CRUDCls loCls;
        
        try
        {
            loCls = new CRUDCls();
            loRtn = new R_ServiceGetRecordResultDTO<CustomerDTO>();
            // poParameter.Entity.CCOMPANY_ID = R_BackGlobalVar.COMPANY_ID;
            loRtn.data = loCls.R_GetRecord(poParameter.Entity);
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
    public R_ServiceSaveResultDTO<CustomerDTO> R_ServiceSave(R_ServiceSaveParameterDTO<CustomerDTO> poParameter)
    {
        R_Exception loException = new R_Exception();
        R_ServiceSaveResultDTO<CustomerDTO> loRtn = null;
        CRUDCls loCls;

        try
        {
            loCls = new CRUDCls();
            loRtn = new R_ServiceSaveResultDTO<CustomerDTO>();
            loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
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
    public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<CustomerDTO> poParameter)
    {
        R_Exception loException = new R_Exception();
        R_ServiceDeleteResultDTO loRtn = null;
        CRUDCls loCls;
        try
        {
            loCls = new CRUDCls();
            loRtn = new R_ServiceDeleteResultDTO();
            loCls.R_Delete(poParameter.Entity);
        }
        catch (Exception ex)
        {
            loException.Add(ex); 
        }
        
        EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

    private async IAsyncEnumerable<CustomerStreamDTO> GetCustomerStream(List<CustomerStreamDTO> poParameter)
    {
        foreach (CustomerStreamDTO item in poParameter)
        {
            yield return item;
        }
    }
}