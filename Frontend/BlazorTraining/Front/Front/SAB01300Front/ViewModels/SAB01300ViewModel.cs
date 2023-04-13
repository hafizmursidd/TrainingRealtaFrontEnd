using CategoryCommon.DTOs;
using CategoryModels;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using System.Collections.ObjectModel;

namespace SAB01300Front.ViewModels
{
    public class SAB01300ViewModel : R_ViewModel<CategoryDTO>
    {
        private CategoryModel _categoryModel = new();

        public ObservableCollection<CategoryDTO> CategoryList { get; set; } = new();

        public async Task GetCategoryList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _categoryModel.GetCategoryListAsync();
                CategoryList = new ObservableCollection<CategoryDTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<CategoryDTO> GetCategory(int piCategoryId)
        {
            var loEx = new R_Exception();
            CategoryDTO loResult = null;

            try
            {
                var loParam = new CategoryDTO { CategoryID = piCategoryId };
                loResult = await _categoryModel.GetCategoryAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<CategoryDTO> SaveCategory(CategoryDTO poNewEntity, R_eConductorMode peConductorMode)
        {
            var loEx = new R_Exception();
            CategoryDTO loResult = null;

            try
            {
                loResult = await _categoryModel.SaveCategoryAsync(poNewEntity, (eCRUDMode)peConductorMode);
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
                var loParam = new CategoryDTO { CategoryID = categoryId };
                await _categoryModel.DeleteCategoryAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
