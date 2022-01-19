using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace ObiletDemo.Domain.SelectListHelper
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> ToSelectList<T>(this List<T> list, string idPropertyName, string namePropertyName = "Name",int? selected=null)
        where T : class, new()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            list.ForEach(item =>
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = item.GetType().GetProperty(namePropertyName).GetValue(item).ToString(),
                    Value = item.GetType().GetProperty(idPropertyName).GetValue(item).ToString(),
                    Selected=selected.HasValue ? Convert.ToInt32(item.GetType().GetProperty(idPropertyName).GetValue(item).ToString())==selected.Value ? true:false:false
                });
            });

            return selectListItems;
        }
    }
}
