using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00600Common.DTOs;

namespace SAB00600Back
{
    public class SAB00600Cls : R_BusinessObject<SAB00600DTO>
    {
        protected override void R_Deleting(SAB00600DTO poEntity)
        {
            var loEx = new R_Exception();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"DELETE FROM Customers WHERE CustomerID = '{poEntity.CustomerID}'";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        protected override SAB00600DTO R_Display(SAB00600DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00600DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Customers (NOLOCK) WHERE CustomerID = '{poEntity.CustomerID}'";
                loResult = loDb.SqlExecObjectQuery<SAB00600DTO>(lcQuery, loConn, true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00600DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                string lcQuery = "";
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                if (poCRUDMode == eCRUDMode.AddMode)
                {
                    lcQuery = "INSERT INTO Customers (CustomerID, CompanyName, ContactName) ";
                    lcQuery += $"VALUES ('{poNewEntity.CustomerID}', '{poNewEntity.CompanyName}', '{poNewEntity.ContactName}') ";
                    loDb.SqlExecNonQuery(lcQuery, loConn, true);

                    return;
                }

                lcQuery = $"UPDATE Customers SET CompanyName = '{poNewEntity.CompanyName}', ContactName = '{poNewEntity.ContactName}' ";
                lcQuery += $"WHERE CustomerID = '{poNewEntity.CustomerID}' ";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public List<SAB00600DTO> GetCustomers()
        {
            var loEx = new R_Exception();
            List<SAB00600DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Customers (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAB00600DTO>(lcQuery, loConn, true);
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