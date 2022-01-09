using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class GetAllUsersViewModel
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string  Email { get; set; }

        public string UserType { get; set; }

        public int TotalRecord { get; set; }

    }
}