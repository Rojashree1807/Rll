using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLibrary.CRUD
{
    public class PatientCRUD
    {
        private readonly ClinicDbContext dbContext; //define database class object

        public PatientCRUD()
        {
            dbContext = new ClinicDbContext(); //intialize database object 
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return dbContext.Patients.ToList();
        }
        public void InsertPatient(Patient patient)
        {
            dbContext.Patients.Add(patient);
            dbContext.SaveChanges();
        }
        public void UpdatePatient(Patient patient)
        {
            dbContext.Entry(patient).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        public bool checkPatientLogin(Patient patient)
        {
            return dbContext.Patients.Any(d => d.Email == patient.Email && d.Password == patient.Password);
        }
        public void DeletePatient(int id)
        {
            Patient found = dbContext.Patients.Find(id);
            if (found != null)
            {
                dbContext.Patients.Remove(found);
                dbContext.SaveChanges();
            }
        }
        public Patient FindPatientById(int id)
        {
            return dbContext.Patients.Find(id);
        }
        public Patient FindPatientByEmail(string Email)
        {
            return dbContext.Patients.FirstOrDefault(pro => pro.Email == Email);
        }
        //datatype
        public IEnumerable<Patient> FindPatientWithName(string Name)
        {
            return dbContext.Patients.Where(meds => meds.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
