using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLibrary.CRUD
{
    public class Front_OfficerCRUD
    {
        private readonly ClinicDbContext dbContext;
        public Front_OfficerCRUD()
        {
            dbContext = new ClinicDbContext();
        }

        public List<Front_Officer> GetAllFrontOfficerExecutives()
        {
            var obj = dbContext.Front_Officers.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
        public Front_Officer GetFrontOfficeExecutiveById(int Front_OfficerId)
        {
            var obj = dbContext.Front_Officers.Find(Front_OfficerId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        public bool checkFrontOfficerLogin(Front_Officer frontofficer)
        {
            var obj = dbContext.Front_Officers.Any(d => d.Email == frontofficer.Email && d.Password == frontofficer.Password);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return false;
            }

        }
        public void AddFrontOfficeExecutive(Front_Officer frontOfficeExecutive)
        {
            if (frontOfficeExecutive != null)
            {
                dbContext.Front_Officers.Add(frontOfficeExecutive);
                dbContext.SaveChanges();
            }
        }

        public void UpdateFrontOfficeExecutive(Front_Officer frontOfficeExecutive)
        {
            if (frontOfficeExecutive != null)
            {
                dbContext.Entry(frontOfficeExecutive).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void DeleteFrontOfficeExecutive(int Front_OfficerId)
        {
            var Front_Officer = dbContext.Front_Officers.Find(Front_OfficerId);
            if (Front_Officer != null)
            {
                dbContext.Front_Officers.Remove(Front_Officer);
                dbContext.SaveChanges();
            }
        }
        public Front_Officer FindFrontOfficeByEmail(string email)
        {
            var obj = dbContext.Front_Officers.FirstOrDefault(f => f.Email == email);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        public bool FrontOfficeExecutiveExists(int Front_OffId)
        {
            var obj = dbContext.Front_Officers.Any(e => e.Front_OfficerId == Front_OffId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return false;
            }
        }
    }
}
