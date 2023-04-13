using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00900Common.DTOs;
using SAB00900FrontResources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB00900Model.ViewModels
{
    public class SAB00900ViewModel : R_ViewModel<SAB00900DTO>
    {
        private SAB00900Model _model = new SAB00900Model();

        public SAB00900DTO Product { get; set; } = new SAB00900DTO();

        public List<SAB00900CategoryDTO> CategoryList { get; set; } = new List<SAB00900CategoryDTO>();

        public List<SAB00900DTO> ProductList = new List<SAB00900DTO>();

        public int ChosenOption { get; set; } = 0;
        public List<RadioModel> Options { get; set; } = new List<RadioModel>
        {
            new RadioModel { Id = 1, Text = R_FrontUtility.R_GetMessage(typeof(Resources_Dummy_Class),"_Yes") },
            new RadioModel { Id = 2, Text = R_FrontUtility.R_GetMessage(typeof(Resources_Dummy_Class),"_No") },
        };

        public async Task GetProductById(int productId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00900DTO { ProductID = productId };
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);

                Product = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveProduct(SAB00900DTO poNewEntity, R_eConductorMode conductorMode)
        {
            var loEx = new R_Exception();
            SAB00900DTO loResult = null;

            try
            {
                loResult = await _model.R_ServiceSaveAsync(poNewEntity, (eCRUDMode)conductorMode);

                Product = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteProduct(int productId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00900DTO { ProductID = productId };
                await _model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetCategories()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllCategoryAsync();

                CategoryList = loResult.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetProductList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllProductAsync();
                ProductList = loResult.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }

    public class RadioModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
