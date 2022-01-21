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
    public class VehiclePartsStoreService
    {
        ServiceProviderProfileRepository serviceProviderProfileRepository = new ServiceProviderProfileRepository();
        VehiclePartsStoreRepository vehiclePartsStoreRepository = new VehiclePartsStoreRepository();
        ShoppingMethodMstrRepository shoppingMethodMstrRepository = new ShoppingMethodMstrRepository();
        public VehiclePartsStore SaveVehiclePartsService(int userId, VehiclePartsStore vehiclePartsStore)
        {
            var objResult1 = serviceProviderProfileRepository.GetServiceProviderProfileByUserId(userId);
            VehiclePartsStore objResult2 = null;

            vehiclePartsStore.ServiceId = objResult1.ServiceId;
            vehiclePartsStore.UserId = objResult1.UserId;
            vehiclePartsStore.IsActive = true;

            if(vehiclePartsStore.StoreId <= 0)
            {
                objResult2 = vehiclePartsStoreRepository.PostVehiclePartsStore(vehiclePartsStore);
            }

            else
            {
                objResult2 = vehiclePartsStoreRepository.UpdateVehiclePartsStore(vehiclePartsStore.StoreId,vehiclePartsStore);
            }

            return objResult2;

        }
        public List<VehiclePartsStoreViewModel> GetvehiclePartsStoresByIdList(int userId)
        {
            var objResult = vehiclePartsStoreRepository.GetvehiclePartsStoresByIdList(userId);
            List<VehiclePartsStoreViewModel> vehiclePartsStoreViewModel = new List<VehiclePartsStoreViewModel>();

            foreach (var i in objResult)
            {
                vehiclePartsStoreViewModel.Add(new VehiclePartsStoreViewModel { StoreId = (int)i.StoreId, UserId = i.UserId, ServiceId = i.ServiceId, StoreName = i.StoreName, ContactNumber = i.ContactNumber, AddressOfStore = i.AddressOfStore, ShoppingMethodId = i.ShoppingMethod, ShoppingMethod = shoppingMethodMstrRepository.GetShoppingMethodMstrById((int)i.ShoppingMethod).ShoppingMethod, IsActive = i.IsActive });
            }

            return vehiclePartsStoreViewModel;

        }
    }
}
