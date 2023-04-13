using AuthBack;
using AuthCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using R_AuthenticationBack;
using R_AuthenticationEnumAndInterface;
using R_Common;

namespace AuthService
{
    [Route("api/[controller]/[action]"), AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase, IAuth
    {
        private readonly IConfiguration _configuration;
        private readonly R_TokenUtility _tokenUtility;
        private readonly AuthCls _authCls;
        private readonly R_TokenConfigurationResultDTO _tokenConfiguration;

        const string TOKEN = "Token";
        const string TOKEN_EXPIRES = "TokenExpiresInMin";
        const string REFRESH_TOKEN_EXPIRES = "RefreshTokenExpiresInDay";
        const string REFRESH_TOKEN = "RefreshToken";

        #region ctor
        public AuthController(IConfiguration configuration, R_TokenUtility tokenUtility, AuthCls authCls)
        {
            _configuration = configuration;
            _tokenUtility = tokenUtility;
            _authCls = authCls;

            _tokenConfiguration = tokenUtility.R_GetTokenConfiguration();
        }
        #endregion

        [HttpPost]
        public LoginResultDTO Login(UserDTO poLoginParameter)
        {
            R_Exception loException = new R_Exception();
            GetUserAuthByIdParameterBackDTO loUserPar = new GetUserAuthByIdParameterBackDTO() { CCOMPANY_ID = poLoginParameter.CompanyId, CUSER_ID = poLoginParameter.UserId };
            GetUserAuthResultBackDTO loUser;
            LoginResultDTO loRtn = null;
            R_CreateRefreshTokenResultDTO newRefreshToken;

            try
            {
                //Search User
                loUser = _authCls.GetUserAuthById(loUserPar);
                if (loUser == null)
                {
                    loException.Add("Err01", "Credential not Valid.");
                    goto EndTryBlock;
                }

                if (!VerifyPasswordHash(poLoginParameter.Password, loUser.CUSER_PASSWORD, loUser.CUSER_ID))
                {
                    loException.Add("Err01", "Credential not Valid.");
                    goto EndTryBlock;
                }

                //Create Token
                R_CreateTokenParameterDTO loTokenParameter = new R_CreateTokenParameterDTO()
                {
                    Key = _tokenConfiguration.Token,
                    ExpiresInMin = _tokenConfiguration.TokenExpiresInMin,
                    UserToken = new R_UserTokenDTO() { CompanyId = loUser.CCOMPANY_ID.Trim(), UserId = loUser.CUSER_ID, UserRole = "ADMIN" }
                };
                string pcToken = _tokenUtility.R_CreateToken(loTokenParameter);

                //Set IP Address
                loUser.CTOKEN_IP_ADDRESS = _tokenUtility.R_GetIpAddress();

                newRefreshToken = _tokenUtility.R_CreateRefreshToken(_tokenConfiguration.RefreshTokenExpiresInDay);
                SetRefreshToken(loUser, newRefreshToken);

                loRtn = new LoginResultDTO()
                {
                    data = new TokenDTO() { token = pcToken }
                };

            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndTryBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_RefreshTokenResultDTO R_RefreshToken()
        {
            R_Exception loException = new R_Exception();
            GetUserAuthByRefreshTokenParameterBackDTO loUserPar;
            GetUserAuthResultBackDTO loUser;
            R_RefreshTokenResultDTO loRtn = null;
            string lcRefreshToken;
            string lcIpAddress;
            try
            {
                lcRefreshToken = Request.Cookies[REFRESH_TOKEN];
                lcIpAddress = _tokenUtility.R_GetIpAddress();

                //Search User by Request Token
                loUserPar = new GetUserAuthByRefreshTokenParameterBackDTO() { CREFRESH_TOKEN = lcRefreshToken.Trim() };
                loUser = _authCls.GetUserAuthByRefreshToken(loUserPar);

                if (loUser == null)
                {
                    loException.Add("Err01", "Invalid Refresh Token 1.");
                    goto EndTryBlock;
                }

                if (!loUser.CTOKEN_IP_ADDRESS.Trim().Equals(lcIpAddress.Trim()))
                {
                    loException.Add("Err02", "Invalid Refresh Token 2.");
                    goto EndTryBlock;
                }

                if (loUser.DREFRESH_TOKEN_UTC_EXPIRES < DateTime.UtcNow)
                {
                    loException.Add("Err03", "Token expired.");
                    goto EndTryBlock;
                }

                //Create Token
                R_CreateTokenParameterDTO loTokenParameter = new R_CreateTokenParameterDTO()
                {
                    Key = _tokenConfiguration.Token,
                    ExpiresInMin = _tokenConfiguration.TokenExpiresInMin,
                    UserToken = new R_UserTokenDTO() { CompanyId = loUser.CCOMPANY_ID.Trim(), UserId = loUser.CUSER_ID, UserRole = "ADMIN" }
                };
                string lcToken = _tokenUtility.R_CreateToken(loTokenParameter);

                //Create Refresh Token
                R_CreateRefreshTokenResultDTO newRefreshToken = _tokenUtility.R_CreateRefreshToken(_tokenConfiguration.RefreshTokenExpiresInDay);
                SetRefreshToken(loUser, newRefreshToken);

                loRtn = new R_RefreshTokenResultDTO()
                {
                    data = new R_RefreshTokenResultData() { token = lcToken }
                };

            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndTryBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }


        private void SetRefreshToken(GetUserAuthResultBackDTO loUser, R_CreateRefreshTokenResultDTO newRefreshToken)
        {
            R_Exception loException = new R_Exception();
            UpdateRefreshTokenParameterBackDTO loUserPar;
            CookieOptions cookieOptions;
            try
            {
                cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = newRefreshToken.Expires,
                    IsEssential=true
                };
                Response.Cookies.Append(REFRESH_TOKEN, newRefreshToken.Token, cookieOptions);

                //Set Refresh Token
                loUser.CREFRESH_TOKEN = newRefreshToken.Token;
                loUser.DREFRESH_TOKEN_UTC_CREATED = newRefreshToken.Created;
                loUser.DREFRESH_TOKEN_UTC_EXPIRES = newRefreshToken.Expires;

                //Set Database
                loUserPar = new UpdateRefreshTokenParameterBackDTO()
                {
                    CCOMPANY_ID = loUser.CCOMPANY_ID,
                    CUSER_ID = loUser.CUSER_ID,
                    CREFRESH_TOKEN = loUser.CREFRESH_TOKEN,
                    CTOKEN_IP_ADDRESS = loUser.CTOKEN_IP_ADDRESS,
                    DREFRESH_TOKEN_UTC_CREATED = loUser.DREFRESH_TOKEN_UTC_CREATED,
                    DREFRESH_TOKEN_UTC_EXPIRES = loUser.DREFRESH_TOKEN_UTC_EXPIRES
                };
                _authCls.UpdateRefreshToken(loUserPar);

            }
            catch (Exception ex)
            {

                loException.Add(ex);
            }
        EndTryBlock:
            loException.ThrowExceptionIfErrors();





        }

        private bool VerifyPasswordHash(string poPassword, string poPasswordHash, string poPasswordSalt)
        {
            string loHashPass = R_Utility.HashPassword(poPassword, poPasswordSalt.ToLower().Trim());
            return loHashPass.Trim().Equals(poPasswordHash.Trim());
        }

    }
}
