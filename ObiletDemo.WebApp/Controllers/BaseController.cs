using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObiletDemo.BusinessLogic.ServiceInterfaces;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using ObiletDemo.Domain.UserManager;
using Microsoft.Extensions.DependencyInjection;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace ObiletDemo.WebApp.Controllers
{
    public abstract class BaseController<T> : Controller where T:class
    {
        public DeviceSession currentUser;
        private IObiletSessionService _sessionService;
        private IBrowserDetector _browserDetector;
        public static HttpContext _httpContext => new HttpContextAccessor().HttpContext;

    
        protected IBrowserDetector browserDetector => _browserDetector ?? (_browserDetector = _httpContext.RequestServices.GetService<IBrowserDetector>());
        protected IObiletSessionService obiletSessionService => _sessionService ?? (_sessionService = _httpContext.RequestServices.GetService<IObiletSessionService>());
        public BaseController()
        {
            //var userAgent = _httpContext.Request.Headers["User-Agent"];
            //currentUser = Manager.GetUserInfo();
            if (currentUser==null)
            {
                
                //var uaParser = Parser.GetDefault();
                //ClientInfo browser = uaParser.Parse(userAgent);
                var browser = browserDetector.Browser;

                var session = obiletSessionService.GetSession(new Domain.OBiletApiModels.RequestModels.GetSessionRequestModel
                {
                    type = 1,
                    browser = new Domain.OBiletApiModels.RequestModels.Browser { name = browser.Name, version = browser.Version },
                    connection = new Domain.OBiletApiModels.RequestModels.Connection { ipaddress = _httpContext.Connection.RemoteIpAddress.ToString() != "::1" ? _httpContext.Connection.RemoteIpAddress.ToString() : "127.0.0.1", port = _httpContext.Connection.RemotePort.ToString() }
                }).Result;
                Manager.SetUserInfo(new DeviceSession { deviceid = session.Data.data.deviceid, sessionid = session.Data.data.sessionid });
                currentUser = new DeviceSession { deviceid = session.Data.data.deviceid, sessionid = session.Data.data.sessionid };
            }
        }
    }
}
