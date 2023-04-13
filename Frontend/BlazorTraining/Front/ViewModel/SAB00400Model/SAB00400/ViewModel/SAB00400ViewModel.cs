using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00400Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SAB00400.ViewModel
{
    public class SAB00400ViewModel :  R_ViewModel<SAB00400DTO>
    {
        private SAB00400Model _modelSAB00400 = new SAB00400Model ();
        public ObservableCollection <SAB00400DTO> RegionList { get; set; } = new ObservableCollection<SAB00400DTO> ();


        public async Task GetRegionList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _modelSAB00400.GetRegionListAsync();
                RegionList = new ObservableCollection<SAB00400DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<SAB00400DTO> GetRegion(int piRegionId)
        {
            var loEx = new R_Exception();
            SAB00400DTO loResult = null;

            try
            {
                var loParam = new SAB00400DTO { RegionId = piRegionId };
                loResult = await _modelSAB00400.GetRegionAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
    }
}
