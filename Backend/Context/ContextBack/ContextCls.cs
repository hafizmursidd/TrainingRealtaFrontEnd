using ContextCommon;
using R_Common;

namespace ContextBack;

public class ContextCls
{
    public List<SalesStreamDTO> GetSalesListDb(GetSalesListDbParameterDTO poParameter)
    {
        R_Exception loException = new();
        List<SalesStreamDTO> loRtn = null;
        try
        {
            loRtn = new List<SalesStreamDTO>();
            for (var lnCount = 1; lnCount <= poParameter.SalesCount; lnCount++)
            {
                loRtn.Add(new SalesStreamDTO()
                    {
                        CompanyId = poParameter.CompanyId,
                        DepartmentId = poParameter.DepartmentId,
                        SalesId = String.Format("S-{0}", lnCount.ToString()),
                        SalesName = String.Format("Sales {0}", lnCount.ToString())
                    }
                );
            }
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

    public List<OrderStreamDTO> GetOrderListDb(GetOrderListDbParameterDTO poParameter)
    {
        R_Exception loException = new();
        List<OrderStreamDTO> loRtn = null;
        try
        {
            loRtn = new List<OrderStreamDTO>();
            for (var lnCount = 1; lnCount <= poParameter.OrderCount; lnCount++)
            {
                loRtn.Add(new OrderStreamDTO()
                    {
                        CompanyId = poParameter.CompanyId,
                        DepartmentId = poParameter.DepartmentId,
                        SalesId = poParameter.SalesId,
                        OrderId = String.Format("O-{0}", lnCount.ToString()),
                        OrderDate = DateTime.Now.ToString("yyyyMMdd")
                    }
                );
            }
        }
        catch (Exception ex)
        {
            loException.Add(ex);
        }

        EndBlock:
        loException.ThrowExceptionIfErrors();

        return loRtn;
    }

}