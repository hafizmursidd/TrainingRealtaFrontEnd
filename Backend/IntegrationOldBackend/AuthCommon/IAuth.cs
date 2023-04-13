using R_AuthenticationEnumAndInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthCommon
{
    public interface IAuth
    {
        LoginResultDTO Login(UserDTO poLoginParameter);
        R_RefreshTokenResultDTO R_RefreshToken();

    }
}
