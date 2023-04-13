using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00700Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00700Model
{
    public class SAB00700ViewModel : R_ViewModel<SAB00700DTO>
    {
        private SAB00700Model _model = new SAB00700Model();

        public ObservableCollection<SAB00700GridDTO> CategoryList = new ObservableCollection<SAB00700GridDTO>();

        public SAB00700DTO Category = new SAB00700DTO();

        public async Task GetCategoryList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetAllCategoryAsync();
                CategoryList = new ObservableCollection<SAB00700GridDTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task GetCategoryById(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00700DTO { CategoryID = piCategoryId };
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);

                Category = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveCategory(SAB00700DTO poEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.R_ServiceSaveAsync(poEntity, peCRUDMode);

                Category = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteCategory(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00700DTO { CategoryID = piCategoryId };
                await _model.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
