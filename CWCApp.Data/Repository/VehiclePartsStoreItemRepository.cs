using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class VehiclePartsStoreItemRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public VehiclePartsStoreItem GetVehiclePartsStoreItemById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Where(x => x.ItemId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public VehiclePartsStoreItem GetVehiclePartsStoreItemByName(VehiclePartsStoreItem vehiclePartsStoreItem)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Where(x => x.ItemName.ToUpper() == vehiclePartsStoreItem.ItemName.ToUpper() && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<VehiclePartsStoreItem> GetVehiclePartsStoreItemList()
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Where(x => x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<VehiclePartsStoreItem> GetvehiclePartsStoreItemsByIdList(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Where(x => x.UserId == userId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public VehiclePartsStoreItem PostVehiclePartsStoreItem(VehiclePartsStoreItem vehiclePartsStoreItem)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Add(vehiclePartsStoreItem);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VehiclePartsStoreItem UpdateVehiclePartsStoreItem(int id, VehiclePartsStoreItem vehiclePartsStoreItem)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(vehiclePartsStoreItem);
                cwcAppDBEntities.SaveChanges();

                return vehiclePartsStoreItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VehiclePartsStoreItem DeleteVehiclePartsStoreItem(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehiclePartsStoreItems.Find(id);
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
