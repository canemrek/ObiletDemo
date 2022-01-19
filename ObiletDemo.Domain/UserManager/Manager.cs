using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ObiletDemo.Domain.Extensions;
using ObiletDemo.Domain.OBiletApiModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.UserManager
{
    public static class Manager
    {
        public static HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        public static void SetUserInfo(DeviceSession deviceSession)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(30);
            var info = JsonConvert.SerializeObject(deviceSession);
            _httpContext.Response.Cookies.Append("uic", info.ToBase64Encode());
        }

        public static DeviceSession GetUserInfo()
        {
            var value = _httpContext.Request.Cookies["uic"];
            return JsonConvert.DeserializeObject<DeviceSession>(value.ToBase64Decode());
        }

        public static DateTime GetUserDepartureDate()
        {
            DateTime returnDate = DateTime.Now;

            try
            {
                var value = GetCookieValue(Consts.DefaultValues.DepartureDateCookieName);
                returnDate = DateTime.ParseExact(value, "MM/dd/yyyy", null);
                returnDate = returnDate < DateTime.Now ? DateTime.Now : returnDate;
            }
            catch (Exception)
            {
                
            }
           
            return returnDate;
        }

        public static int GetUserDepartureLocation()
        {
            var value = GetCookieValue(Consts.DefaultValues.DepartureLocationCookieName);
            int returnValue =0;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static int GetUserArrivalLocation()
        {
            var value = GetCookieValue(Consts.DefaultValues.ArrivalLocationCookieName);
            int returnValue = 0;
            int.TryParse(value, out returnValue);
            return returnValue;
        }

        public static string GetCookieValue(string name)
        {
            return _httpContext.Request.Cookies[name];
        }
    }
}
