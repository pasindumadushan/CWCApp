using CWCApp.Application.Services;
using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class LoginController : Controller
    {
        LoginExistService loginExistService = new LoginExistService();
        UpdatePasswordService updatePasswordService = new UpdatePasswordService();
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        ServiceProviderProfileRepository serviceProviderProfileRepository = new ServiceProviderProfileRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UserProfile userProfile)
        {
            var objResult = loginExistService.loginExist(userProfile);
            if(objResult == 3)
            {
                var objEntity = userProfileRepository.GetUserProfileByEmail(userProfile);
                var objEntity2 = serviceProviderProfileRepository.GetServiceProviderProfileByUserId(objEntity.UserId);

                if(objEntity2 != null)
                {
                    Session["UserServiceProfileType"] = objEntity2.ServiceProviderTypeId;
                }
                else
                {
                    Session["UserServiceProfileType"] = 10;
                }

                Session["UserName"] = objEntity.UserName;
                Session["UserId"] = objEntity.UserId;
                Session["Email"] = objEntity.Email;
                Session["UserTypeId"] = objEntity.UserTypeId;
            }
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConfirmEmail()
        {
            return View();
        }

        public ActionResult SendVerificationCode(UserProfile userProfile)
        {
            var objResult = 0;
            try
            {
                Random rnd = new Random();
                int code = rnd.Next(10000000, 99999999);

                MailMessage Mail = new MailMessage();
                MailAddress ma = new MailAddress("jefffranko7@gmail.com");
                Mail.From = ma;
                Mail.To.Add(userProfile.Email);
                Mail.Subject = "CWCApp Recovery Code";
                string htmlString = @"<html>
                      <body>
                      <H2>Here's your new recovery code</H2>
                      <p>If you ever need a recovery access to your account, this code use for tempary password. We strongly recommended to update your password with new one.</p>
                      <p>If you previously had a recovery code, it is no longer valid. Use this new code instead</br></p>
                      <p>Your new code is <b>" + code + @"</b></p>  
                      <p>Thank you!</br></p>
                      </body>
                      </html>
                     ";

                Mail.Body = htmlString;
                Mail.IsBodyHtml = true;

                SmtpClient smtpMailObj = new SmtpClient();
                smtpMailObj.Host = "smtp.gmail.com";
                smtpMailObj.Credentials = new System.Net.NetworkCredential("jefffranko7@gmail.com", "0382291409");
                smtpMailObj.Port = 587;
                smtpMailObj.EnableSsl = true;
                smtpMailObj.Send(Mail);

                Session["recovery code"] = code;
                objResult = 1;
            }
            catch (Exception)
            {
                throw;
            }

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangePassword(string email)
        {
            ViewBag.ViewBagEmail = email;
            ViewBag.ViewBagRecoveryCode= System.Web.HttpContext.Current.Session["recovery code"];
            return View();
        }

        public ActionResult UpdatePassword(UserProfile userProfile)
        {
            var objResult = updatePasswordService.updatePassword(userProfile);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["UserId"] = null;
            Session["Email"] = null;
            Session["recovery code"] = null;
            Session["UserTypeId"] = null;

            return View("Index");
        }

    }
}