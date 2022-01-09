using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class UserLoginViewModel
    {
        public int ID { get; set; }

        public int UserType { get; set; }

        public string UserName { get; set; }
    }
}