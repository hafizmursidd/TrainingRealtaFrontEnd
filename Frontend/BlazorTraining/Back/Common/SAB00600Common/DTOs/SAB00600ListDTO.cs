using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00600Common.DTOs
{
    public class SAB00600ListDTO : R_APIResultBaseDTO
    {
        public List<SAB00600DTO> Data { get; set; }
    }
}
