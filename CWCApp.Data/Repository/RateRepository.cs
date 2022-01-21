using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class RateRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public Rate GetRateById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Where(x => x.RateId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Rate> GetRateByProductOrServiceIdAndServiceType(int productOrServiceId, int serviceType)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Where(x => x.ProductOrServiceId == productOrServiceId && x.ServiceProviderType == serviceType && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Rate> GetRateByServiceProviderId(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Where(x => x.ServiceProviderId == id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Rate GetRateExistForRatedUser(Rate rate)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Where(x => x.ProductOrServiceId == rate.ProductOrServiceId && x.RatedUserId == rate.RatedUserId && x.ServiceProviderType == rate.ServiceProviderType && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Rate> GetRateList()
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Rate PostRate(Rate rate)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Add(rate);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Rate UpdateRate(int id, Rate rate)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(rate);
                cwcAppDBEntities.SaveChanges();

                return rate;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Rate DeleteRate(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.Rates.Find(id);
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
