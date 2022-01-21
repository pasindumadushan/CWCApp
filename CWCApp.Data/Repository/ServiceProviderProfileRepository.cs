using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class ServiceProviderProfileRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public ServiceProviderProfile GetServiceProviderProfileById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderProfiles.Where(x => x.ServiceId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ServiceProviderProfile GetServiceProviderProfileByUserId(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderProfiles.Where(x => x.UserId == userId && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ServiceProviderProfile> GetServiceProviderProfileList()
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderProfiles.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ServiceProviderProfile PostServiceProviderProfile(ServiceProviderProfile serviceProviderProfile)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderProfiles.Add(serviceProviderProfile);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceProviderProfile UpdateServiceProviderProfile(int id, ServiceProviderProfile serviceProviderProfile)
        {
            try
            {
                cwcAppDBEntities.Entry(serviceProviderProfile).State = EntityState.Modified;
                cwcAppDBEntities.SaveChanges();

                return serviceProviderProfile;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceProviderProfile DeleteServiceProviderProfile(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderProfiles.Find(id);
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
