using GSM00200Back;
using GSM00200Common;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;

namespace GSM00200Service;

[Route("api/[controller]/[action]")]
[ApiController]
public class GSM00210Controller : IGSM00210
{
    [HttpPost]
    public IAsyncEnumerable<GSM00210DTOnon> GetTableDTList()
    {
        R_Exception loException = new R_Exception();
        IAsyncEnumerable<GSM00210DTOnon> loRtn = null;
        List<GSM00210DTOnon> loRtnTmp;
        GSM00210Cls loCls;
        string lcCompId;
        string lcTableId;

        try
        {
            lcCompId = R_Utility.R_GetStreamingContext<string>(GSM00200Constant.CCOMPANY_ID);
            lcTableId = R_Utility.R_GetStreamingContext<string>(GSM00200Constant.TABLE_ID);
            loCls = new GSM00210Cls();
            loRtnTmp = loCls.GetTableDTList(lcCompId, lcTableId);
            loRtn = GetGSM00210Stream(loRtnTmp);
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
    public R_ServiceGetRecordResultDTO<GSM00210DTO> R_ServiceGetRecord(
        R_ServiceGetRecordParameterDTO<GSM00210DTO> poParameter)
    {
        R_Exception loException = new R_Exception();
        R_ServiceGetRecordResultDTO<GSM00210DTO> loRtn = null;
        GSM00210Cls loCls;

        try
        {
            loCls = new GSM00210Cls();
            loRtn = new R_ServiceGetRecordResultDTO<GSM00210DTO>();
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
    public R_ServiceSaveResultDTO<GSM00210DTO> R_ServiceSave(R_ServiceSaveParameterDTO<GSM00210DTO> poParameter)
    {
        R_Exception loException = new R_Exception();
        R_ServiceSaveResultDTO<GSM00210DTO> loRtn = null;
        GSM00210Cls loCls;

        try
        {
            loCls = new GSM00210Cls();
            loRtn = new R_ServiceSaveResultDTO<GSM00210DTO>();
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
    public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<GSM00210DTO> poParameter)
    {
        R_Exception loException = new R_Exception();
        R_ServiceDeleteResultDTO loRtn = null;
        GSM00210Cls loCls;
        try
        {
            loCls = new GSM00210Cls();
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
    
    // This is the method that I want to implement
    private async IAsyncEnumerable<GSM00210DTOnon> GetGSM00210Stream(List<GSM00210DTOnon> poParameter)
    {
        foreach (GSM00210DTOnon item in poParameter)
        {
            yield return item;
        }
    }
}