using ExceptionCommon;
using R_Common;

namespace ExceptionBack;

public class ExceptionCls
{
    public List<CustomerStreamDTO> GetCustomersDb(GetCustomersDbParameterDTO poParameter)
    {
        R_Exception loException = new();
        List<CustomerStreamDTO> loRtn = null;
        try
        {
            //simulasi Error kalau count>50
            if (poParameter.CustomerCount > 50)
            {
                loException.Add("01", "Error Count>50");
                goto EndBlock;
            }

            loRtn = new List<CustomerStreamDTO>();
            for (var lnCount = 1; lnCount <= poParameter.CustomerCount; lnCount++)
            {
                loRtn.Add(new CustomerStreamDTO()
                    {
                        CustomerId = String.Format("C-{0}", lnCount.ToString()),
                        CustomerName = String.Format("Customer {0}", lnCount.ToString())
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


    public CustomerDTO GetCustomerByIdDb(GetCustomerByIdDbParameterDTO poParameter)
    {
        R_Exception loException = new();
        CustomerDTO loRtn = null;
        try
        {
            loRtn = new CustomerDTO()
            {
                CustomerId = String.Format("C-{0}", poParameter.CustomerId),
                CustomerName = String.Format("Customer {0}", poParameter.CustomerId),
                DateOfBirth = DateTime.Now.ToString("yyyyMMdd")
            };
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