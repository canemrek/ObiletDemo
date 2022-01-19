using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletDemo.WebApp.ViewModels
{
    public class IndexViewModel
    {
        public int DepartureId { get; set; }
        public int ArrivalId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }
    }
}
