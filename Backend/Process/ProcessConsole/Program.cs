using System;
using ProcessCommon;
using R_APIClient;
using R_APICommonDTO;
using R_CommonFrontBackAPI;
using R_ProcessAndUploadFront;

namespace ProcessConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static HttpClient loHttpClient;
        private static R_HTTPClient loClient;

        static void Main(string[] args)
        {
            R_APIException loException = new R_APIException();
            try
            {
                loHttpClient = new HttpClient();
                loHttpClient.BaseAddress = new Uri("http://localhost:5298");
                R_HTTPClient.R_CreateInstanceWithName("DEFAULT", loHttpClient);
                loClient = R_HTTPClient.R_GetInstanceWithName("DEFAULT");

                //Task.Run(() => ServiceAttachFile());
                //Task.Run(() => ServiceProcess());
                Task.Run(() => ServiceSaveBatchWithBulkCopy(false));
            }
            catch (Exception ex)
            {
                loException.add(ex);
            }


            Console.ReadKey();
        }

        static async Task ServiceAttachFile()
        {
            R_APIException loException = new R_APIException();
            List<R_KeyValue> loUserParameters;
            R_UploadPar loUploadPar;
            R_ProcessAndUploadClient loCls;

            R_IProcessProgressStatus loProgressStatus;
            try
            {
                //persiapkan User Par
                loUserParameters = new List<R_KeyValue>();
                loUserParameters.Add(new R_KeyValue() { Key = ProcessConstant.EMPLOYEE_ID, Value = "Employee01" });

                //Persiapkan UploadPar
                loUploadPar = new R_UploadPar();
                loUploadPar.UserParameters = loUserParameters;


                loUploadPar.USER_ID = "User01";
                loUploadPar.COMPANY_ID = "C001";
                loUploadPar.ClassName = "ProcessBack.AttachFileCls";

                loUploadPar.FilePath = $@"D:\VS2022\Training\Latihan\ProcessAndUpload\Data\Test1.pdf";
                loUploadPar.File = new R_File();
                loUploadPar.File.FileId = System.IO.Path.GetFileNameWithoutExtension(loUploadPar.FilePath);
                loUploadPar.File.FileDescription = $"Description of {loUploadPar.File.FileId}";
                loUploadPar.File.FileExtension = System.IO.Path.GetExtension(loUploadPar.FilePath);

                //Progress Status
                loProgressStatus = new ProcessStatus();

                //Persiapkan Process Class
                loCls = new R_ProcessAndUploadClient(poProcessProgressStatus: loProgressStatus,
                    plSendWithContext: false, plSendWithToken: false);


                await loCls.R_AttachFile<Object>(loUploadPar);
            }
            catch (Exception ex)
            {
                loException.add(ex);
            }

            EndBlock:
            loException.ThrowExceptionIfErrors();
        }

        static async Task ServiceProcess()
        {
            R_APIException loException = new R_APIException();
            List<R_KeyValue> loUserParameters;
            R_BatchParameter loBatchPar;
            R_ProcessAndUploadClient loCls;

            R_IProcessProgressStatus loProgressStatus;

            string lcGuid;
            try
            {
                //persiapkan User Par
                loUserParameters = new List<R_KeyValue>();
                loUserParameters.Add(new R_KeyValue() { Key = ProcessConstant.LOOP, Value = 10 });
                loUserParameters.Add(new R_KeyValue() { Key = ProcessConstant.IS_ERROR, Value = true });
                loUserParameters.Add(new R_KeyValue() { Key = ProcessConstant.IS_ERROR_STATEMENT, Value = false });

                //Persiapkan UploadPar
                loBatchPar = new R_BatchParameter();
                loBatchPar.UserParameters = loUserParameters;


                loBatchPar.USER_ID = "User01";
                loBatchPar.COMPANY_ID = "C001";
                loBatchPar.ClassName = "ProcessBack.BatchProcessCls";


                //Progress Status
                loProgressStatus = new ProcessStatus();
                ((ProcessStatus)loProgressStatus).CompanyId = loBatchPar.COMPANY_ID;
                ((ProcessStatus)loProgressStatus).UserId = loBatchPar.USER_ID;

                //Persiapkan Process Class
                loCls = new R_ProcessAndUploadClient(poProcessProgressStatus: loProgressStatus,
                    plSendWithContext: false, plSendWithToken: false);


                lcGuid = await loCls.R_BatchProcess<Object>(loBatchPar, 10);

                Console.WriteLine($"Process with return GUID {lcGuid}");
            }
            catch (Exception ex)
            {
                loException.add(ex);
            }

            EndBlock:
            loException.ThrowExceptionIfErrors();
        }

        private static async Task ServiceSaveBatchWithBulkCopy(bool plGenerateErrorData)
        {
            R_APIException loException = new R_APIException();
            R_BatchParameter loBatchPar;
            List<EmployeeDTO> loBigObject;
            R_ProcessAndUploadClient loCls;

            R_IProcessProgressStatus loProgressStatus;


            string lcRtn;

            try
            {
                // Kirim Data ke Big Object
                loBigObject = GenerateEmployeeData("01", 100, plGenerateErrorData);

                loProgressStatus = new ProcessStatus();

                // Instantiate ProcessClient
                loCls = new R_ProcessAndUploadClient(poProcessProgressStatus: loProgressStatus,
                    plSendWithContext: false, plSendWithToken: false);

                // preapare Batch Parameter
                loBatchPar = new R_BatchParameter();

                loBatchPar.COMPANY_ID = "01";
                loBatchPar.USER_ID = "GY";
                loBatchPar.ClassName = "ProcessBack.SaveBatchWithBulkCopyCls";
                loBatchPar.BigObject = loBigObject;

                //Initial For Error Report
                ((ProcessStatus)loProgressStatus).CompanyId = loBatchPar.COMPANY_ID;
                ((ProcessStatus)loProgressStatus).UserId = loBatchPar.USER_ID;


                lcRtn = await loCls.R_BatchProcess<List<EmployeeDTO>>(loBatchPar, 100);
            }
            catch (Exception ex)
            {
                loException.add(ex);
            }

            EndBlock:
            loException.ThrowExceptionIfErrors();
        }

        private static List<EmployeeDTO> GenerateEmployeeData(string pcCoId, int pnTotalEmployee,
            bool plGenerateErrorData)
        {
            List<EmployeeDTO> loRtn = new List<EmployeeDTO>();
            string lcSex;

            for (var lnCount = 1; lnCount <= pnTotalEmployee; lnCount++)
            {
                if (plGenerateErrorData && lnCount == 3)
                    lcSex = "D";
                else if ((lnCount % 2) == 0)
                {
                    lcSex = "M";
                }
                else
                {
                    lcSex = "F";
                }

                loRtn.Add(new EmployeeDTO()
                {
                    CompanyId = pcCoId.Trim(),
                    EmployeeId = string.Format("Emp{0}", lnCount.ToString("00000")),
                    FirstName = string.Format("Employee {0}", lnCount.ToString("00000")),
                    LastName = string.Format("Last Name {0}", lnCount.ToString("00000")),
                    SeqNo = lnCount,
                    SexId = lcSex,
                    TotalChildren = (lnCount % 3)
                });
            }


            return loRtn;
        }
    }
}