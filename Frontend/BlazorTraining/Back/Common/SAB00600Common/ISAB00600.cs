using R_CommonFrontBackAPI;
using SAB00600Common.DTOs;

namespace SAB00600Common
{
    public interface ISAB00600 : R_IServiceCRUDBase<SAB00600DTO>
    {
        SAB00600ListDTO GetAllCustomer();
    }
}
