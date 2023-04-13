using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00700Common.DTOs;

namespace SAB00700Back
{
    public class SAB00700Cls : R_BusinessObject<SAB00700DTO>
    {
        protected override void R_Deleting(SAB00700DTO poEntity)
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

        protected override SAB00700DTO R_Display(SAB00700DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00700DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Categories (NOLOCK) WHERE CategoryID = {poEntity.CategoryID}";
                loResult = loDb.SqlExecObjectQuery<SAB00700DTO>(lcQuery, loConn, true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00700DTO poNewEntity, eCRUDMode poCRUDMode)
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
                    lcQuery += "SELECT SCOPE_IDENTITY()";

                    var liResult = loDb.SqlExecObjectQuery<decimal>(lcQuery, loConn, true);

                    poNewEntity.CategoryID = Convert.ToInt32(liResult.FirstOrDefault());

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

        public List<SAB00700GridDTO> GetCategories()
        {
            var loEx = new R_Exception();
            List<SAB00700GridDTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Categories (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAB00700GridDTO>(lcQuery, loConn, true);
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