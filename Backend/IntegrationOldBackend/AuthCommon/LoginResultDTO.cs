using R_APICommonDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthCommon
{
    public class LoginResultDTO: R_APIResultBaseDTO
    {
        public TokenDTO data { get; set; }
    }
}
