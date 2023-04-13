using R_CommonFrontBackAPI;
using SAB00700Common.DTOs;

namespace SAB00700Common
{
    public interface ISAB00700 : R_IServiceCRUDBase<SAB00700DTO>
    {
        SAB00700ListDTO GetAllCategory();
    }
}
