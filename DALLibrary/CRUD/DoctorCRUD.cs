using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;


namespace DALLibrary.CRUD
{
    public class DoctorCRUD
    {
        private readonly ClinicDbContext dbContext;
        public DoctorCRUD()
        {
            dbContext = new ClinicDbContext();
        }

        public List<Doctor> GetAllDoctors()
        {
            var obj = dbContext.Doctors.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
        public Doctor GetDoctorById(int doctorId)
        {
            return dbContext.Doctors
     .FirstOrDefault(d => d.DoctorId == doctorId);

        }


        public Doctor FindDoctorByEmail(string email)
        {
            var obj = dbContext.Doctors.FirstOrDefault(f => f.Email == email);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public bool checkDoctorLogin(Doctor doctor)
        {
            return dbContext.Doctors.Any(d => d.Email == doctor.Email && d.Password == doctor.Password);
        }
        public void AddDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                dbContext.Doctors.Add(doctor);
                dbContext.SaveChanges();
            }
        }

        public void UpdateDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                dbContext.Entry(doctor).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public void DeleteDoctor(int doctorId)
        {
            var doctor = dbContext.Doctors.Find(doctorId);
            if (doctor != null)
            {
                dbContext.Doctors.Remove(doctor);
                dbContext.SaveChanges();
            }
        }
        public bool DoctorExists(int doctorId)
        {
            return dbContext.Doctors.Any(d => d.DoctorId == doctorId);
        }
    }
}
