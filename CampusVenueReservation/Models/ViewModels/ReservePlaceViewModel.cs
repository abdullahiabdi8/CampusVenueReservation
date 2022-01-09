using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class ReservePlaceViewModel
    {
        public int StudentID { get; set; }

        public int PlaceID { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int UserID { get; set; }

        public int UserType { get; set; }

        public int RequestTo { get; set; }



    }
}