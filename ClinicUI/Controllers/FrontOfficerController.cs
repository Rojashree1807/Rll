using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicApi.Models;

namespace ClinicUI.Controllers
{
    public class FrontOfficerController : Controller
    {
        private readonly Service service;
        public FrontOfficerController()
        {
            service = new Service(); //object create
        }


        public ActionResult AddPatient()//Adding patient
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("FrontOfficeLogin", "Login");
        }

        [HttpPost]
        public ActionResult AddPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                service.InsertPatient(patient);
                return RedirectToAction("ViewAppointment", "FrontOfficer");
            }
            return View();
        }
        public ActionResult BookAppointment()//Book_Appointment 
        {
            if (Session["SId"] != null)
            {
                ViewBag.Patient = service.GetAllPatients();  
                ViewBag.Doctor = service.GetAllDoctors();         
                return View();
            }
            return RedirectToAction("FrontOfficeLogin", "Login");
        }
        [HttpPost]
        public ActionResult BookAppointment(Appointment appointment)
        {
            if (appointment.StartDateTime.Date >= DateTime.Now.Date)
            {
                if (ModelState.IsValid)
                {
                    service.AddAppointment(appointment);
                    return RedirectToAction("ViewAppointment");
                }
            }
            ModelState.AddModelError("StartDateTime", "Select Valid date");
            ViewBag.Patient = service.GetAllPatients();
            ViewBag.Doctor = service.GetAllDoctors();
            return View();
        }
        public ActionResult ViewAppointment()//View_Appointments
        {
            if (Session["SId"] != null)
            {
                List<Appointment> Appoinmentlist = service.GetAllAppointments();
                return View(Appoinmentlist);
            }
            return RedirectToAction("FrontOfficeLogin", "Login");
        }

        [HttpPost]
        public ActionResult ViewAppointment(string PatientSearch)
        {
            IEnumerable<Appointment> patientAppoinments = service.FindPatientAppointByName(PatientSearch);
            return View(patientAppoinments);
        }

        [HttpPost]
        public ActionResult ApproveAppoint(int id)//Post Action for Approve Appointments
        {
            Appointment appointment = service.GetAppointmentById(id);
            appointment.IsApprove = true;
            appointment.Status = "Approved";
            service.UpdateAppointment(appointment);
            return RedirectToAction("ViewAppointment");
        }
        [HttpPost]
        public ActionResult RejectAppoint(int id) //Post Action for Reject Approvement
        {
            Appointment appointment = service.GetAppointmentById(id);
            appointment.IsApprove = false;
            appointment.Status = "Rejected";
            service.UpdateAppointment(appointment);
            return RedirectToAction("ViewAppointment");
        }
        public ActionResult UpdateOfficerInfo()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["PhObject"] as Front_Officer;
                return View(obj);
            }
            return RedirectToAction("FrontOfficeLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdateOfficerInfo(Front_Officer o)
        {
            if (ModelState.IsValid)
            {
                service.UpdateFrontOfficeExecutive(o);
                return RedirectToAction("ViewAppointment", "FrontOfficer");
            }
            return View();
        }

    }
}