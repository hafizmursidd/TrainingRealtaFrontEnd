using R_APICommonDTO;
using System.Collections.Generic;

namespace PublicLookupCommon.DTOs
{
    public class SALGenericListDTO<T> : R_APIResultBaseDTO
    {
        public List<T> Data { get; set; }
    }
}
