using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;
using System.Collections.Generic;

namespace SAB01300Common
{
    public interface ISAB01300 : R_IServiceCRUDBase<SAB01300DTO>
    {
        SAB01300ListDTO<SAB01300DTO> GetAllCategory();
        IAsyncEnumerable<SAB01300DTO> GetAllCategoryStream();
    }
}
