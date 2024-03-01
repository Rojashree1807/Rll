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
    public class AppointmentCRUD
    {
        private readonly ClinicDbContext dbContext;
        public AppointmentCRUD()
        {
            dbContext = new ClinicDbContext();
        }

        public List<Appointment> GetAllAppointments() 
        {
            var obj = dbContext.Appointments.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
        public IEnumerable<Appointment> FindPatientAppointByName(string Name)
        {
            IEnumerable<Appointment> appointments = dbContext.Appointments.Where(p => p.Patient.Name.ToLower().Contains(Name.ToLower()) && p.Patient.PatientId == p.PatientId).
                OrderBy(p => p.AppointmentId);
            return appointments;
        }
        public IEnumerable<Appointment> SearchbyPatientIdApproved(int id)
        {
            IEnumerable<Appointment> appointments = dbContext.Appointments.Include("Patient").
                OrderBy(a => a.AppointmentId).Where(a => a.PatientId == id && a.IsApprove == true);
            return appointments;

        }

        public IEnumerable<Appointment> SearchbyDoctorIdApproved(int id)
        {
            IEnumerable<Appointment> appointments = dbContext.Appointments.Include("Doctor").
                OrderBy(a => a.AppointmentId).Where(a => a.DoctorId == id && a.IsApprove == true);
            return appointments;
        }
        public Appointment GetMsgLimitForSpecificAppoinment(int appointmentId)
        {
            return (Appointment)dbContext.Appointments
               .Where(a => a.AppointmentId == appointmentId)
                .Select(a => a.MsgLimit);

        }
        public Appointment GetAppointmentById(int doc, int pat)
        {
            return dbContext.Appointments
                .FirstOrDefault(d => d.DoctorId == doc && d.PatientId == pat);
        }
        public Appointment GetAppointmentById(int appointmentId)
        {
            return dbContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        public void AddAppointment(Appointment appointment)
        {
            dbContext.Appointments.Add(appointment);
            dbContext.SaveChanges();
        }
        public void UpdateAppointment(Appointment appointment)
        {
            dbContext.Entry(appointment).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteAppointment(int appointmentId)
        {
            var appointment = dbContext.Appointments.Find(appointmentId);
            dbContext.Appointments.Remove(appointment);
            dbContext.SaveChanges();
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return dbContext.Appointments
                .Where(a => a.PatientId == patientId)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return dbContext.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToList();
        }
        public bool AppointmentExists(int appointmentId) 
        {
            return dbContext.Appointments.Any(a => a.AppointmentId == appointmentId);
        }
    }
}
