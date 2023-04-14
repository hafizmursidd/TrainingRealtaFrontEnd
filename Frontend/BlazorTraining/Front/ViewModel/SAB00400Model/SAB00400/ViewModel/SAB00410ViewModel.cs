using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00400Common;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00400.ViewModel
{
    public class SAB00410ViewModel : R_ViewModel<SAB00410DTO>
    {
        private SAB00400Model _SAB00400Model = null;
        public ObservableCollection<SAB00410DTO> TerritoryList { get; set; } = new ObservableCollection<SAB00410DTO>();

        public SAB00410ViewModel()
        {
            _SAB00400Model = new SAB00400Model();
        }

        public async Task GetListTerritoryByRegionId(int piRegionId)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00400Model.GetTerritoryListByRegionId(piRegionId); ;
                TerritoryList = new ObservableCollection<SAB00410DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

       //{
            //var loEx = new R_Exception();
            //SAB00410DTO loResult = null;

            //try
            //{
            //    var loParam = new SAB00410DTO { RegionId = piTerritoryId };
            //    //loResult = await _SAB00400Model.GetTerritory(loParam);
            //}
            //catch (Exception ex)
            //{
            //    loEx.Add(ex);
            //}

            //loEx.ThrowExceptionIfErrors();

            //return loResult;
        //}

       // public async Task<SAB01310DTO> SaveProduct(SAB01310DTO poNewEntity, R_eConductorMode peConductorMode)
       // {

       //     throw NotImplementedException;

            //var loEx = new R_Exception();
            //SAB01310DTO loResult = null;

            //try
            //{
            //   // loResult = await _SAB01300Model.SaveProduct(poNewEntity, (eCRUDMode)peConductorMode);
            //}
            //catch (Exception ex)
            //{
            //    loEx.Add(ex);
            //}

            //loEx.ThrowExceptionIfErrors();

            //return loResult;
     //   }

        public async Task DeleteProduct(int productId)
        {
            var loEx = new R_Exception();

            try
            {
                //var loParam = new SAB01310DTO { ProductID = productId };
                //await _SAB01300Model.DeleteProduct(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
