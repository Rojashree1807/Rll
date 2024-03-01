using DALLibrary.CRUD;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicApi.Models
{
    public class Service
    {
            private readonly ManagerCRUD managerCrud;
            private readonly AppointmentCRUD OpCrud;
            private readonly DoctorCRUD doctorCRUD;
            private readonly Front_OfficerCRUD front_OfficersCrud;
            private readonly MedicineCRUD medicineCRUD;
            private readonly MessageCRUD messageCRUD;
            private readonly PatientCRUD patientCRUD;
            private readonly PharmacistCRUD pharmacistCRUD;

            public Service()
            { 
                managerCrud = new ManagerCRUD();
                OpCrud = new AppointmentCRUD();
                doctorCRUD = new DoctorCRUD();
                front_OfficersCrud = new Front_OfficerCRUD();
                medicineCRUD = new MedicineCRUD();
                messageCRUD = new MessageCRUD();
                patientCRUD = new PatientCRUD();
                pharmacistCRUD = new PharmacistCRUD();
            }


            //invoked methods from PharmacistCRUD folder from DAL
            public IEnumerable<Pharmacist> GetAllPharmacists()
            {
                return pharmacistCRUD.GetAllPharmacists();
            }
            public Pharmacist GetPharmacistById(int pharmacistId)
            {
                return pharmacistCRUD.GetPharmacistById(pharmacistId);
            }
            public Pharmacist FindPharmacistByEmail(string email)
            {
                return pharmacistCRUD.FindPharmacistByEmail(email);
            }

            public bool checkPharmistLogin(Pharmacist pharmacist)
            {
                return pharmacistCRUD.checkPharmistLogin(pharmacist);
            }
            public void AddPharmacist(Pharmacist pharmacist)
            {
                pharmacistCRUD.AddPharmacist(pharmacist);
            }

            public void UpdatePharmacist(Pharmacist pharmacist)
            {
                pharmacistCRUD.UpdatePharmacist(pharmacist);
            }

            public void DeletePharmacist(int pharmacistId)
            {
                pharmacistCRUD.DeletePharmacist(pharmacistId);
            }

            public bool PharmacistExists(int pharmacistId)
            {
                return pharmacistCRUD.PharmacistExists(pharmacistId);
            }

            //Invoked methods from Front-OffCRUD 
            public IEnumerable<Front_Officer> GetAllFrontOfficer()
            {
                return front_OfficersCrud.GetAllFrontOfficerExecutives();
            }
            public Front_Officer FindFrontOfficeByEmail(string Email)
            {
                return front_OfficersCrud.FindFrontOfficeByEmail(Email);
            }
            public Front_Officer GetFrontOfficeExecutiveById(int Front_OfficerId)
            {
                return front_OfficersCrud.GetFrontOfficeExecutiveById(Front_OfficerId);
            }
            public void AddFrontOfficeExecutive(Front_Officer frontOfficeExecutive)
            {
                front_OfficersCrud.AddFrontOfficeExecutive(frontOfficeExecutive);

            }
            public void UpdateFrontOfficeExecutive(Front_Officer frontOfficeExecutive)
            {
                front_OfficersCrud.UpdateFrontOfficeExecutive(frontOfficeExecutive);

            }
            public void DeleteFrontOfficeExecutive(int Front_OfficerId)
            {
                front_OfficersCrud.DeleteFrontOfficeExecutive(Front_OfficerId);

            }
            public bool FrontOfficeExecutiveExists(int Front_OfficerId)
            {
                return front_OfficersCrud.FrontOfficeExecutiveExists(Front_OfficerId);
            }
            public bool checkFrontOfficerLogin(Front_Officer FrontOfficer)
            {
                return front_OfficersCrud.checkFrontOfficerLogin(FrontOfficer);
            }

            //Invoked methods from AppointmentCRUD Calss

            public List<Appointment> GetAllAppointments()
            {
                return OpCrud.GetAllAppointments();

            }
            public IEnumerable<Appointment> FindPatientAppointByName(string Name)
            {
                return OpCrud.FindPatientAppointByName(Name);
            }
            public IEnumerable<Appointment> SearchbyPatientIdApproved(int id)
            {
                return OpCrud.SearchbyPatientIdApproved(id);

            }

            public IEnumerable<Appointment> SearchbyDoctorIdApproved(int id)
            {
                return OpCrud.SearchbyDoctorIdApproved(id);
            }
            public Appointment GetMsgLimitForSpecificAppoinment(int appointmentId)
            {
                return OpCrud.GetMsgLimitForSpecificAppoinment(appointmentId);
            }
            public Appointment GetAppointmentById(int doc, int pat)
            {
                return OpCrud.GetAppointmentById(doc, pat);
            }
            public Appointment GetAppointmentById(int appointmentId)
            {
                return OpCrud.GetAppointmentById(appointmentId);
            }

            public void AddAppointment(Appointment appointment)
            {
                OpCrud.AddAppointment(appointment);
            }
            public void UpdateAppointment(Appointment appointment)
            {
                OpCrud.UpdateAppointment(appointment);
            }

            public void DeleteAppointment(int appointmentId)
            {
                OpCrud.DeleteAppointment(appointmentId);
            }

            public List<Appointment> GetAppointmentsByPatientId(int patientId)
            {
                return OpCrud.GetAppointmentsByPatientId(patientId);
            }

            public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
            {
                return OpCrud.GetAppointmentsByDoctorId(doctorId);
            }
            public bool AppointmentExists(int appointmentId)
            {
                return OpCrud.AppointmentExists(appointmentId);
            }

            // Invoked Medicine Methods from MedicineCRUD 

            public List<Medicine> GetAllMedicines()
            {
                return medicineCRUD.GetAllMedicines();
            }

            public Medicine GetMedicineById(int medicineId)
            {
                return medicineCRUD.GetMedicineById(medicineId);
            }
            public IEnumerable<Medicine> FindMedicineByName(string Name)
            {
                return medicineCRUD.FindMedicineByName(Name);
            }
            public void AddMedicine(Medicine medicine)
            {
                medicineCRUD.AddMedicine(medicine);
            }
            public void UpdateMedicine(Medicine medicine)
            {
                medicineCRUD.UpdateMedicine(medicine);
            }

            public void DeleteMedicine(int medicineId)
            {
                medicineCRUD.DeleteMedicine(medicineId);
            }
            //Invoked admin Menthods from adminCRUD class
            public Manager FindAdminByEmail(string email)
            {
                return managerCrud.FindAdminByEmail(email);
            }

            public bool checkAdminLogin(Manager admin)
            {
                return managerCrud.checkAdminLogin(admin);
            }

            public void UpdateAdmin(Manager admin)
            {
                managerCrud.UpdateAdmin(admin);
            }
            public List<Manager> GetAllAdmin()
            {
                return managerCrud.GetAllAdmins();
            }


            // invoked Doctor methods
            public List<Doctor> GetAllDoctors()
            {
                return doctorCRUD.GetAllDoctors();
            }

            public Doctor FindDoctorByEmail(string email)
            {
                return doctorCRUD.FindDoctorByEmail(email);
            }
            public Doctor GetDoctorById(int doctorId)
            {
                return doctorCRUD.GetDoctorById(doctorId);
            }

            public void AddDoctor(Doctor doctor)
            {
                doctorCRUD.AddDoctor(doctor);
            }
            public void UpdateDoctor(Doctor doctor)
            {
                doctorCRUD.UpdateDoctor(doctor);

            }
            public void DeleteDoctor(int doctorId)
            {
                doctorCRUD.DeleteDoctor(doctorId);

            }
            public bool DoctorExists(int doctorId)
            {
                return doctorCRUD.DoctorExists(doctorId);
            }
            public bool checkDoctorLogin(Doctor doctor)
            {
                return doctorCRUD.checkDoctorLogin(doctor);
            }

            //patient methods invoked
            public IEnumerable<Patient> GetAllPatients()
            {
                return patientCRUD.GetAllPatients();
            }
            public void InsertPatient(Patient patient)
            {
                patientCRUD.InsertPatient(patient);
            }
            public void UpdatePatient(Patient patient)
            {
                patientCRUD.UpdatePatient(patient);
            }
            public bool checkPatientLogin(Patient patient)
            {
                return patientCRUD.checkPatientLogin(patient);
            }
            public void DeletePatient(int id)
            {
                patientCRUD.DeletePatient(id);
            }
            public Patient FindPatientById(int id)
            {
                return patientCRUD.FindPatientById(id);
            }
            public Patient FindPatientByEmail(string Email)
            {
                return patientCRUD.FindPatientByEmail(Email);
            }
            //datatype
            public IEnumerable<Patient> FindPatientWithName(string Name)
            {
                return patientCRUD.FindPatientWithName(Name);
            }

            //Invoker Message methods

            //Message
            public List<Message> GetAllMessage()
            {
                return messageCRUD.GetAllMessages();
            }
            public Message GetMessageById(int id)
            {
                return messageCRUD.GetMessageById(id);
            }
            public IEnumerable<Message> GetBySenderIdAndRecieverId(int SenderId, int RecieverId)
            {

                return messageCRUD.GetBySenderIdAndRecieverId(SenderId, RecieverId);
            }
            public void AddMessage(Message message)
            {
                messageCRUD.AddMessage(message);
            }
            public void UpdateMessage(Message message)
            {
                messageCRUD.UpdateMessage(message);
            }
            public void DeleteMessage(int messageId)
            {
                messageCRUD.DeleteMessage(messageId);
            }
        }
}