using System.Collections.Generic;

namespace ContextCommon
{
    public interface IContextProgram
    {
        IAsyncEnumerable<SalesStreamDTO> GetSalesList();
        IAsyncEnumerable<OrderStreamDTO> GetOrderList();
    }
}