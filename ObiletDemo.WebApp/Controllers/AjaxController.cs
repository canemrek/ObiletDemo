using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObiletDemo.BusinessLogic.ServiceInterfaces;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletDemo.WebApp.Controllers
{
    public class AjaxController : BaseController<AjaxController>
    {
        private readonly IObiletApiService obiletApiService;

        public AjaxController(IObiletApiService obiletApiService)
        {
            this.obiletApiService = obiletApiService;
        }
        public async Task<JsonResult> Index(string term, int? size)
        {
            
            size = 10;
            var locations = await obiletApiService.GetBusLocations(new Domain.OBiletApiModels.RequestModels.GetBussLocationsRequestModel
            {
                data = term,
                devicesession = new DeviceSession { deviceid = currentUser.deviceid, sessionid = currentUser.sessionid },
                date = DateTime.Now,
                language = "tr-TR"
            });

            if (size.HasValue)
                return Json(locations.Data.data.Take(10));
            return Json(locations.Data.data);
        }
    }
}
