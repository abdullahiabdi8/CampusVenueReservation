using CampusVenueReservation.Models.ViewModels;
using CampusVenueReservation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampusVenueReservation.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Index()
        {
            GenericRepository<DropDownViewModel> getRegion = new GenericRepository<DropDownViewModel>("sp_GetUserType", "Division");
            List<DropDownViewModel> Regions = getRegion.SPWithOutParameter().ToList();
            ViewBag.UserType = new SelectList(Regions, "ID", "Name");

            return View();
        }

        public ActionResult GetAllUsers(string SearchCriteria, int LastRowId = 0, int PageSize = 25, int Direction = 0)
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
            //int UserID = Convert.ToInt32(Session["UserID"]);
            List<GetAllUsersViewModel> data = new List<GetAllUsersViewModel>();
            try
            {
                GenericRepository<GetAllUsersViewModel> repo = new GenericRepository<GetAllUsersViewModel>("sp_GetAllUsers", "GetStolenList");
                data = repo.SPWithParameter(new { LastRowID = tempLastRowId, PageSize = PageSize, SearchCriteria = SearchCriteria }).ToList();
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("GetVenueList", "Venue/GetVenueList", ex.ToString());
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
        public JsonResult Delete(int ID)
        {
            try
            {

                GenericRepository<ExecuteSPReturn> Request = new GenericRepository<ExecuteSPReturn>("sp_DeleteUser", "Delete");
                var result = Request.SPWithParameterSingleReturn(new { ID = ID });
                if (result != null)
                {
                    return Json(new { Status = true, msg = "Data updated successfully!" }, JsonRequestBehavior.AllowGet);
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