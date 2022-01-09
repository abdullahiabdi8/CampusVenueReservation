using CampusVenueReservation;
using CampusVenueReservation.Models.ViewModels;
using CampusVenueReservation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Campus_Venue_Reservation.Controllers
{
    public class ReservePlaceController : Controller
    {
        // GET: ReservePlace
        public ActionResult Index()
        {
            GenericRepository <DropDownViewModel> getRegion = new GenericRepository<DropDownViewModel>("sp_GetStudent", "Division");
            List<DropDownViewModel> Regions = getRegion.SPWithOutParameter().ToList();
            ViewBag.Student = new SelectList(Regions, "ID", "Name");

            GenericRepository<DropDownViewModel> getplace = new GenericRepository<DropDownViewModel>("sp_GetPlaces", "Division");
            List<DropDownViewModel> places = getplace.SPWithOutParameter().ToList();
            ViewBag.Places = new SelectList(places, "ID", "Name");

            GenericRepository<DropDownViewModel> getuser = new GenericRepository<DropDownViewModel>("sp_GetUserType", "Division");
            List<DropDownViewModel> userType = getuser.SPWithOutParameter().Where(x=>x.ID !=4).ToList();
            ViewBag.UserType = new SelectList(userType, "ID", "Name");

            return View();
        }

        public JsonResult ReservePlace(ReservePlaceViewModel vm)
        {
            try
            {
                vm.StudentID = Convert.ToInt32(Session["UserID"]);
                vm.UserID = Convert.ToInt32(Session["UserID"]);
                vm.UserType = Convert.ToInt32(Session["UserType"]);

                GenericRepository<ExecuteSPReturn> Request = new GenericRepository<ExecuteSPReturn>("sp_Requestforplace", "ReservePlace");
                var result = Request.SPWithParameterSingleReturn(vm);
                if(result != null)
                {
                    return Json(new { Status=true,msg="Data Inserted Successfully!"},JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Status = false, msg = "Internet Issue please Try Again!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("", "", ex.ToString());
                return Json(new { Status = false, msg = "Internet Issue please Try Again!" }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult GetRequestedplace(string SearchCriteria, int LastRowId = 0, int PageSize = 25, int Direction = 0)
        {

            int tempLastRowId = LastRowId;
            if (Direction < 0)
                tempLastRowId = LastRowId - PageSize;
            else if (Direction > 0)
                tempLastRowId = LastRowId + PageSize;
            else
                tempLastRowId = LastRowId;
            if (tempLastRowId < 0)
                tempLastRowId = 0;
            int UserID = Convert.ToInt32(Session["UserID"]);
            List<GetAllRequestedplaceViewModel> data = new List<GetAllRequestedplaceViewModel>();
            try
            {
                GenericRepository<GetAllRequestedplaceViewModel> repo = new GenericRepository<GetAllRequestedplaceViewModel>("sp_GetAllRequestedPlace", "GetStolenList");
                data = repo.SPWithParameter(new { LastRowID = tempLastRowId, PageSize = PageSize, SearchCriteria = SearchCriteria, UserID= UserID }).ToList();
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("GetRequestedplace", "ReservedPlace/GetRequestedplace", ex.ToString());
                return Json(new { Status = false, ex.Message }, JsonRequestBehavior.AllowGet);
            }
            if (data.Count > 0)
            {
                return Json(new { Data = data, Status = true, LastRowID = tempLastRowId, PageSize = PageSize, TotalRecord = data.FirstOrDefault().TotalRecord, Count = data.Count }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Data = data, Status = false, LastRowID = tempLastRowId, PageSize = PageSize, TotalRecord = data.Count, Count = data.Count }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}