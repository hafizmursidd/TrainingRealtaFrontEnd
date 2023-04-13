using R_APICommonDTO;

namespace AuthCommon
{
    public class RegisterResultDTO: R_APIResultBaseDTO
    {
        public UserDTO data { get; set; }
    }
}
