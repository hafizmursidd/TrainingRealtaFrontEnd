using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00600Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00600Model
{
    public class SAB00600ViewModel : R_ViewModel<SAB00600DTO>
    {
        private SAB00600Model _model = null;

        public ObservableCollection<SAB00600DTO> CustomerList { get; set; } = new ObservableCollection<SAB00600DTO>();

        public SAB00600ViewModel()
        {
            _model = new SAB00600Model();
        }

        public async Task GetCustomerList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetCustomerListAsync();
                CustomerList = new ObservableCollection<SAB00600DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<SAB00600DTO> GetCustomerById(string customerId)
        {
            var loEx = new R_Exception();
            SAB00600DTO loResult = null;

            try
            {
                var loParam = new SAB00600DTO { CustomerID = customerId };
                loResult = await _model.GetCustomerAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB00600DTO> SaveCustomer(SAB00600DTO poNewEntity, R_eConductorMode peConductorMode)
        {
            var loEx = new R_Exception();
            SAB00600DTO loResult = null;

            try
            {
                loResult = await _model.SaveCustomerAsync(poNewEntity, (eCRUDMode)peConductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteCustomer(string customerId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00600DTO { CustomerID = customerId };
                await _model.DeleteCustomerAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
