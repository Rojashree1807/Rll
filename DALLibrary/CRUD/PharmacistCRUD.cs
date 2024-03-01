using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLibrary.CRUD
{
    public class PharmacistCRUD
    {
        public ClinicDbContext dbContext;
        public PharmacistCRUD()
        {
            dbContext = new ClinicDbContext();
        }
        public IEnumerable<Pharmacist> GetAllPharmacists()
        {
            var obj = dbContext.Pharmacists.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        public Pharmacist GetPharmacistById(int pharmacistId)
        {
            var obj = dbContext.Pharmacists.Find(pharmacistId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        public Pharmacist FindPharmacistByEmail(string email)
        {
            var obj = dbContext.Pharmacists.FirstOrDefault(f => f.Email == email);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public bool checkPharmistLogin(Pharmacist pharmacist)
        {
            return dbContext.Pharmacists.Any(d => d.Email == pharmacist.Email && d.Password == pharmacist.Password);
        }
        public void AddPharmacist(Pharmacist pharmacist)
        {
            if (pharmacist != null)
            {
                dbContext.Pharmacists.Add(pharmacist);
                dbContext.SaveChanges();
            }
        }

        public void UpdatePharmacist(Pharmacist pharmacist)
        {
            if (pharmacist != null)
            {
                dbContext.Entry(pharmacist).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void DeletePharmacist(int pharmacistId)
        {
            var pharmacist = dbContext.Pharmacists.Find(pharmacistId);
            if (pharmacist != null)
            {
                dbContext.Pharmacists.Remove(pharmacist);
                dbContext.SaveChanges();
            }
        }

        public bool PharmacistExists(int pharmacistId)
        {
            return dbContext.Pharmacists.Any(e => e.PharmacistId == pharmacistId);
        }
    }
}
