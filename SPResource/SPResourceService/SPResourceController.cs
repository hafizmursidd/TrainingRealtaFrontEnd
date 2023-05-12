using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using SPResourceBack;

namespace SPResourceService
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SPResourceController : ControllerBase
    {
        [HttpPost]
        public void GSMaintainCenter()
        {
            var loEx = new R_Exception();

            try
            {
                var loCls = new SPResourceCls();

                loCls.GSMaintainCenter();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}