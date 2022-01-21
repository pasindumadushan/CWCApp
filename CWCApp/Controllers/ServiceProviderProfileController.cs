using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class ServiceProviderProfileController : Controller
    {
        ServiceProviderProfileRepository serviceProviderProfileRepository = new ServiceProviderProfileRepository();
        ServiceProviderMstrRepository serviceProviderMstrRepository = new ServiceProviderMstrRepository();

        // GET: ServiceProviderProfile
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult LoadServiceTypes()
        {
            var objResult = serviceProviderMstrRepository.GetServiceProviderMstrList();
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadAllFields()
        {
            var objResult = serviceProviderProfileRepository.GetServiceProviderProfileByUserId((int)Session["UserId"]);
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveServiceProviderProfile(ServiceProviderProfile serviceProviderProfile)
        {
            ServiceProviderProfile objResult;
            serviceProviderProfile.UserId = (int?)Session["UserId"];
            serviceProviderProfile.IsActive = true;
            
            if(serviceProviderProfile.ServiceId == 0)
            {
                objResult = serviceProviderProfileRepository.PostServiceProviderProfile(serviceProviderProfile);
            } 
            else
            {
                objResult = serviceProviderProfileRepository.UpdateServiceProviderProfile(serviceProviderProfile.ServiceId,serviceProviderProfile);
            }

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

    }
}