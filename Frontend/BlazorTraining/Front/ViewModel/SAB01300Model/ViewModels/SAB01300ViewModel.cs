using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB01300Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB01300Model.ViewModels
{
    public class SAB01300ViewModel : R_ViewModel<SAB01300DTO>
    {
        private SAB01300Model _SAB01300Model = new SAB01300Model();

        public ObservableCollection<SAB01300DTO> CategoryList { get; set; } = new ObservableCollection<SAB01300DTO>();

        public async Task GetCategoryList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB01300Model.GetCategoryListAsync();
                CategoryList = new ObservableCollection<SAB01300DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<SAB01300DTO> GetCategory(int piCategoryId)
        {
            var loEx = new R_Exception();
            SAB01300DTO loResult = null;

            try
            {
                var loParam = new SAB01300DTO { CategoryID = piCategoryId };
                loResult = await _SAB01300Model.GetCategoryAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB01300DTO> SaveCategory(SAB01300DTO poNewEntity, R_eConductorMode peConductorMode)
        {
            var loEx = new R_Exception();
            SAB01300DTO loResult = null;

            try
            {
                loResult = await _SAB01300Model.SaveCategoryAsync(poNewEntity, (eCRUDMode)peConductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB01300DTO { CategoryID = categoryId };
                await _SAB01300Model.DeleteCategoryAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
