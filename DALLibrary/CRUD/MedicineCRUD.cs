using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLibrary.CRUD
{
    public class MedicineCRUD
    {
        private readonly ClinicDbContext dbContext;
        public MedicineCRUD()
        {
            dbContext = new ClinicDbContext();
        }

        public List<Medicine> GetAllMedicines()
        {
            var obj = dbContext.Medicines.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Medicine GetMedicineById(int medicineId)
        {
            var obj = dbContext.Medicines.Find(medicineId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Medicine> FindMedicineByName(string Name)
        {
            return dbContext.Medicines.Where(meds => meds.MedicineName.Contains(Name));
        }

        public void AddMedicine(Medicine medicine)
        {
            if (medicine != null)
            {
                dbContext.Medicines.Add(medicine);
                dbContext.SaveChanges();
            }
        }

        public void UpdateMedicine(Medicine medicine)
        {
                dbContext.Entry(medicine).State = EntityState.Modified;
                dbContext.SaveChanges();
        }
        public void DeleteMedicine(int medicineId)
        {
            var medicine = dbContext.Medicines.Find(medicineId);
            if (medicine != null)
            {
                dbContext.Medicines.Remove(medicine);
                dbContext.SaveChanges();
            }
        }
    }
}
