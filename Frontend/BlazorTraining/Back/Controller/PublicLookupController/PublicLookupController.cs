using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicLookupBack;
using PublicLookupCommon;
using PublicLookupCommon.DTOs;
using R_Common;

namespace PublicLookupController
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class PublicLookupController : ControllerBase, IPublicLookup
    {
        [HttpPost]
        public SALGenericListDTO<SAL00100DTO> GetAllEmployee()
        {
            var loEx = new R_Exception();
            SALGenericListDTO<SAL00100DTO> loRtn = null;

            try
            {
                var loCls = new PublicLookupCls();

                var loResult = loCls.GetAllEmployee();

                loRtn = new SALGenericListDTO<SAL00100DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SALGenericListDTO<SAL00200DTO> GetAllCategory()
        {
            var loEx = new R_Exception();
            SALGenericListDTO<SAL00200DTO> loRtn = null;

            try
            {
                var loCls = new PublicLookupCls();

                var loResult = loCls.GetAllCategory();

                loRtn = new SALGenericListDTO<SAL00200DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SALGenericListDTO<SAL00300DTO> GetAllProduct()
        {
            var loEx = new R_Exception();
            SALGenericListDTO<SAL00300DTO> loRtn = null;

            try
            {
                var loCls = new PublicLookupCls();

                var loResult = loCls.GetAllProduct();

                loRtn = new SALGenericListDTO<SAL00300DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
    }
}