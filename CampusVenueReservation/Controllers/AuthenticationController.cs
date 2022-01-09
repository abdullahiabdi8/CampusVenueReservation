using CampusVenueReservation.Models.ViewModels;
using CampusVenueReservation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampusVenueReservation.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            GenericRepository<DropDownViewModel> getRegion = new GenericRepository<DropDownViewModel>("sp_GetUserType", "Division");
            List<DropDownViewModel> Regions = getRegion.SPWithOutParameter().ToList();
            ViewBag.UserType = new SelectList(Regions, "ID", "Name");

            return View();
        }
        public ActionResult LandingPage()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateUser(CreateUserViewModel vm)
        {
            try
            {
                GenericRepository<ExecuteSPReturn> user = new GenericRepository<ExecuteSPReturn>("Sp_CreateUser", "Authentication/CreateUser");
                ExecuteSPReturn result = user.SPWithParameterSingleReturn(vm);

                if (result.StatusCode == 200)
                {
                    return Json(new { Status = true, msg = result.StatusMessage }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Status = false, msg = result.StatusMessage }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ErrorLog.LogTxt("CreateUser", "Authentication/CreateUser", ex.Message);
                return Json(new { Status = false, ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult UserLogin(CreateUserViewModel vm)
        {
            try
            {
                GenericRepository<UserLoginViewModel> user = new GenericRepository<UserLoginViewModel>("sp_Login", "Authentication/Login");
                var result = user.SPWithParameterSingleReturn(new { UserName = vm.UserName, Password = vm.Password });
                if (result != null)
                {
                    Session["UserName"] = result.UserName;
                    Session["UserID"] = result.ID;
                    Session["UserType"] = result.UserType;
                    return Json(new { Data = result, Status = true, msg = "Successfully Login" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Status = false, msg = "Please Verify Your Credential!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("CreateUser", "Authentication/CreateUser", ex.Message);
                return Json(new { Status = false, ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public JsonResult PasswordChange(ChangePasswordViewModel vm)
        {
            try
            {
                vm.UserID = Convert.ToInt32(Session["UserID"]);

                GenericRepository<ExecuteSPReturn> user = new GenericRepository<ExecuteSPReturn>("Sp_ChangePassword", "Authentication/CreateUser");
                ExecuteSPReturn result = user.SPWithParameterSingleReturn(vm);

                if (result.StatusCode > 0)
                {
                    return Json(new { Status = true, msg = result.StatusMessage }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Status = false, msg = result.StatusMessage }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ErrorLog.LogTxt("CreateUser", "Authentication/CreateUser", ex.Message);
                return Json(new { Status = false, ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Logout()
        {
            Session["UserID"] = null;
            Session["UserType"] = null;

            return Json(new { Status = true, msg = "Successfully Logout!" }, JsonRequestBehavior.AllowGet);
        }
    }
}