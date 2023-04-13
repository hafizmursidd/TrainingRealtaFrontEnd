using ContextCommon;
using R_APIClient;

namespace ContextConsole;

public class NotifySales:R_INotify<SalesStreamDTO>
{
    public void Notify(SalesStreamDTO poSales)
    { 
        Console.WriteLine("Sales: {0} {1}", poSales.SalesId, poSales.SalesName);
    }
}