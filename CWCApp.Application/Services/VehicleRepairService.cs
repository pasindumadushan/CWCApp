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
    public class VehicleRepairService
    {
        RepairServiceRepository repairServiceRepository = new RepairServiceRepository();
        GarageRepository garageRepository = new GarageRepository();
        RequestRepairDetailsRepository requestRepairDetailsRepository = new RequestRepairDetailsRepository();
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        RateServices rateServices = new RateServices();

        public RepairService SaveRepairService(int userId, RepairService repairService)
        {

            RepairService objResult = null;

            if (repairService.RepairServiceID <= 0)
            {
                repairService.UserId = userId;
                repairService.IsActive = true;
                objResult = repairServiceRepository.PostRepairService(repairService);
            }
            else
            {
                objResult = repairServiceRepository.GetRepairServiceById(repairService.RepairServiceID);
                objResult.GarageId = repairService.GarageId;
                objResult.TravelRange = repairService.TravelRange;
                objResult.VehicleExpertise = repairService.VehicleExpertise;
                objResult.RatePerHour = repairService.RatePerHour;
                objResult.RatePerJob = repairService.RatePerJob;
                objResult.ExtraFeatures = repairService.ExtraFeatures;
                objResult = repairServiceRepository.UpdateRepairService(objResult.RepairServiceID, objResult);
            }

            return objResult;
        }

        public List<RepairServiceViewModel> GetRepairServicesById(int userId)
        {
            var objResult = repairServiceRepository.GetrepairServicesByIdList(userId);

            List<RepairServiceViewModel> repairServiceViewModel = new List<RepairServiceViewModel>();

            foreach (var i in objResult)
            {
                repairServiceViewModel.Add(new RepairServiceViewModel
                {
                    RepairServiceID = i.RepairServiceID,
                    GarageId = i.GarageId,
                    UserId = i.UserId,
                    GarageName = garageRepository.GetGarageById((int)i.GarageId).GarageName,
                    TravelRange = i.TravelRange,
                    VehicleExpertise = i.VehicleExpertise,
                    RatePerHour = i.RatePerHour,
                    RatePerJob = i.RatePerJob,
                    ExtraFeatures = i.ExtraFeatures,
                    IsActive = i.IsActive
                });
            }

            return repairServiceViewModel;
        }

        public List<RepairServiceViewModel> GetRepairServices()
        {
            var objResult = repairServiceRepository.GetRepairServiceList();

            List<RepairServiceViewModel> repairServiceViewModel = new List<RepairServiceViewModel>();

            foreach (var i in objResult)
            {
                repairServiceViewModel.Add(new RepairServiceViewModel
                {
                    RepairServiceID = i.RepairServiceID,
                    UserId = i.UserId,
                    GarageId = i.GarageId,
                    GarageName = garageRepository.GetGarageById((int)i.GarageId).GarageName,
                    TravelRange = i.TravelRange,
                    VehicleExpertise = i.VehicleExpertise,
                    RatePerHour = i.RatePerHour,
                    RatePerJob = i.RatePerJob,
                    ExtraFeatures = i.ExtraFeatures,
                    AvgRate = rateServices.GetRateFeedbackByRepairProductId(i.RepairServiceID).Select(item => item.RatedValue).ToList().Average() != null ? rateServices.GetRateFeedbackByRepairProductId(i.RepairServiceID).Select(item => item.RatedValue).ToList().Average() : 0,
                    IsActive = i.IsActive
                });
            }

            return repairServiceViewModel;
        }

        public RepairServiceViewModel GetRepairServicesDetails(int RepairServiceID)
        {
            var objResult = repairServiceRepository.GetRepairServiceById(RepairServiceID);
            var garageName = garageRepository.GetGarageById((int)objResult.GarageId).GarageName;
            var shopOwnerId = garageRepository.GetGarageById((int)objResult.GarageId).UserId;
            RepairServiceViewModel repairServiceViewModel = new RepairServiceViewModel();

            repairServiceViewModel.RepairServiceID = objResult.RepairServiceID;
            repairServiceViewModel.GarageId = objResult.GarageId;
            repairServiceViewModel.GarageName = garageName;
            repairServiceViewModel.UserId = objResult.UserId;
            repairServiceViewModel.TravelRange = objResult.TravelRange;
            repairServiceViewModel.VehicleExpertise = objResult.VehicleExpertise;
            repairServiceViewModel.RatePerHour = objResult.RatePerHour;
            repairServiceViewModel.RatePerJob = objResult.RatePerJob;
            repairServiceViewModel.ExtraFeatures = objResult.ExtraFeatures;
            repairServiceViewModel.IsActive = objResult.IsActive;

            return repairServiceViewModel;
        }

        public List<RequestedRepairServiceViewModel> GetRequestedRepairServicesForRequester(int userId)
        {
            List<RequestedRepairServiceViewModel> requestedRepairServiceViewModel = new List<RequestedRepairServiceViewModel>();
            var objResult = requestRepairDetailsRepository.GetRequestedRepairDetailsByRequesterIdList(userId);

            foreach (var i in objResult)
            {
                var garageId = repairServiceRepository.GetRepairServiceById((int)i.RepairServiceID).GarageId;
                var garageName = garageRepository.GetGarageById((int)garageId).GarageName;
                var shopOwnerName = userProfileRepository.GetUserProfileById((int)i.ShopOwnerId).UserName;
                var requesterName = userProfileRepository.GetUserProfileById((int)i.RequesterId).UserName;

                requestedRepairServiceViewModel.Add(new RequestedRepairServiceViewModel
                {
                    DetailId = i.DetailId,
                    RepairServiceID = i.RepairServiceID,
                    GarageName = garageName,
                    ShopOwnerId = i.ShopOwnerId,
                    ShopOwnerName = shopOwnerName,
                    RequesterId = i.RequesterId,
                    RequesterName = requesterName,
                    ReqestedCity = i.ReqestedCity,
                    ContactNo = i.ContactNo,
                    RatePerHour = i.RatePerHour,
                    RatePerJob = i.RatePerJob,
                    IsActive = i.IsActive
                });
            }
            return requestedRepairServiceViewModel;
        }

        public List<RequestedRepairServiceViewModel> GetRequestedRepairServicesForOwner(int userId)
        {
            List<RequestedRepairServiceViewModel> requestedRepairServiceViewModel = new List<RequestedRepairServiceViewModel>();
            var objResult = requestRepairDetailsRepository.GetRequestedRepairDetailsByShopOwnerIdList(userId);

            foreach (var i in objResult)
            {
                var garageId = repairServiceRepository.GetRepairServiceById((int)i.RepairServiceID).GarageId;
                var garageName = garageRepository.GetGarageById((int)garageId).GarageName;
                var shopOwnerName = userProfileRepository.GetUserProfileById((int)i.ShopOwnerId).UserName;
                var requesterName = userProfileRepository.GetUserProfileById((int)i.RequesterId).UserName;

                requestedRepairServiceViewModel.Add(new RequestedRepairServiceViewModel
                {
                    DetailId = i.DetailId,
                    RepairServiceID = i.RepairServiceID,
                    GarageName = garageName,
                    ShopOwnerId = i.ShopOwnerId,
                    ShopOwnerName = shopOwnerName,
                    RequesterId = i.RequesterId,
                    RequesterName = requesterName,
                    ReqestedCity = i.ReqestedCity,
                    ContactNo = i.ContactNo,
                    RatePerHour = i.RatePerHour,
                    RatePerJob = i.RatePerJob,
                    IsActive = i.IsActive
                });
            }
            return requestedRepairServiceViewModel;
        }

    }
}
