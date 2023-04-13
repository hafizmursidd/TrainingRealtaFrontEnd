using System.Collections.Generic;
using R_CommonFrontBackAPI;

namespace CRUDCommon
{
    public interface ICRUD:R_IServiceCRUDBase<CustomerDTO>
    {
        IAsyncEnumerable<CustomerStreamDTO> CustomerList();
    }
}