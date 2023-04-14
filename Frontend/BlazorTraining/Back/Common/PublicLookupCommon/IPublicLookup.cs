using PublicLookupCommon.DTOs;

namespace PublicLookupCommon
{
    public interface IPublicLookup
    {
        SALGenericListDTO<SAL00100DTO> GetAllEmployee();
        SALGenericListDTO<SAL00200DTO> GetAllCategory();
        SALGenericListDTO<SAL00300DTO> GetAllProduct();
    }
}
