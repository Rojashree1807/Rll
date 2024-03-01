using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLibrary.CRUD
{
    public class ManagerCRUD
    {
        private readonly ClinicDbContext dbContext;
        public ManagerCRUD()
        {
            dbContext = new ClinicDbContext();
        }
        public Manager FindAdminByEmail(string email)
        {
            return dbContext.Managers.FirstOrDefault(m => m.Email == email);
        }

        public bool checkAdminLogin(Manager manager)
        {
            return dbContext.Managers.Any(e => e.Email == manager.Email && e.Password == manager.Password);
        }

        public void UpdateAdmin(Manager manager)
        {
            if (manager != null)
            {
                dbContext.Entry(manager).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public List<Manager> GetAllAdmins()
        {
            return dbContext.Managers.ToList();
        }
    }
}
