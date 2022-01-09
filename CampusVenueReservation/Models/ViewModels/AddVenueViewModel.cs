using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class AddVenueViewModel
    {
        public string Name { get; set; }

        public String Capacity { get; set; }

        public decimal Costs { get; set; }
    }
}