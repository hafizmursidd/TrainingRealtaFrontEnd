using System.Data;
using System.Data.Common;
using ProcessCommon;
using R_BackEnd;
using R_Common;

namespace ProcessBack;

public class AttachFileCls : R_IAttachFile
{
    public void R_AttachFile(R_AttachFilePar poAttachFile)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb;
        DbCommand loCommand;
        string lcCmd;
        string lcEmpId = "";
        try
        {
            //User parameter validation
            //harusadanuser parameter
            if (poAttachFile.UserParameters.Count > 0)
            {
                var loVar = poAttachFile.UserParameters.Where(x => x.Key.Equals(ProcessConstant.EMPLOYEE_ID))
                    .FirstOrDefault().Value;
                if (loVar == null)
                {
                    loException.Add("01", "Employee Id Parameter not found");
                    goto EndBlock;
                }

                lcEmpId = ((System.Text.Json.JsonElement)loVar).GetString();
                if (string.IsNullOrEmpty(lcEmpId))
                {
                    loException.Add("01", "Employee Id Parameter not found");
                    goto EndBlock;
                }
            }

            //versi parameter
            lcCmd =
                "Insert into TestEmployeeAttachment(CoId, EmpId, FileName, FileExtension, oData) Values(@CoId, @EmpId, @FileName, @FileExtension, dbo.RFN_CombineByte(@CoId,@UserId,@KeyGUID))";

            loDb = new R_Db();
            loCommand = loDb.GetCommand();
            loCommand.CommandText = lcCmd;
            loCommand.CommandType = CommandType.Text;

            loDb.R_AddCommandParameter(loCommand, "CoId", DbType.String, 50, poAttachFile.Key.COMPANY_ID);
            loDb.R_AddCommandParameter(loCommand, "EmpId", DbType.String, 50, lcEmpId);
            loDb.R_AddCommandParameter(loCommand, "FileName", DbType.String, 50, poAttachFile.File.FileId);
            loDb.R_AddCommandParameter(loCommand, "FileExtension", DbType.String, 50, poAttachFile.File.FileExtension);
            loDb.R_AddCommandParameter(loCommand, "UserId", DbType.String, 50, poAttachFile.Key.USER_ID);
            loDb.R_AddCommandParameter(loCommand, "KeyGUID", DbType.String, 50, poAttachFile.Key.KEY_GUID);

            loDb.SqlExecNonQuery(loDb.GetConnection(), loCommand, true);
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();
    }
}

// public class 