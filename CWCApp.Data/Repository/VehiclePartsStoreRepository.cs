using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class VehiclePartsStoreRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public VehiclePartsStore GetVehiclePartsStoreById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.Where(x => x.StoreId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public VehiclePartsStore GetVehiclePartsStoreByName(VehiclePartsStore vehiclePartsStore)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.Where(x => x.StoreName.ToUpper() == vehiclePartsStore.StoreName.ToUpper() && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<VehiclePartsStore> GetVehiclePartsStoreList()
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<VehiclePartsStore> GetvehiclePartsStoresByIdList(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.Where(x => x.UserId == userId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public VehiclePartsStore PostVehiclePartsStore(VehiclePartsStore vehiclePartsStore)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.Add(vehiclePartsStore);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VehiclePartsStore UpdateVehiclePartsStore(int id, VehiclePartsStore vehiclePartsStore)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(vehiclePartsStore);
                cwcAppDBEntities.SaveChanges();

                return vehiclePartsStore;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VehiclePartsStore DeleteVehiclePartsStore(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStores.Find(id);
                objResult.IsActive = false;

                cwcAppDBEntities.Entry(objResult).State = EntityState.Modified;
                cwcAppDBEntities.SaveChanges();

                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

