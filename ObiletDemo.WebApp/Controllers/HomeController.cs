using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObiletDemo.BusinessLogic.ServiceInterfaces;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using ObiletDemo.Domain.UserManager;
using ObiletDemo.WebApp.ViewModels;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletDemo.WebApp.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly IObiletApiService obiletApiService;

        public HomeController(IObiletApiService obiletApiService)
        {
            this.obiletApiService = obiletApiService;
        }
        public async Task<IActionResult> Index()
        {
            throw new Exception();
            IndexViewModel model = new IndexViewModel();
            var locations = await obiletApiService.GetBusLocations(new Domain.OBiletApiModels.RequestModels.GetBussLocationsRequestModel
            {
                data =null,
                devicesession = new DeviceSession { deviceid = currentUser.deviceid, sessionid = currentUser.sessionid },
                date = DateTime.Now,
                language = "tr-TR"
            });

            if (locations.Status)
            {
                model.DepartureDate = Manager.GetUserDepartureDate();
                var defaultDeparture = locations.Data.data.FirstOrDefault();
                model.DepartureId =Manager.GetUserDepartureLocation()!=0 ? Manager.GetUserDepartureLocation() : defaultDeparture!=null ? defaultDeparture.id:1;
                model.ArrivalId =Manager.GetUserArrivalLocation()!=0 ? Manager.GetUserArrivalLocation() : locations.Data.data.FirstOrDefault(x => x.id != defaultDeparture.id && x.parentid != defaultDeparture.parentid).id;
                ViewBag.DepartureList = new SelectList(locations.Data.data.ToList(), "id", "name");
                ViewBag.ArrivalList = new SelectList(locations.Data.data.ToList(), "id", "name");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List(IndexViewModel model)
        {
            var journey = await obiletApiService.GetBusJourneys(new Domain.OBiletApiModels.RequestModels.GetBusJourneysRequestModel
            {
                data = new Data { originid = model.DepartureId, destinationid = model.ArrivalId, departuredate = model.DepartureDate },
                devicesession = new Domain.OBiletApiModels.RequestModels.DeviceSession { deviceid = currentUser.deviceid, sessionid = currentUser.sessionid },
                date = DateTime.Now,
                language = "tr-TR"
            });
            if (journey.Status && journey.Data != null && journey.Data.data != null)
            {
                ViewBag.Title = $"{journey.Data.data.FirstOrDefault().originlocation} - {journey.Data.data.FirstOrDefault().destinationlocation}";
                ViewBag.Date = model.DepartureDate.ToString("dd MMM yyyy dddd");
                return View(journey.Data.data.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

        }


    }
}
