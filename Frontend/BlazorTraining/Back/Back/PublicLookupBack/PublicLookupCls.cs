using PublicLookupCommon.DTOs;
using R_BackEnd;
using R_Common;

namespace PublicLookupBack
{
    public class PublicLookupCls
    {
        public List<SAL00100DTO> GetAllEmployee()
        {
            var loEx = new R_Exception();
            List<SAL00100DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Employees (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAL00100DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List<SAL00200DTO> GetAllCategory()
        {
            var loEx = new R_Exception();
            List<SAL00200DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Categories (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAL00200DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List<SAL00300DTO> GetAllProduct()
        {
            var loEx = new R_Exception();
            List<SAL00300DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Products (NOLOCK) ORDER BY ProductID";
                loResult = loDb.SqlExecObjectQuery<SAL00300DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
    }
}