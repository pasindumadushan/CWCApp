using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using CWCApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Application.Services
{
    public class RateServices
    {
        ServiceProviderProfileRepository serviceProviderProfileRepository = new ServiceProviderProfileRepository();
        RateRepository rateRepository = new RateRepository();
        FeedBackRepository feedBackRepository = new FeedBackRepository();
        ServiceFeedBackRepository serviceFeedBackRepository = new ServiceFeedBackRepository();
        TOWServiceRepository towServiceRepository = new TOWServiceRepository();
        RepairServiceRepository repairServiceRepository = new RepairServiceRepository();
        VehicleRentalServiceRepository vehicleRentalServiceRepository = new VehicleRentalServiceRepository();
        VehiclePartsStoreItemRepository vehiclePartsStoreItemRepository = new VehiclePartsStoreItemRepository();
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        public Rate SetRateTOW(Rate rate, string feedBack)
        {
            FeedBack objFeedBack = new FeedBack();
            var ServiceProviderId = towServiceRepository.GetTOWServiceById((int)rate.ProductOrServiceId).UserId;
            var ServiceProviderType = 1;

            rate.ServiceProviderId = ServiceProviderId;
            rate.ServiceProviderType = ServiceProviderType;
            rate.CreatedDate = DateTime.Now;

            var objResult = rateRepository.GetRateExistForRatedUser(rate);

            if(objResult == null)
            {
                objResult = rateRepository.PostRate(rate);

                objFeedBack.RateId = objResult.RateId;
                objFeedBack.FeedBack1 = feedBack;
                objFeedBack.IsActive = true;
                feedBackRepository.PostFeedBack(objFeedBack);
            }
            else
            {
                rate.RateId = objResult.RateId;
                objResult = rateRepository.UpdateRate(rate.RateId,rate);

                var objFeedBack1 = feedBackRepository.GetFeedBackByRateId(rate.RateId);

                if (objFeedBack1 != null)
                {
                    objFeedBack1.FeedBack1 = feedBack;
                    feedBackRepository.UpdateFeedBack(objFeedBack1.FeedBackId, objFeedBack1);
                }
                else
                {
                    objFeedBack.RateId = objResult.RateId;
                    objFeedBack.FeedBack1 = feedBack;
                    objFeedBack.IsActive = true;
                    feedBackRepository.PostFeedBack(objFeedBack);
                }

            }

            return objResult;
        }

        public Rate SetRateRepair(Rate rate, string feedBack)
        {
            FeedBack objFeedBack = new FeedBack();
            var ServiceProviderId = repairServiceRepository.GetRepairServiceById((int)rate.ProductOrServiceId).UserId;
            var ServiceProviderType = 3;

            rate.ServiceProviderId = ServiceProviderId;
            rate.ServiceProviderType = ServiceProviderType;
            rate.CreatedDate = DateTime.Now;

            var objResult = rateRepository.GetRateExistForRatedUser(rate);

            if (objResult == null)
            {
                objResult = rateRepository.PostRate(rate);

                objFeedBack.RateId = objResult.RateId;
                objFeedBack.FeedBack1 = feedBack;
                objFeedBack.IsActive = true;
                feedBackRepository.PostFeedBack(objFeedBack);
            }
            else
            {
                rate.RateId = objResult.RateId;
                objResult = rateRepository.UpdateRate(rate.RateId, rate);

                var objFeedBack1 = feedBackRepository.GetFeedBackByRateId(rate.RateId);

                if (objFeedBack1 != null)
                {
                    objFeedBack1.FeedBack1 = feedBack;
                    feedBackRepository.UpdateFeedBack(objFeedBack1.FeedBackId, objFeedBack1);
                }
                else
                {
                    objFeedBack.RateId = objResult.RateId;
                    objFeedBack.FeedBack1 = feedBack;
                    objFeedBack.IsActive = true;
                    feedBackRepository.PostFeedBack(objFeedBack);
                }

            }

            return objResult;
        }

        public Rate SetRateRent(Rate rate, string feedBack)
        {
            FeedBack objFeedBack = new FeedBack();
            var ServiceProviderId = vehicleRentalServiceRepository.GetVehicleRentalServiceById((int)rate.ProductOrServiceId).UserId;
            var ServiceProviderType = 2;

            rate.ServiceProviderId = ServiceProviderId;
            rate.ServiceProviderType = ServiceProviderType;
            rate.CreatedDate = DateTime.Now;

            var objResult = rateRepository.GetRateExistForRatedUser(rate);

            if (objResult == null)
            {
                objResult = rateRepository.PostRate(rate);

                objFeedBack.RateId = objResult.RateId;
                objFeedBack.FeedBack1 = feedBack;
                objFeedBack.IsActive = true;
                feedBackRepository.PostFeedBack(objFeedBack);
            }
            else
            {
                rate.RateId = objResult.RateId;
                objResult = rateRepository.UpdateRate(rate.RateId, rate);

                var objFeedBack1 = feedBackRepository.GetFeedBackByRateId(rate.RateId);

                if (objFeedBack1 != null)
                {
                    objFeedBack1.FeedBack1 = feedBack;
                    feedBackRepository.UpdateFeedBack(objFeedBack1.FeedBackId, objFeedBack1);
                }
                else
                {
                    objFeedBack.RateId = objResult.RateId;
                    objFeedBack.FeedBack1 = feedBack;
                    objFeedBack.IsActive = true;
                    feedBackRepository.PostFeedBack(objFeedBack);
                }

            }

            return objResult;
        }

        public Rate SetRateStoreItem(Rate rate, string feedBack)
        {
            FeedBack objFeedBack = new FeedBack();
            var ServiceProviderId = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)rate.ProductOrServiceId).UserId;
            var ServiceProviderType = 4;

            rate.ServiceProviderId = ServiceProviderId;
            rate.ServiceProviderType = ServiceProviderType;
            rate.CreatedDate = DateTime.Now;

            var objResult = rateRepository.GetRateExistForRatedUser(rate);

            if (objResult == null)
            {
                objResult = rateRepository.PostRate(rate);

                objFeedBack.RateId = objResult.RateId;
                objFeedBack.FeedBack1 = feedBack;
                objFeedBack.IsActive = true;
                feedBackRepository.PostFeedBack(objFeedBack);
            }
            else
            {
                rate.RateId = objResult.RateId;
                objResult = rateRepository.UpdateRate(rate.RateId, rate);

                var objFeedBack1 = feedBackRepository.GetFeedBackByRateId(rate.RateId);

                if (objFeedBack1 != null)
                {
                    objFeedBack1.FeedBack1 = feedBack;
                    feedBackRepository.UpdateFeedBack(objFeedBack1.FeedBackId, objFeedBack1);
                }
                else
                {
                    objFeedBack.RateId = objResult.RateId;
                    objFeedBack.FeedBack1 = feedBack;
                    objFeedBack.IsActive = true;
                    feedBackRepository.PostFeedBack(objFeedBack);
                }

            }

            return objResult;
        }

        public List<RateFeedbackViewModel> GetRateFeedback(int userId)
        {
            var objResult1 = rateRepository.GetRateByServiceProviderId(userId);
            List<RateFeedbackViewModel> rateFeedbackViewModel = new List<RateFeedbackViewModel>();

            foreach (var i in objResult1)
            {
                var objResult2 = feedBackRepository.GetFeedBackByRateId(i.RateId);
                var objResult3 = serviceFeedBackRepository.GetServiceFeedBackByFeedBackId(objResult2.FeedBackId);


                if (objResult3 == null)
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = 0,
                        ServiceFeedBack1 = "Service feedback not submitted",
                        CreatedDate = i.CreatedDate
                    });
                }
                else
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = objResult3.ServiceFeedBackId,
                        ServiceFeedBack1 = objResult3.ServiceFeedBack1,
                        CreatedDate = i.CreatedDate
                    });
                }
                
            }
            return rateFeedbackViewModel;
        }

        public List<RateFeedbackViewModel> GetRateFeedbackByTOWProductId(int productOrServiceId)
        {
            var objResult1 = rateRepository.GetRateByProductOrServiceIdAndServiceType(productOrServiceId, 1);
            List<RateFeedbackViewModel> rateFeedbackViewModel = new List<RateFeedbackViewModel>();

            foreach (var i in objResult1)
            {
                var objResult2 = feedBackRepository.GetFeedBackByRateId(i.RateId);
                var objResult3 = serviceFeedBackRepository.GetServiceFeedBackByFeedBackId(objResult2.FeedBackId);

                if (objResult3 == null)
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = 0,
                        ServiceFeedBack1 = "Service feedback not submitted",
                        CreatedDate = i.CreatedDate
                    });
                }
                else
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = objResult3.ServiceFeedBackId,
                        ServiceFeedBack1 = objResult3.ServiceFeedBack1,
                        CreatedDate = i.CreatedDate
                    });
                }

            }
            return rateFeedbackViewModel;
        }

        public List<RateFeedbackViewModel> GetRateFeedbackByRepairProductId(int productOrServiceId)
        {
            var objResult1 = rateRepository.GetRateByProductOrServiceIdAndServiceType(productOrServiceId, 3);
            List<RateFeedbackViewModel> rateFeedbackViewModel = new List<RateFeedbackViewModel>();

            foreach (var i in objResult1)
            {
                var objResult2 = feedBackRepository.GetFeedBackByRateId(i.RateId);
                var objResult3 = serviceFeedBackRepository.GetServiceFeedBackByFeedBackId(objResult2.FeedBackId);

                if (objResult3 == null)
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = 0,
                        ServiceFeedBack1 = "Service feedback not submitted",
                        CreatedDate = i.CreatedDate
                    });
                }
                else
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = objResult3.ServiceFeedBackId,
                        ServiceFeedBack1 = objResult3.ServiceFeedBack1,
                        CreatedDate = i.CreatedDate
                    });
                }

            }
            return rateFeedbackViewModel;
        }

        public List<RateFeedbackViewModel> GetRateFeedbackByRentProductId(int productOrServiceId)
        {
            var objResult1 = rateRepository.GetRateByProductOrServiceIdAndServiceType(productOrServiceId, 2);
            List<RateFeedbackViewModel> rateFeedbackViewModel = new List<RateFeedbackViewModel>();

            foreach (var i in objResult1)
            {
                var objResult2 = feedBackRepository.GetFeedBackByRateId(i.RateId);
                var objResult3 = serviceFeedBackRepository.GetServiceFeedBackByFeedBackId(objResult2.FeedBackId);

                if (objResult3 == null)
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = 0,
                        ServiceFeedBack1 = "Service feedback not submitted",
                        CreatedDate = i.CreatedDate
                    });
                }
                else
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = objResult3.ServiceFeedBackId,
                        ServiceFeedBack1 = objResult3.ServiceFeedBack1,
                        CreatedDate = i.CreatedDate
                    });
                }

            }
            return rateFeedbackViewModel;
        }

        public List<RateFeedbackViewModel> GetRateFeedbackByStoreItemProductId(int productOrServiceId)
        {
            var objResult1 = rateRepository.GetRateByProductOrServiceIdAndServiceType(productOrServiceId, 4);
            List<RateFeedbackViewModel> rateFeedbackViewModel = new List<RateFeedbackViewModel>();

            foreach (var i in objResult1)
            {
                var objResult2 = feedBackRepository.GetFeedBackByRateId(i.RateId);
                var objResult3 = serviceFeedBackRepository.GetServiceFeedBackByFeedBackId(objResult2.FeedBackId);

                if (objResult3 == null)
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = 0,
                        ServiceFeedBack1 = "Service feedback not submitted",
                        CreatedDate = i.CreatedDate
                    });
                }
                else
                {
                    rateFeedbackViewModel.Add(new RateFeedbackViewModel
                    {
                        RateId = i.RateId,
                        RatedUserId = i.RatedUserId,
                        RatedUserName = userProfileRepository.GetUserProfileById((int)i.RatedUserId).UserName,
                        ServiceProviderId = i.ServiceProviderId,
                        ServiceProviderType = i.ServiceProviderType,
                        ProductOrServiceId = i.ProductOrServiceId,
                        RatedValue = i.RatedValue,
                        FeedBackId = objResult2.FeedBackId,
                        FeedBack1 = objResult2.FeedBack1,
                        ServiceFeedBackId = objResult3.ServiceFeedBackId,
                        ServiceFeedBack1 = objResult3.ServiceFeedBack1,
                        CreatedDate = i.CreatedDate
                    });
                }

            }
            return rateFeedbackViewModel;
        }
        public ServiceFeedBack SaveServiceFeedback(ServiceFeedBack serviceFeedBack)
        {
            var objResult = serviceFeedBackRepository.GetServiceFeedBackByFeedBackId((int)serviceFeedBack.FeedBackId);
            ServiceFeedBack objResult1 = new ServiceFeedBack();

            if (objResult == null)
            {
               objResult1 = serviceFeedBackRepository.PostServiceFeedBack(serviceFeedBack);
            }
            else
            {
                objResult.ServiceFeedBack1 = serviceFeedBack.ServiceFeedBack1;
                objResult1 = serviceFeedBackRepository.UpdateServiceFeedBack(objResult.ServiceFeedBackId, objResult);
            }

            return objResult1;
        }
    }
}
