using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class UserTypeController : Controller
    {
        UserTypeMstrRepository userTypeMstrRepository = new UserTypeMstrRepository();
        // GET: UserType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAllUserTypes()
        {
            var objResult = userTypeMstrRepository.GetUserTypeMstrList();
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}