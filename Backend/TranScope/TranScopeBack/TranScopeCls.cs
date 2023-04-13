using System.Data;
using System.Data.Common;
using System.Transactions;
using R_BackEnd;
using R_Common;
using TranScopeCommon;

namespace TranScopeBack;

public class TranScopeCls
{
    public TranScopeDataDTO ProcessWithoutTransactionDB(int poProcessRecordCount)
    {
        R_Exception loException = new R_Exception();
        TranScopeDataDTO loRtn = new TranScopeDataDTO();
        List<CustomerDbDTO> Customers;
        try
        {
            Customers = GetAllCustomer(poProcessRecordCount);

            RemoveAllCustomer(Customers);
            AddAllCopyCustomer(Customers);

            loRtn.IsSuccess = true;
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
    EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }


    public TranScopeDataDTO ProcessAllWithTransactionDB(int poProcessRecordCount)
    {
        R_Exception loException = new R_Exception();
        TranScopeDataDTO loRtn = new TranScopeDataDTO();
        List<CustomerDbDTO> Customers;
        try
        {
            Customers = GetAllCustomer(poProcessRecordCount);

            using (TransactionScope TransScope = new TransactionScope(TransactionScopeOption.Required))
            {
                RemoveAllCustomer(Customers);
                AddAllCopyCustomer(Customers);

                TransScope.Complete();
            }



            loRtn.IsSuccess = true;
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
    EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

    public TranScopeDataDTO ProcessEachTransactionDB(int poProcessRecordCount)
    {
        R_Exception loException = new R_Exception();
        TranScopeDataDTO loRtn = new TranScopeDataDTO();
        List<CustomerDbDTO> Customers;
        int lnCount;
        try
        {
            Customers = GetAllCustomer(poProcessRecordCount);
            lnCount = 1;
            foreach (CustomerDbDTO item in Customers)
            {
                try
                {
                    using (TransactionScope TransScope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        RemoveEachCustomer(item);
                        AddLogEachCustomer(item);
                        AddEachCopyCustomer(item);

                        if ((lnCount % 4) == 0)
                        {
                            loException.Add("001", $"Error at {lnCount} data");
                            goto EndDetail;
                        }

                        TransScope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    loException.Add(ex);
                }
            EndDetail:

                lnCount++;
            }



            loRtn.IsSuccess = true;
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
    EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }




    private List<CustomerDbDTO> GetAllCustomer(int pnCount)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb = null;
        string lcCmd;
        List<CustomerDbDTO> loRtn = null;
        string lcCust;
        try
        {
            lcCust = String.Format("Cust{0}", pnCount.ToString("0000"));
            lcCmd = "select * from TestCustomer(nolock) where CustomerID<={0}";
            loDb = new R_Db();
            loRtn = loDb.SqlExecObjectQuery<CustomerDbDTO>(lcCmd, lcCust);

        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

    EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

    private void RemoveAllCustomer1(List<CustomerDbDTO> poCustomers)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb = null;
        DbConnection loConn = null;
        DbCommand loCommand;
        string lcCmd;
        DbParameter loDbParameter;
        try
        {
            loDb = new R_Db();
            loCommand = loDb.GetCommand();
            loConn = loDb.GetConnection();
            loDb.R_AddCommandParameter(loCommand, "StrPar1", DbType.String, 50, "");
            loDbParameter = loCommand.Parameters[0];
            foreach (CustomerDbDTO item in poCustomers)
            {
                lcCmd = "delete TestCustomer where CustomerID=@StrPar1";
                loCommand.CommandText = lcCmd;
                loDbParameter.Value = item.CustomerID;
                loDb.SqlExecNonQuery(loConn, loCommand, false);


                lcCmd = "insert into TestCustomerLog(Log) Values(@StrPar1)";
                loCommand.CommandText = lcCmd;
                loDbParameter.Value = $"Remove Customer {item.CustomerID}";
                //loDb.SqlExecNonQuery(loConn, loCommand, false);

                using (TransactionScope TransScope = new TransactionScope(TransactionScopeOption.Suppress))
                {
                    loDb.SqlExecNonQuery(loConn, loCommand, false);
                }


            }
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }
                loConn.Dispose();
            }


        }
    EndBlock:
        loException.ThrowExceptionIfErrors();

    }

    private void RemoveAllCustomer(List<CustomerDbDTO> poCustomers)
    {
        R_Exception loException = new R_Exception();
        try
        {
            foreach (CustomerDbDTO item in poCustomers)
            {
                RemoveEachCustomer(item);
                AddLogEachCustomer(item);
            }
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

    EndBlock:
        loException.ThrowExceptionIfErrors();

    }


    private void AddAllCopyCustomer(List<CustomerDbDTO> poCustomers)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb = null;
        DbConnection loConn = null;
        DbCommand loCommand;
        string lcCmd;
        DbParameter loDbParCustomerID;
        DbParameter loDbParCustomerName;
        DbParameter loDbParContactName;
        int lnCount;
        try
        {
            //CustomerID CustomerName    ContactName
            loDb = new R_Db();
            loCommand = loDb.GetCommand();
            loConn = loDb.GetConnection();
            loDb.R_AddCommandParameter(loCommand, "CustomerID", DbType.String, 50, "");
            loDb.R_AddCommandParameter(loCommand, "CustomerName", DbType.String, 50, "");
            loDb.R_AddCommandParameter(loCommand, "ContactName", DbType.String, 50, "");

            loDbParCustomerID = loCommand.Parameters["CustomerID"];
            loDbParCustomerName = loCommand.Parameters["CustomerName"];
            loDbParContactName = loCommand.Parameters["ContactName"];

            lnCount = 1;
            foreach (CustomerDbDTO item in poCustomers)
            {
                if ((lnCount % 4) == 0)
                {
                    loException.Add("001", $"Error at {lnCount} data");
                    goto EndBlock;
                }

                lcCmd = "insert into TestCopyCustomer(CustomerID, CustomerName, ContactName) Values(@CustomerID, @CustomerName, @ContactName)";
                loCommand.CommandText = lcCmd;
                loDbParCustomerID.Value = item.CustomerID;
                loDbParCustomerName.Value = item.CustomerName;
                loDbParContactName.Value = item.ContactName;
                loDb.SqlExecNonQuery(loConn, loCommand, false);

                lnCount++;
            }
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }
                loConn.Dispose();
            }
        }
    EndBlock:
        loException.ThrowExceptionIfErrors();

    }

    private void RemoveEachCustomer(CustomerDbDTO poCustomer)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb = null;
        DbConnection loConn = null;
        DbCommand loCommand;
        string lcCmd;
        DbParameter loDbParameter;

        try
        {
            loDb = new R_Db();
            loCommand = loDb.GetCommand();
            loConn = loDb.GetConnection();
            loDb.R_AddCommandParameter(loCommand, "StrPar1", DbType.String, 50, "");
            loDbParameter = loCommand.Parameters[0];

            lcCmd = "delete TestCustomer where CustomerID=@StrPar1";
            loCommand.CommandText = lcCmd;
            loDbParameter.Value = poCustomer.CustomerID;
            loDb.SqlExecNonQuery(loConn, loCommand, false);

        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }
                loConn.Dispose();
            }


        }
    EndBlock:
        loException.ThrowExceptionIfErrors();


    }

    private void AddLogEachCustomer(CustomerDbDTO poCustomer)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb = null;
        DbConnection loConn = null;
        DbCommand loCommand;
        string lcCmd;
        DbParameter loDbParameter;

        try
        {
            using (TransactionScope TransScope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                loDb = new R_Db();
                loCommand = loDb.GetCommand();
                loConn = loDb.GetConnection();
                loDb.R_AddCommandParameter(loCommand, "StrPar1", DbType.String, 50, "");
                loDbParameter = loCommand.Parameters[0];

                lcCmd = "insert into TestCustomerLog(Log) Values(@StrPar1)";
                loCommand.CommandText = lcCmd;
                loDbParameter.Value = $"Remove Customer {poCustomer.CustomerID}";
                loDb.SqlExecNonQuery(loConn, loCommand, false);
            }


        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }
                loConn.Dispose();
            }


        }
    EndBlock:
        loException.ThrowExceptionIfErrors();


    }

    private void AddEachCopyCustomer(CustomerDbDTO poCustomer)
    {
        R_Exception loException = new R_Exception();
        R_Db loDb = null;
        DbConnection loConn = null;
        DbCommand loCommand;
        string lcCmd;
        DbParameter loDbParCustomerID;
        DbParameter loDbParCustomerName;
        DbParameter loDbParContactName;

        try
        {
            loDb = new R_Db();
            loCommand = loDb.GetCommand();
            loConn = loDb.GetConnection();
            loDb.R_AddCommandParameter(loCommand, "CustomerID", DbType.String, 50, "");
            loDb.R_AddCommandParameter(loCommand, "CustomerName", DbType.String, 50, "");
            loDb.R_AddCommandParameter(loCommand, "ContactName", DbType.String, 50, "");

            loDbParCustomerID = loCommand.Parameters["CustomerID"];
            loDbParCustomerName = loCommand.Parameters["CustomerName"];
            loDbParContactName = loCommand.Parameters["ContactName"];

            lcCmd = "insert into TestCopyCustomer(CustomerID, CustomerName, ContactName) Values(@CustomerID, @CustomerName, @ContactName)";
            loCommand.CommandText = lcCmd;
            loDbParCustomerID.Value = poCustomer.CustomerID;
            loDbParCustomerName.Value = poCustomer.CustomerName;
            loDbParContactName.Value = poCustomer.ContactName;
            loDb.SqlExecNonQuery(loConn, loCommand, false);

        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }
        finally
        {
            if (loConn != null)
            {
                if (loConn.State != ConnectionState.Closed)
                {
                    loConn.Close();
                }
                loConn.Dispose();
            }


        }
    EndBlock:
        loException.ThrowExceptionIfErrors();


    }

}