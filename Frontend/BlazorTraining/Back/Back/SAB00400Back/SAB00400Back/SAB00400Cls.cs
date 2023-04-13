using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Common;

namespace SAB00400Back
{
    public class SAB00400Cls : R_BusinessObject<SAB00400DTO>
    {
        protected override void R_Deleting(SAB00400DTO poEntity)
        {
            var loEx = new R_Exception();
            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"DELETE FROM Region WHERE RegionID = {poEntity.RegionId}";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        protected override SAB00400DTO R_Display(SAB00400DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00400DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Region (NOLOCK) WHERE RegionID = {poEntity.RegionId}";
                loResult = loDb.SqlExecObjectQuery<SAB00400DTO>(lcQuery, loConn, true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00400DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                string lcQuery = "";
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                if (poCRUDMode == eCRUDMode.AddMode)
                {
                    lcQuery = "INSERT INTO Region (RegionID, RegionDescription) ";
                    lcQuery += $"VALUES ('{poNewEntity.RegionId}' , '{poNewEntity.RegionDescription}') ";
                    loDb.SqlExecNonQuery(lcQuery, loConn, true);

                    return;
                }

                lcQuery = $"UPDATE Region SET RegionDescription =  '{poNewEntity.RegionDescription}' ";
                lcQuery += $"WHERE RegionID = {poNewEntity.RegionId} ";
                loDb.SqlExecNonQuery(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public List<SAB00400DTO> GetRegion()
        {
            var loEx = new R_Exception();
            List<SAB00400DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Region (NOLOCK)";
                loResult = loDb.SqlExecObjectQuery<SAB00400DTO>(lcQuery, loConn, true);
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