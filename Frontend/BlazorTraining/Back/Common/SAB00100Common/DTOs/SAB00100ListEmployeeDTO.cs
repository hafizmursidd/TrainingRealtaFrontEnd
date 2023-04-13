using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00100Common.DTOs
{
    public class SAB00100ListEmployeeDTO : R_APIResultBaseDTO
    {
        public List<SAB00100GridDTO> Data { get; set; }
    }

    public class SAB00100GridDTO
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
