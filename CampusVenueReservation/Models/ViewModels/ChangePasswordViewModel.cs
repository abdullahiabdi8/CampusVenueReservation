using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusVenueReservation.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string oldPassword { get; set; }
        public string NewPassword { get; set; }

        public int UserID { get; set; }

    }
}