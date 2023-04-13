using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;

namespace SAB00100Back
{
    public class SAB00100Cls : R_BusinessObject<SAB00100DTO>
    {
        protected override void R_Deleting(SAB00100DTO poEntity)
        {
            var loEx = new R_Exception();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"DELETE FROM Employees WHERE EmployeeID = {poEntity.EmployeeID}";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        protected override SAB00100DTO R_Display(SAB00100DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00100DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Employees (NOLOCK) WHERE EmployeeID = {poEntity.EmployeeID}";
                loResult = loDb.SqlExecObjectQuery<SAB00100DTO>(lcQuery, loConn, true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00100DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                string lcQuery = "";
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var loCmd = loDb.GetCommand();
                if (poCRUDMode == eCRUDMode.AddMode)
                {
                    lcQuery = "INSERT INTO Employees (FirstName, LastName, Address, City, Country) ";
                    lcQuery += $"VALUES ('{poNewEntity.FirstName}', '{poNewEntity.LastName}', '{poNewEntity.Address}', '{poNewEntity.City}', '{poNewEntity.Country}') ";
                    lcQuery += "SELECT SCOPE_IDENTITY()";

                    var liResult = loDb.SqlExecObjectQuery<decimal>(lcQuery, loConn, true);

                    poNewEntity.EmployeeID = Convert.ToInt32(liResult.FirstOrDefault());

                    return;
                }

                lcQuery = $"UPDATE Employees SET FirstName = '{poNewEntity.FirstName}', LastName = '{poNewEntity.LastName}', ";
                lcQuery += $"Address = '{poNewEntity.Address}', City = '{poNewEntity.City}', Country = '{poNewEntity.Country}'";
                lcQuery += $"WHERE EmployeeID = '{poNewEntity.EmployeeID}' ";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        // public List<SAB00100GridDTO> GetAllEmployee()
        // {
        //     var loEx = new R_Exception();
        //     List<SAB00100GridDTO> loResult = null;
        //
        //     try
        //     {
        //         var loDb = new R_Db();
        //         var loConn = loDb.GetConnection("NorthwindConnectionString");
        //
        //         var lcQuery = "SELECT * FROM Employees (NOLOCK)";
        //         loResult = loDb.SqlExecObjectQuery<SAB00100GridDTO>(lcQuery, loConn, true);
        //     }
        //     catch (Exception ex)
        //     {
        //         loEx.Add(ex);
        //     }
        //
        //     loEx.ThrowExceptionIfErrors();
        //
        //     return loResult;
        // }
        
        public List<SAB00100DTO> GetAllEmployee()
        {
            var loEx = new R_Exception();
            List<SAB00100DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Employees (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAB00100DTO>(lcQuery, loConn, true);
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