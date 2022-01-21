using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class VehicleRentalServiceRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public VehicleRentalService GetVehicleRentalServiceById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.Where(x => x.RentalServiceID == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public VehicleRentalService GetVehicleRentalServiceByName(VehicleRentalService vehicleRentalService)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.Where(x => x.RantalServiceName.ToUpper() == vehicleRentalService.RantalServiceName.ToUpper() && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<VehicleRentalService> GetVehicleRentalServiceList()
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<VehicleRentalService> GetvehicleRentalServicesByIdList(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.Where(x => x.UserId == userId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public VehicleRentalService PostVehicleRentalService(VehicleRentalService vehicleRentalService)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.Add(vehicleRentalService);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VehicleRentalService UpdateVehicleRentalService(int id, VehicleRentalService vehicleRentalService)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(vehicleRentalService);
                cwcAppDBEntities.SaveChanges();

                return vehicleRentalService;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VehicleRentalService DeleteVehicleRentalService(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.VehicleRentalServices.Find(id);
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
