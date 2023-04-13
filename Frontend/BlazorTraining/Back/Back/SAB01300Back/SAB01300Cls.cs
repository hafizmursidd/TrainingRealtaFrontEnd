using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;

namespace SAB01300Back
{
    public class SAB01300Cls : R_BusinessObject<SAB01300DTO>
    {
        protected override void R_Deleting(SAB01300DTO poEntity)
        {
            var loEx = new R_Exception();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"DELETE FROM Categories WHERE CategoryID = {poEntity.CategoryID}";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        protected override SAB01300DTO R_Display(SAB01300DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB01300DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Categories (NOLOCK) WHERE CategoryID = {poEntity.CategoryID}";
                loResult = loDb.SqlExecObjectQuery<SAB01300DTO>(lcQuery, loConn, true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB01300DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                string lcQuery = "";
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                if (poCRUDMode == eCRUDMode.AddMode)
                {
                    lcQuery = "INSERT INTO Categories (CategoryName, Description) ";
                    lcQuery += $"VALUES ('{poNewEntity.CategoryName}', '{poNewEntity.Description}') ";
                    loDb.SqlExecNonQuery(lcQuery, loConn, true);

                    return;
                }

                lcQuery = $"UPDATE Categories SET CategoryName = '{poNewEntity.CategoryName}', Description = '{poNewEntity.Description}' ";
                lcQuery += $"WHERE CategoryID = {poNewEntity.CategoryID} ";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public List<SAB01300DTO> GetCategories()
        {
            var loEx = new R_Exception();
            List<SAB01300DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Categories (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAB01300DTO>(lcQuery, loConn, true);
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