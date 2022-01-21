using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class RepairServiceRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public RepairService GetRepairServiceById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RepairServices.Where(x => x.RepairServiceID == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RepairService> GetRepairServiceList()
        {
            try
            {
                var objResult = cwcAppDBEntities.RepairServices.Where(x => x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<RepairService> GetrepairServicesByIdList(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.RepairServices.Where(x => x.UserId == userId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public RepairService PostRepairService(RepairService repairService)
        {
            try
            {
                var objResult = cwcAppDBEntities.RepairServices.Add(repairService);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RepairService UpdateRepairService(int id, RepairService repairService)
        {
            try
            {
                var objResult = cwcAppDBEntities.RepairServices.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(repairService);
                cwcAppDBEntities.SaveChanges();

                return repairService;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RepairService DeleteRepairService(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RepairServices.Find(id);
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
