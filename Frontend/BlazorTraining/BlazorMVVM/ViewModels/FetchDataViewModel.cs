using BlazorMVVM.DTOs;
using BlazorMVVM.Models;

namespace BlazorMVVM.ViewModels
{
    public class FetchDataViewModel
    {
        private readonly FetchDataModel _fetchDataModel;
        public List<WeatherForecast> forecasts;

        public FetchDataViewModel(FetchDataModel fetchDataModel)
        {
            _fetchDataModel = fetchDataModel;
        }

        public async Task RetrieveForecastsAsync()
        {
            var loResult = await _fetchDataModel.RetrieveForecast();

            forecasts = loResult.ToList();
        }
    }
}
