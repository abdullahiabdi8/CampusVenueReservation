using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class DashboardDataViewmodel
    {
        public DashboardViewModel RequestCount { get; set; }

        public List<GetAllRequestedplaceViewModel> RequestList { get; set; }

    }
}