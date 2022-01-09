using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalRequest { get; set; }

        public int Pending { get; set; }

        public int Accepted { get; set; }

        public int Rejected { get; set; }
        public int TodayTotalRequest { get; set; }

        public int TodayPending { get; set; }

        public int TodayAccepted { get; set; }

        public int TodayRejected { get; set; }

    }
}