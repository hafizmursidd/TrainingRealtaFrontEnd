using R_APICommonDTO;
using R_CommonFrontBackAPI;
using R_ProcessAndUploadFront;

namespace ProcessConsole;

public class ProcessStatus : R_IProcessProgressStatus
{
    public string CompanyId { get; set; }
    public string UserId { get; set; }
    public async Task ProcessComplete(string pcKeyGuid, eProcessResultMode poProcessResultMode)
    {
        if(poProcessResultMode == eProcessResultMode.Success)
        {
            Console.WriteLine($"Process Complete Succes with GUID {pcKeyGuid} ");
        }
        else
        {
            Console.WriteLine($"Process Complete Fail with GUID {pcKeyGuid} ");
            await GetError(pcKeyGuid);
        }
            
    }

    public  Task ProcessError(string pcKeyGuid, R_APIException ex)
    {
        Console.WriteLine($"Process Fail with GUID {pcKeyGuid} ");
        foreach (R_Error item in ex.ErrorList)
        {
            Console.WriteLine(item.ErrDescp);
        }

        return Task.CompletedTask;
    }

    public Task ReportProgress(int pnProgress, string pcStatus)
    {
        Console.WriteLine($"Step {pnProgress} with status {pcStatus}");
        return Task.CompletedTask;
    }

    private async Task GetError(string pcKeyGuid)
    {
        R_APIException loException;
        R_ProcessAndUploadClient loCls;
        List<R_ErrorStatusReturn> loErrStatusRtn;
            
        try
        {
            loCls = new R_ProcessAndUploadClient(plSendWithContext: false, plSendWithToken: false);
            loErrStatusRtn = await loCls.R_GetErrorProcess(new R_UploadAndProcessKey() { COMPANY_ID = this.CompanyId, USER_ID = this.UserId, KEY_GUID = pcKeyGuid });
            foreach (R_ErrorStatusReturn item in loErrStatusRtn)
            {
                Console.WriteLine($"Error Seqno {item.SeqNo} with error {item.ErrorMessage}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}