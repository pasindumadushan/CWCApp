using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class ServiceProviderMstrRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public ServiceProviderMstr GetServiceProviderMstrById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderMstrs.Where(x => x.ServiceProviderTypeId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<ServiceProviderMstr> GetServiceProviderMstrList()
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderMstrs.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ServiceProviderMstr PostServiceProviderMstr(ServiceProviderMstr serviceProviderMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderMstrs.Add(serviceProviderMstr);
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceProviderMstr UpdateServiceProviderMstr(int id, ServiceProviderMstr serviceProviderMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderMstrs.Find(id);

                cwcAppDBEntities.Entry(serviceProviderMstr).State = EntityState.Modified;
                cwcAppDBEntities.SaveChanges();

                return serviceProviderMstr;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceProviderMstr DeleteServiceProviderMstr(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceProviderMstrs.Find(id);
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
