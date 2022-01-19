using ObiletDemo.Domain.CommonModels;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using ObiletDemo.Domain.OBiletApiModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ObiletDemo.BusinessLogic.ServiceInterfaces
{
    public interface IObiletApiService
    {
        
        /// <summary>
        /// Kullanılacak olan otobüs lokasyonlarını Obilet servisinden çeker.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<GetBusLocationsResponseModel>> GetBusLocations(GetBussLocationsRequestModel request);
        /// <summary>
        /// Seçilen kalkış ve varış noktası arasında seçilen tarihte yer alan seferleri listeler
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<GetBusJourneysResponseModel>> GetBusJourneys(GetBusJourneysRequestModel request);
    }
}
