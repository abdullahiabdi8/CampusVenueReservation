using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class GetAllVenueViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Capacity { get; set; }

        public decimal Costs { get; set; }

        public int TotalRecord { get; set; }

    }
}