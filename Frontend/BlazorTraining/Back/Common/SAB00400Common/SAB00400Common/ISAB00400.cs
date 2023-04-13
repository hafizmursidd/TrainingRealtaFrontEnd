using R_CommonFrontBackAPI;

namespace SAB00400Common
{
    public interface ISAB00400 : R_IServiceCRUDBase<SAB00400DTO>
    {
        SAB00400ListDTO<SAB00400DTO> GetAllRegion();
    }
}
