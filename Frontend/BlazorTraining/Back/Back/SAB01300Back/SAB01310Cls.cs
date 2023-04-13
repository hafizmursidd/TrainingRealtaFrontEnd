using BackHelper;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;

namespace SAB01300Back
{
    public class SAB01310Cls : R_BusinessObject<SAB01310DTO>
    {
        protected override void R_Deleting(SAB01310DTO poEntity)
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

        protected override SAB01310DTO R_Display(SAB01310DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB01310DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Products (NOLOCK) WHERE ProductID = @ProductID";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@ProductID", poEntity.ProductID);

                var loDataTable = loDb.SqlExecQuery(loConn, loCmd, true);

                loResult = R_Utility.R_ConvertTo<SAB01310DTO>(loDataTable).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB01310DTO poNewEntity, eCRUDMode poCRUDMode)
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
                    lcQuery += "VALUES (@ProductName, @CategoryID, @UnitPrice, @UnitsInStock, @Discontinued) ";
                    lcQuery += "SELECT SCOPE_IDENTITY()";

                    loCmd.CommandText = lcQuery;
                    loCmd.AddParameter("@ProductName", poNewEntity.ProductName);
                    loCmd.AddParameter("@CategoryID", poNewEntity.CategoryID);
                    loCmd.AddParameter("@UnitPrice", poNewEntity.UnitPrice);
                    loCmd.AddParameter("@UnitsInStock", poNewEntity.UnitsInStock);
                    loCmd.AddParameter("@Discontinued", poNewEntity.Discontinued);

                    var loResult = loDb.SqlExecQuery(loConn, loCmd, true);

                    poNewEntity.ProductID = Convert.ToInt32(loResult.Rows[0].ItemArray[0]);

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

        public List<SAB01310DTO> GetAllProduct()
        {
            var loEx = new R_Exception();
            List<SAB01310DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Products (NOLOCK) ORDER BY ProductID";
                loResult = loDb.SqlExecObjectQuery<SAB01310DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List<SAB01310DTO> GetAllProductByCategory(int piCategoryId)
        {
            var loEx = new R_Exception();
            var loResult = new List<SAB01310DTO>();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Products (NOLOCK) ";
                lcQuery += $"WHERE CategoryID = {piCategoryId}";
                loResult = loDb.SqlExecObjectQuery<SAB01310DTO>(lcQuery, loConn, true);
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
