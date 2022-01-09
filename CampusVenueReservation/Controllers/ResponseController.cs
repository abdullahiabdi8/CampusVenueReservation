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
    public class ResponseController : Controller
    {
        // GET: Response
        public ActionResult Index()
        {
            GenericRepository<DropDownViewModel> getRegion = new GenericRepository<DropDownViewModel>("sp_GetStudent", "Division");
            List<DropDownViewModel> Regions = getRegion.SPWithOutParameter().ToList();
            ViewBag.Student = new SelectList(Regions, "ID", "Name");
            return View();
        }

        public ActionResult GetResponseplace(string SearchCriteria, int LastRowId = 0, int PageSize = 25, int Direction = 0,int? StudentID=null)
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
            int UserType = Convert.ToInt32(Session["UserType"]);

            List<GetAllRequestedplaceViewModel> data = new List<GetAllRequestedplaceViewModel>();
            try
            {
                GenericRepository<GetAllRequestedplaceViewModel> repo = new GenericRepository<GetAllRequestedplaceViewModel>("sp_GetAllResponsePlace", "GetStolenList");
                data = repo.SPWithParameter(new { LastRowID = tempLastRowId, PageSize = PageSize, SearchCriteria = SearchCriteria , UserType = UserType, StudentID= StudentID }).ToList();
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

        public JsonResult Remarks(int ID,string Remarks,int Status)
        {
            try
            {
                int UserID = Convert.ToInt32(Session["UserID"]);
                

                GenericRepository<ExecuteSPReturn> Request = new GenericRepository<ExecuteSPReturn>("sp_ReponseVenue", "ReservePlace");
                var result = Request.SPWithParameterSingleReturn(new {ID=ID,Remarks=Remarks, UserID= UserID, Status= Status });
                if (result != null)
                {
                    return Json(new { Status = true, msg = "Data Inserted Successfully!" }, JsonRequestBehavior.AllowGet);
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
    }
}