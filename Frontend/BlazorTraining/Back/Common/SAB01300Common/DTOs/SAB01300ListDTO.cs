using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB01300Common.DTOs
{
    public class SAB01300ListDTO<T> : R_APIResultBaseDTO
    {
        public List<T> Data { get; set; }
    }
}
