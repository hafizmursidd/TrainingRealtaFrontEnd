using R_CommonFrontBackAPI;
using SAB00900Common.DTOs;

namespace SAB00900Common
{
    public interface ISAB00900 : R_IServiceCRUDBase<SAB00900DTO>
    {
        SAB00900ListDTO<SAB00900CategoryDTO> GetAllCategory();
        SAB00900ListDTO<SAB00900DTO> GetAllProduct();
    }
}
