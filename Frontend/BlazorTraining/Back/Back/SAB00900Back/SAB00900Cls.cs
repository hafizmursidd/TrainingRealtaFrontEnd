using BackHelper;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00900Common.DTOs;

namespace SAB00900Back
{
    public class SAB00900Cls : R_BusinessObject<SAB00900DTO>
    {
        protected override void R_Deleting(SAB00900DTO poEntity)
        {
            var loEx = new R_Exception();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "DELETE FROM Products WHERE ProductID = @ProductID";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@ProductID", poEntity.ProductID);

                loDb.SqlExecNonQuery(loConn, loCmd, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        protected override SAB00900DTO R_Display(SAB00900DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00900DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Products (NOLOCK) WHERE ProductID = @ProductID";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@ProductID", poEntity.ProductID);

                var loDataTable = loDb.SqlExecQuery(loConn, loCmd, true);

                loResult = R_Utility.R_ConvertTo<SAB00900DTO>(loDataTable).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00900DTO poNewEntity, eCRUDMode poCRUDMode)
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
                    lcQuery = "INSERT INTO Products (ProductName, CategoryID, UnitPrice, UnitsInStock, Discontinued) ";
                    lcQuery += $"VALUES ('{poNewEntity.ProductName}', {poNewEntity.CategoryID}, {poNewEntity.UnitPrice}, {poNewEntity.UnitsInStock}, '{poNewEntity.Discontinued}') ";
                    lcQuery += "SELECT SCOPE_IDENTITY()";

                    var liResult = loDb.SqlExecObjectQuery<decimal>(lcQuery, loConn, true);

                    //loCmd.CommandText = lcQuery;
                    //loCmd.AddParameter("@ProductName", poNewEntity.ProductName);
                    //loCmd.AddParameter("@CategoryID", poNewEntity.CategoryID);
                    //loCmd.AddParameter("@UnitPrice", poNewEntity.UnitPrice);
                    //loCmd.AddParameter("@UnitsInStock", poNewEntity.UnitsInStock);
                    //loCmd.AddParameter("@Discontinued", poNewEntity.Discontinued);

                    //var loResult = loDb.SqlExecQuery(loConn, loCmd, true);

                    //poNewEntity.ProductID = Convert.ToInt32(loResult.Rows[0].ItemArray[0]);
                    poNewEntity.ProductID = Convert.ToInt32(liResult.FirstOrDefault());

                    return;
                }

                lcQuery = "UPDATE Products SET ProductName = @ProductName, " +
                    "CategoryID = @CategoryID, " +
                    "UnitPrice = @UnitPrice, " +
                    "UnitsInStock = @UnitsInStock, " +
                    "Discontinued = @Discontinued ";
                lcQuery += "WHERE ProductID = @ProductID ";

                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@ProductID", poNewEntity.ProductID);
                loCmd.AddParameter("@CategoryID", poNewEntity.CategoryID);
                loCmd.AddParameter("@UnitPrice", poNewEntity.UnitPrice);
                loCmd.AddParameter("@UnitsInStock", poNewEntity.UnitsInStock);
                loCmd.AddParameter("@Discontinued", poNewEntity.Discontinued);
                loCmd.AddParameter("@ProductName", poNewEntity.ProductName);
                loDb.SqlExecNonQuery(loConn, loCmd, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public List<SAB00900CategoryDTO> GetAllCategory()
        {
            var loEx = new R_Exception();
            List<SAB00900CategoryDTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Categories (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAB00900CategoryDTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List<SAB00900DTO> GetAllProduct()
        {
            var loEx = new R_Exception();
            List<SAB00900DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Products (NOLOCK) ORDER BY ProductID";
                loResult = loDb.SqlExecObjectQuery<SAB00900DTO>(lcQuery, loConn, true);
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