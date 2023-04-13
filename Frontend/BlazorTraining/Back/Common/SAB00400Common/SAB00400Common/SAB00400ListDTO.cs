using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00400Common
{
    public class SAB00400ListDTO<T> : R_APIResultBaseDTO
    {
        public List<T> Data { get; set; }
    }
}
