using System.Collections.Generic;
using System.Threading.Tasks;
using R_CommonFrontBackAPI;

namespace GSM00200Common
{
    public interface IGSM00200 : R_IServiceCRUDBase<GSM00200DTO>
    {
        IAsyncEnumerable<GSM00200DTOnon> GetTableHDList();
    }
}