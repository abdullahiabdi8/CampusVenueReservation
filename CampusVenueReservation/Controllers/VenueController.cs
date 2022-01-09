using CampusVenueReservation.Models.ViewModels;
using CampusVenueReservation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampusVenueReservation.Controllers
{
    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Create(AddVenueViewModel vm)
        {
            try
            {
                //vm.UserID = Convert.ToInt32(Session["UserID"]);
                //vm.UserType = Convert.ToInt32(Session["UserType"]);

                GenericRepository<ExecuteSPReturn> Request = new GenericRepository<ExecuteSPReturn>("sp_AddVenue", "Create");
                var result = Request.SPWithParameterSingleReturn(vm);
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

        public ActionResult GetVenueList(string SearchCriteria, int LastRowId = 0, int PageSize = 25, int Direction = 0)
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
            List<GetAllVenueViewModel> data = new List<GetAllVenueViewModel>();
            try
            {
                GenericRepository<GetAllVenueViewModel> repo = new GenericRepository<GetAllVenueViewModel>("sp_GetAllVenue", "GetStolenList");
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
        [HttpPost]
        public JsonResult Edit(int ID)
        {
            try
            {

                GenericRepository<GetAllVenueViewModel> Request = new GenericRepository<GetAllVenueViewModel>("sp_GetVenueAgainstID", "Edit");
                var result = Request.SPWithParameterSingleReturn(new { ID = ID });
                if (result != null)
                {
                    return Json(new { Status = true, Data = result }, JsonRequestBehavior.AllowGet);
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

        public JsonResult Update(UpdateVenueViewModel vm)
        {
            try
            {
                //vm.UserID = Convert.ToInt32(Session["UserID"]);
                //vm.UserType = Convert.ToInt32(Session["UserType"]);

                GenericRepository<ExecuteSPReturn> Request = new GenericRepository<ExecuteSPReturn>("sp_UpdateVenue", "Create");
                var result = Request.SPWithParameterSingleReturn(vm);
                if (result != null)
                {
                    return Json(new { Status = true, msg = result.StatusMessage }, JsonRequestBehavior.AllowGet);
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
        public JsonResult Delete(int ID)
        {
            try
            {

                GenericRepository<ExecuteSPReturn> Request = new GenericRepository<ExecuteSPReturn>("sp_DeleteVenue", "Delete");
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