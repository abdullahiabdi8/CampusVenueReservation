using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class GetAllRequestedplaceViewModel
    {
        public int ID { get; set; }

        public string RequestedBy { get; set; }

        public string RequestedTo { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string RemarkID { get; set; }

        public string PlaceID { get; set; }

        public string Status { get; set; }

        public int TotalRecord { get; set; }

    }
}