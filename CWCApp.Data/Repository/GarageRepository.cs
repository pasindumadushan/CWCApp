using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class GarageRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public Garage GetGarageById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.Where(x => x.GarageId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Garage GetGarageByName(Garage garage)
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.Where(x => x.GarageName.ToUpper() == garage.GarageName.ToUpper() && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Garage> GetGarageList()
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Garage> GetgaragesByIdList(int userId)
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.Where(x => x.UserId == userId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Garage PostGarage(Garage garage)
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.Add(garage);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Garage UpdateGarage(int id, Garage garage)
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(garage);
                cwcAppDBEntities.SaveChanges();

                return garage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Garage DeleteGarage(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.Garages.Find(id);
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

