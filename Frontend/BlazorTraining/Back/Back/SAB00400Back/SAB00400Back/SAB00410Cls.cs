using BackHelper;
using R_BackEnd;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Common;

namespace SAB00400Back
{
    public class SAB00410Cls : R_BusinessObject<SAB00410DTO>
    {
        protected override void R_Deleting(SAB00410DTO poEntity)
        {
            throw new NotImplementedException();
            //var loEx = new R_Exception();
            //try
            //{
            //    var loDb = new R_Db();
            //    var loConn = loDb.GetConnection("NorthwindConnectionString");

            //    var lcQuery = "DELETE FROM Territories WHERE TerritoryId = @TerritoryId";

            //    var loCmd = loDb.GetCommand();
            //    loCmd.CommandText = lcQuery;
            //    loCmd.AddParameter("@ProductID", poEntity.TerritoryId);

            //    loDb.SqlExecNonQuery(loConn, loCmd, true);
            //}
            //catch (Exception ex)
            //{
            //    loEx.Add(ex);
            //}

            //loEx.ThrowExceptionIfErrors();
        }

        protected override SAB00410DTO R_Display(SAB00410DTO poEntity)
        {
            var loEx = new R_Exception();
            SAB00410DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) WHERE TerritoryId = @TerritoryId";

                var loCmd = loDb.GetCommand();
                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@TerritoryId", poEntity.TerritoryId);

                var loDataTable = loDb.SqlExecQuery(loConn, loCmd, true);

                loResult = R_Utility.R_ConvertTo<SAB00410DTO>(loDataTable).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Saving(SAB00410DTO poNewEntity, eCRUDMode poCRUDMode)
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
                    lcQuery = "INSERT Territories (TerritoryID, TerritoryDescription,  RegionID) ";
                    lcQuery += "VALUES (@TerritoryID, @TerritoryDescription, @RegionID) ";

                    loCmd.CommandText = lcQuery;
                    loCmd.AddParameter("@TerritoryID", poNewEntity.TerritoryId);
                    loCmd.AddParameter("@TerritoryDescription", poNewEntity.TerritoryDescription);
                    loCmd.AddParameter("@RegionID", poNewEntity.RegionId);

                    var loResult = loDb.SqlExecQuery(loConn, loCmd, true);

                    return;
                }

                lcQuery = "UPDATE Territories SET TerritoryDescription = @TerritoryDescription, " +
                    "RegionId = @RegionId ";
                lcQuery += "WHERE RegionID = @RegionID ";

                loCmd.CommandText = lcQuery;
                loCmd.AddParameter("@TerritoryID", poNewEntity.TerritoryId);
                loCmd.AddParameter("@TerritoryDescription", poNewEntity.TerritoryDescription);
                loCmd.AddParameter("@RegionID", poNewEntity.RegionId);

                loDb.SqlExecNonQuery(loConn, loCmd, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public List<SAB00410DTO> GetAllTerritories()
        {
            var loEx = new R_Exception();
            List<SAB00410DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) ORDER BY TerritoryId";
                loResult = loDb.SqlExecObjectQuery<SAB00410DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List <SAB00410DTO> GetTerritoryByRegion (int pcRegionId)
        {
            var loEx = new R_Exception();
            var loResult = new List<SAB00410DTO>();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) ";
                lcQuery += $"WHERE RegionId = {pcRegionId}";
                loResult = loDb.SqlExecObjectQuery<SAB00410DTO>(lcQuery, loConn, true);
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