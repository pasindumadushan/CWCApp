using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class TOWServiceRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public TOWService GetTOWServiceById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.TOWServices.Where(x => x.TOWServiceID == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TOWService> GetTOWServiceList()
        {
            try
            {
                var objResult = cwcAppDBEntities.TOWServices.Where(x => x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<TOWService> GettowServicesByIdList(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.TOWServices.Where(x => x.UserId == userId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public TOWService PostTOWService(TOWService towService)
        {
            try
            {
                var objResult = cwcAppDBEntities.TOWServices.Add(towService);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TOWService UpdateTOWService(int id, TOWService towService)
        {
            try
            {
                var objResult = cwcAppDBEntities.TOWServices.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(towService);
                cwcAppDBEntities.SaveChanges();

                return towService;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TOWService DeleteTOWService(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.TOWServices.Find(id);
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
