using Newtonsoft.Json;
using ObiletDemo.BusinessLogic.ServiceInterfaces;
using ObiletDemo.Domain.CommonModels;
using ObiletDemo.Domain.Extensions;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using ObiletDemo.Domain.OBiletApiModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletDemo.BusinessLogic.Services
{
    public class ObiletApiService : IObiletApiService
    {
        private readonly IHttpClientFactory factory;

        public ObiletApiService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

       
        public async Task<Response<GetBusLocationsResponseModel>> GetBusLocations(GetBussLocationsRequestModel request)
        {
            Response<GetBusLocationsResponseModel> responseModel = new Response<GetBusLocationsResponseModel>();
            try
            {
                var client = factory.CreateClient();
                client.DefaultRequestHeaders.Add($"Authorization", $"Basic {Settings.ObiletServiceInfo.ApiClientToken}");
                string url = Settings.ObiletServiceInfo.ApiUrl + "/location/getbuslocations";
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetBusLocationsResponseModel>(stringResult);
                    responseModel.Status = true;
                    responseModel.Data = result;
                }
            }
            catch (Exception ex)
            {
                //log tutalım
                responseModel.Status = false;
                responseModel.Message = "Bir hata meydana geldi.";
            }
            return responseModel;
        }

        public async Task<Response<GetBusJourneysResponseModel>> GetBusJourneys(GetBusJourneysRequestModel request)
        {
            Response<GetBusJourneysResponseModel> responseModel = new Response<GetBusJourneysResponseModel>();
            try
            {
                var client = factory.CreateClient();
                client.DefaultRequestHeaders.Add($"Authorization", $"Basic {Settings.ObiletServiceInfo.ApiClientToken}");
                string url = "https://v2-api.obilet.com/api/journey/getbusjourneys";
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetBusJourneysResponseModel>(stringResult);
                    responseModel.Status = true;
                    responseModel.Data = result;
                }
            }
            catch (Exception ex)
            {
                //log tutalım
                responseModel.Status = false;
                responseModel.Message = "Bir hata meydana geldi.";
            }
            return responseModel;
        }
    }
}
