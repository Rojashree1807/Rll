using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicUI.Controllers
{
    public class PatientsController : Controller
    {
        private readonly Service service;

        public PatientsController()
        {
            service = new Service();
        }

        // landing page
        public ActionResult GetAllDoc()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllDoctors());
            }
            return RedirectToAction("PatientLogin", "Login");
        }
        [HttpGet]
        public ActionResult RegisterPatient()
        {
            return View(new Patient());
        }
        [HttpPost]
        public ActionResult RegisterPatient(Patient p)
        {
            if (ModelState.IsValid)
            {
                service.InsertPatient(p);
                return RedirectToAction("PatientLogin", "Login");
            }
            return View();
        }
        public ActionResult BookOp(int docId)//book Appointment
        {
            Doctor doc = service.GetDoctorById(docId);
            Session["DocId"] = docId;
            Session["DoctorName"] = doc.DoctorName;
            Session["Specialization"] = doc.Specialization;
            Session["Timings"] = doc.Timings;
            return View();
        }

        [HttpPost]
        public ActionResult BookOp(Appointment appointment)
        {
            if (Session["SId"] != null)
            {
                if (appointment.StartDateTime.Date >= DateTime.Now.Date)
                {

                    var obj = Session["PatientObj"] as Patient;

                    appointment.Status = "Pending";
                    appointment.MsgLimit = 0;
                    appointment.IsApprove = false;
                    appointment.DoctorId = (int)Session["DocId"];
                    appointment.PatientId = obj.PatientId;
                    service.AddAppointment(appointment);
                    return RedirectToAction("GetAllDoc");
                }
                else
                {
                    ModelState.AddModelError("StartDateTime", "Select Valid Appointment Date");
                    return View();
                }
            }
            return RedirectToAction("PatientLogin", "Login");
        }
        public ActionResult ViewAppointments(Appointment a)//list of appointments
        {
            if (Session["SId"] != null)
            {
                var obj = Session["PatientObj"] as Patient;
                List<Appointment> appointment = service.GetAppointmentsByPatientId(obj.PatientId);
                return View(appointment);
            }
            return RedirectToAction("PatientLogin", "Login");
        }

        public ActionResult MessageDoctor()// message ui 
        {
            if (Session["SId"] != null)
            {
                var obj = Session["PatientObj"] as Patient;
                var appointments = service.SearchbyPatientIdApproved(obj.PatientId);

                ViewBag.Appointments = appointments;
                Session["PatientId"] = obj.PatientId;
                return View();
            }
            return RedirectToAction("PatientLogin", "Login");
           
        }

        [HttpPost]
        public ActionResult MessageDoctor(int id)
        {

            var obj = Session["PatientObj"] as Patient;
            Doctor doctor = service.GetDoctorById(id);
            Session["DocId"] = doctor.DoctorId;
            Session["Dname"] = doctor.DoctorName;
            IEnumerable<Message> messages = service.GetBySenderIdAndRecieverId(obj.PatientId, id);
            var appointments = service.SearchbyPatientIdApproved(obj.PatientId);
            ViewBag.Appointments = appointments;
            return View(messages);

        }

        [HttpPost]
        public ActionResult AddMessage(int id, string txtMessage)
        {
            var obj = Session["PatientObj"] as Patient;
            var apt = service.GetAppointmentById(id, obj.PatientId);
            if (apt.MsgLimit <5)
            {
                apt.MsgLimit++;
                service.UpdateAppointment(apt);

                Message message = new Message();
                message.SenderId = (int)TempData["id"];
                message.ReceiverId = id;
                message.Status = "Sent";
                message.Message_ = txtMessage;
                service.AddMessage(message);

                return RedirectToAction("MessageDoctor", new { id = message.ReceiverId });
            }
            else
            {
                ModelState.AddModelError("", "Limit Exceeded");


                IEnumerable<Message> messages = service.GetBySenderIdAndRecieverId(obj.PatientId, id);

                TempData["ErrorMessage"] = "Message limit exceeded. You cannot ask more than Five Queries.";
                TempData["Messages"] = messages;

                return RedirectToAction("MessageDoctor");
            }
        }

        //list of medicine
        public ActionResult ViewMedicine()
        {
            if (Session["SId"] != null)
            {
                List<Medicine> medicines = service.GetAllMedicines();
                foreach (var med in medicines)
                {
                    med.Price = (float)(med.Price + med.Tax - med.Discount);
                }
                return View(medicines);
            }
            return RedirectToAction("PatientLogin", "Login");
        }

        [HttpPost]
        public ActionResult ViewMedicine(string MediName)
        {
            IEnumerable<Medicine> result = service.FindMedicineByName(MediName);
            return View(result);
        }
        [HttpPost]
        public ActionResult CancelAppoint(int id) 
        {
            Appointment appointment = service.GetAppointmentById(id);
            service.DeleteAppointment(appointment.AppointmentId);
            return RedirectToAction("ViewAppointments");
        }
        //patient profile change
        public ActionResult UpdatePatient()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["PatientObj"] as Patient;
                return View(obj);
            }
            return RedirectToAction("PatientLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdatePatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePatient(patient);
                return RedirectToAction("GetAllDoc","Patients");
            }
            return View();
        }


    }
}