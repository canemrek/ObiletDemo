using Newtonsoft.Json;
using ObiletDemo.BusinessLogic.ServiceInterfaces;
using ObiletDemo.Domain.CommonModels;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using ObiletDemo.Domain.OBiletApiModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObiletDemo.BusinessLogic.Services
{
    public class ObiletSessionService : IObiletSessionService
    {
        private readonly IHttpClientFactory factory;

        public ObiletSessionService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }
        public async Task<Response<GetSessionResponseModel>> GetSession(GetSessionRequestModel request)
        {
            Response<GetSessionResponseModel> responseModel = new Response<GetSessionResponseModel>();
            try
            {
                var client = factory.CreateClient();
                client.DefaultRequestHeaders.Add($"Authorization", $"Basic {Settings.ObiletServiceInfo.ApiClientToken}");
                string url = Settings.ObiletServiceInfo.ApiUrl + "/client/getsession";
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetSessionResponseModel>(stringResult);
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
