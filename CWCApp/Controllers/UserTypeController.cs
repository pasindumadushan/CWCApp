using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{

    [Route("api/[controller]")]
    public class UserTypeController : Controller
    {
        UserTypeMstrRepository userTypeMstrRepository = new UserTypeMstrRepository();
        // GET: UserType

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("LoadAllUserTypes")]
        public ActionResult LoadAllUserTypes()
        {
            var objResult = userTypeMstrRepository.GetUserTypeMstrList();
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}