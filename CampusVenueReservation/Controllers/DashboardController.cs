using CampusVenueReservation.Models.ViewModels;
using CampusVenueReservation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampusVenueReservation.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            DashboardDataViewmodel data = new DashboardDataViewmodel();

            GenericRepository<DashboardViewModel, GetAllRequestedplaceViewModel> getRegion = new GenericRepository<DashboardViewModel, GetAllRequestedplaceViewModel>("sp_getAllDashboardData", "Dashboard");
            var result  = getRegion.ExecuteStoreProcedure(new { UserID= UserID });

            data.RequestCount = result.Item1.FirstOrDefault();
            data.RequestList = result.Item2.ToList();

            return View(data);
        }
    }
}