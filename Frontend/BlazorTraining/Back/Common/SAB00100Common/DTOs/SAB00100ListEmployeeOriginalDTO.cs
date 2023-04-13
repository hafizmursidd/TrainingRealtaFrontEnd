using System.Collections.Generic;
using R_APICommonDTO;

namespace SAB00100Common.DTOs
{
    public class SAB00100ListEmployeeOriginalDTO : R_APIResultBaseDTO
    {
        public List<SAB00100DTO> Data { get; set; }
    }
}