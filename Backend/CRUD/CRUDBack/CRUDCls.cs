using System.Data;
using System.Data.Common;
using CRUDCommon;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;

namespace CRUDBack;

public class CRUDCls : R_BusinessObject<CustomerDTO>
{
    public List<CustomerStreamDTO> CustomerListDb(CustomerListDBParameterDTO poParameter)
    {
        R_Exception loException = new R_Exception();
        List<CustomerStreamDTO> loRtn = null;
        string lcCmd;
        R_Db loDb;

        try
        {
            lcCmd = "SELECT CCOMPANY_ID, CustomerID, CustomerName "
                    + "FROM TrainCustomer(nolock) "
                    + "WHERE CCOMPANY_ID = {0}";
            loDb = new R_Db();
            loRtn = loDb.SqlExecObjectQuery<CustomerStreamDTO>(lcCmd, poParameter.CCOMPANY_ID);
            //{0} pada lcCmd akan diganti dengan nilai dari poParameter.CCOMPANY_ID
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

    protected override CustomerDTO R_Display(CustomerDTO poEntity)
    {
        R_Exception loException = new R_Exception();
        CustomerDTO loRtn = null;
        string lcCmd;
        R_Db loDb;
        try
        {
            lcCmd = "SELECT * FROM TrainCustomer(nolock) "
                    + "WHERE CCOMPANY_ID = {0} "
                    + "AND CustomerID = {1}";
            loDb = new R_Db();
            loRtn = loDb.SqlExecObjectQuery<CustomerDTO>(lcCmd, poEntity.CCOMPANY_ID, poEntity.CustomerID)
                .FirstOrDefault();
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

    protected override void R_Saving(CustomerDTO poNewEntity, eCRUDMode poCRUDMode)
    {
        R_Exception loException = new R_Exception();
        CustomerDTO loTempEntity = null;
        string lcCmd = "";
        R_Db loDb;
        DbCommand loCommand;
        DbConnection loConn = null;
        try
        {
            loDb = new R_Db();
            loConn = loDb.GetConnection();
            
            lcCmd = "SELECT CCOMPANY_ID FROM TrainCustomer(updlock) " 
                  + "WHERE CCOMPANY_ID = {0} " 
                  + "AND CustomerID = {1}";
            
            loTempEntity = loDb.SqlExecObjectQuery<CustomerDTO>(lcCmd, poNewEntity.CCOMPANY_ID, poNewEntity.CustomerID)
                .FirstOrDefault();
    
            switch (poCRUDMode)
            {
                case eCRUDMode.AddMode:
                    if (loTempEntity != null)
                    {
                         loException.Add("001", R_Utility.R_GetMessage("CRUDBackResources", "001"));
                         goto EndBlock;
                    }
                    lcCmd = "INSERT INTO TrainCustomer(CCOMPANY_ID, CustomerID, CustomerName, ContactName) "
                          + "VALUES(@CCOMPANY_ID, @CustomerID, @CustomerName, @ContactName)";
    
                    break;
                case eCRUDMode.EditMode:
                    if (loTempEntity == null)
                    {
                        loException.Add("002", R_Utility.R_GetMessage("CRUDBackResources", "002"));
                        goto EndBlock;
                    }
    
                    lcCmd = "UPDATE TrainCustomer "
                            + "SET CustomerName = @CustomerName, "
                            + "ContactName = @ContactName "
                            + "WHERE CCOMPANY_ID = @CCOMPANY_ID "
                            + "AND CustomerID = @CustomerID";
                    break;
            }
    
            loCommand = loDb.GetCommand();
            loCommand.CommandText = lcCmd;
            
            loDb.R_AddCommandParameter(loCommand, "@CCOMPANY_ID", DbType.String, 10, poNewEntity.CCOMPANY_ID);
            loDb.R_AddCommandParameter(loCommand, "@CustomerID", DbType.String, 10, poNewEntity.CustomerID);
            loDb.R_AddCommandParameter(loCommand, "@CustomerName", DbType.String, 50, poNewEntity.CustomerName);
            loDb.R_AddCommandParameter(loCommand, "@ContactName", DbType.String, 10, poNewEntity.ContactName);
            
            loDb.SqlExecNonQuery(loConn, loCommand, true);
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        finally
        {
            if (loConn != null)
            {
                if (loConn.State == ConnectionState.Closed)
                {
                    loConn.Close();
                }
    
                loConn.Dispose();
            }
        }
    
        EndBlock:
        loException.ThrowExceptionIfErrors();
    }

    protected override void R_Deleting(CustomerDTO poEntity)
    {
        R_Exception loException = new R_Exception();
        string lcCmd = "";
        CustomerDTO loTempEntity = null;
        R_Db loDb;
        DbCommand loCommand;
        try
        {
            loDb = new R_Db();
            lcCmd = "SELECT CCOMPANY_ID FROM TrainCustomer(updlock) " 
                    + "WHERE CCOMPANY_ID = {0} " 
                    + "AND CustomerID = {1}";
            
            loTempEntity = loDb.SqlExecObjectQuery<CustomerDTO>(lcCmd, poEntity.CCOMPANY_ID, poEntity.CustomerID)
                .FirstOrDefault();
            
            if(loTempEntity == null)
            {
                loException.Add("002", R_Utility.R_GetMessage("CRUDBackResources", "002"));
                goto EndBlock;
            }
            
            lcCmd = "DELETE FROM TrainCustomer "
                   + "WHERE CCOMPANY_ID = @CCOMPANY_ID "
                   + "AND CustomerID = @CustomerID";
            loCommand = loDb.GetCommand();
            loCommand.CommandText = lcCmd;
            
            loDb.R_AddCommandParameter(loCommand, "@CCOMPANY_ID", DbType.String, 10, poEntity.CCOMPANY_ID);
            loDb.R_AddCommandParameter(loCommand, "@CustomerID", DbType.String, 10, poEntity.CustomerID);
            
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