using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        UserProfileRepository userProfileRepository = new UserProfileRepository();

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("EmailExist")]
        public ActionResult EmailExist(UserProfile userProfile)
        {
            var objResult = userProfileRepository.GetUserProfileByEmail(userProfile);
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("Register")]
        public ActionResult Register(string userProfiledata, string customCheck)
        {

            UserProfile userProfile = JsonConvert.DeserializeObject<UserProfile>(userProfiledata);
            string customCheck2 = JsonConvert.DeserializeObject<string>(customCheck);

            if(customCheck2 == "true")
            {
                userProfile.UserTypeId = 4;
            }
            else
            {
                userProfile.UserTypeId = 1;
            }
            userProfile.IsActive = true;
            var objResult = userProfileRepository.PostUserProfile(userProfile);
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}