using ObiletDemo.Domain.CommonModels;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using ObiletDemo.Domain.OBiletApiModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObiletDemo.BusinessLogic.ServiceInterfaces
{
    public interface IObiletSessionService
    {
        /// <summary>
        /// Kullanıcının Obilet servisini kullanması için session oluşturur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Response<GetSessionResponseModel>> GetSession(GetSessionRequestModel request);
    }
}
