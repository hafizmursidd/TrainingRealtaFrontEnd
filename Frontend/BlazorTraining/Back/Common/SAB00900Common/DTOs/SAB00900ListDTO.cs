using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00900Common.DTOs
{
    public class SAB00900ListDTO<T> : R_APIResultBaseDTO
    {
        public List<T> Data { get; set; }
    }
}
