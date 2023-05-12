using R_BackEnd;
using R_Common;
using System.Data.Common;

namespace SPResourceBack
{
    public class SPResourceCls
    {
        public void GSMaintainCenter()
        {
            var loDb = new R_Db();
            DbConnection loConn = null;
            var loEx = new R_Exception();

            try
            {
                loConn = loDb.GetConnection();

                R_ExternalException.R_SP_Init_Exception(loConn);
                var lcQuery = "EXEC RSP_GS_MAINTAIN_CENTER 'rcd', 'ERC', 'ERICSON', 'True', 'ADD', 'erc'";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;

                try
                {
                    loDb.SqlExecNonQuery(loConn, loCmd, false);
                }
                catch (Exception ex)
                {
                    loEx.Add(ex);
                }

                loEx.Add(R_ExternalException.R_SP_Get_Exception(loConn));
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            finally
            {
                if (loConn != null)
                {
                    if (loConn.State != System.Data.ConnectionState.Closed)
                        loConn.Close();

                    loConn.Dispose();
                    loConn = null;
                }
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}