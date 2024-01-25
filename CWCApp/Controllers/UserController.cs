using CWCApp.Application.Services;
using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        UpdateUserProfileService updateUserProfileService = new UpdateUserProfileService();
        // GET: User 

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("LoadAllFields")]
        public ActionResult LoadAllFields()
        {
            var objResult = userProfileRepository.GetUserProfileById((int)Session["UserId"]);
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SaveUserProfile")]
        public ActionResult SaveUserProfile(HttpPostedFileBase imageFile, string data)
        {
            
            UserProfile userProfile = JsonConvert.DeserializeObject<UserProfile>(data);

            if (imageFile != null)
            {
                string extension = Path.GetExtension(imageFile.FileName);
                var fileName = "ProfilePic-" + userProfile.UserId + extension;
                userProfile.ProfilePicture = "~/Images/ProfilePhotos/" + fileName;

                imageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/ProfilePhotos/" + fileName));
            }

            UserProfile objResult;
            userProfile.IsActive = true;

            if (userProfile.UserId == 0)
            {
                objResult = userProfileRepository.PostUserProfile(userProfile);
            }
            else
            {
                objResult = updateUserProfileService.UpdateUserProfile(userProfile);
            }

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}