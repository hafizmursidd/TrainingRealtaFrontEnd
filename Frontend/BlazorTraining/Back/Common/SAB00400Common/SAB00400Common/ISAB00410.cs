using R_CommonFrontBackAPI;

namespace SAB00400Common
{
    public interface ISAB00410 : R_IServiceCRUDBase<SAB00410DTO>
    {
        SAB00400ListDTO<SAB00410DTO> GetAllTerritory();
        SAB00400ListDTO<SAB00410DTO> GetAllTerritoryByRegion(int piTerritoryId);
    }
}
