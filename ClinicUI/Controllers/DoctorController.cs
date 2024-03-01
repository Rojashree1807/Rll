using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicUI.Controllers
{
    public class DoctorController : Controller
    {
        private Service service;

        public DoctorController()
        {
            service = new Service();
        }

        //Get Medicine List view
        public ActionResult MedicineList()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllMedicines());
            }
            return RedirectToAction("DoctorLogin", "Login");
        }

        [HttpPost]
        public ActionResult MedicineList(string MediName)
        {
            IEnumerable<Medicine> medicine = service.FindMedicineByName(MediName);
            if (medicine != null)
            {
                return View(medicine);
            }
            return View(medicine);
        }

        //Appointment List View 
        public ActionResult AppointmentList()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["DocObject"] as Doctor;
                var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId);
                return View(appointments);
            }
            return RedirectToAction("DoctorLogin", "Login");
        }

        //Message page UI view
        public ActionResult MessagePatient()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["DocObject"] as Doctor;
                Session["DoctorId"] = obj.DoctorId;
                var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId);
                ViewBag.Appointments = appointments;
                return View();
            }
            return RedirectToAction("DoctorLogin", "Login");
        }

        [HttpPost]
        public ActionResult MessagePatient(int id)
        {
            var obj = Session["DocObject"] as Doctor;
            Patient patient = service.FindPatientById(id);
            Session["PatientId"] = patient.PatientId;
            Session["Pname"] = patient.Name;
            IEnumerable<Message> messages = service.GetBySenderIdAndRecieverId(obj.DoctorId, patient.PatientId);
            var appointments = service.SearchbyDoctorIdApproved(obj.DoctorId);
            ViewBag.Appointments = appointments;
            return View(messages);
        }

        [HttpPost]
        public ActionResult AddMessage(int id, string txtMessage)
        {
            Message message = new Message();
            message.SenderId = (int)Session["DoctorId"];
            message.ReceiverId = id;
            message.Status = "Message Sent";
            message.Message_ = txtMessage;
            service.AddMessage(message);
            return RedirectToAction("MessagePatient", message.ReceiverId);
        }

        [HttpGet]
        public ActionResult UpdateProfile()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["DocObject"] as Doctor;
                return View(obj);
            }
            return RedirectToAction("DoctorLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdateProfile(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                service.UpdateDoctor(doctor);
                return RedirectToAction("AppointmentList");
            }
            return View();
        }


    }
}