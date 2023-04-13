using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00700Common.DTOs
{
    public class SAB00700ListDTO : R_APIResultBaseDTO
    {
        public List<SAB00700GridDTO> Data { get; set; }
    }

    public class SAB00700GridDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
