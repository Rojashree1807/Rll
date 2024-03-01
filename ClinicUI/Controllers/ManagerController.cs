using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicUI.Controllers
{
    public class ManagerController : Controller
    {
        private readonly Service service;//operation for all entity
        public ManagerController()
        {
            service = new Service();

        }
        public ActionResult Index()
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogin", "Login");
        }
        public ActionResult DisplayPatients()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllPatients());
            }
            return RedirectToAction("AdminLogin", "Login");
        }
        // GET:
        public ActionResult CreatePatients()
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        // POST
        [HttpPost]
        public ActionResult CreatePatients(Patient p)
        {
            service.InsertPatient(p);
            return RedirectToAction("DisplayPatients", "Manager");
        }
        [HttpGet]
        public ActionResult UpdatePatients(int id)
        {
            if (Session["SId"] != null)
            {
                Patient p = service.FindPatientById(id);
                return View(p);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdatePatients(Patient patient)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePatient(patient);
                return RedirectToAction("DisplayPatients","Manager");
            }
            return View();
        }
        // Delete patient
        public ActionResult DeletePatient(int id)
        {
            if (Session["SId"] != null)
            {
                Patient p = service.FindPatientById(id);
                return View(p);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult DeletePatient(int id, Patient m)
        {
            service.DeletePatient(id);
            return RedirectToAction("DisplayPatients", "Manager");//Patient list view 
        }

        //Doctor 
        public ActionResult DisplayDoctors()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllDoctors());
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        public ActionResult CreateDoctors()
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogin", "Login");
        }


        [HttpPost]
        public ActionResult CreateDoctors(Doctor doctor)
        {
            service.AddDoctor(doctor);
            return RedirectToAction("DisplayDoctors", "Manager");
        }

        [HttpGet]
        public ActionResult UpdateDoctors(int id)
        {
            if (Session["SId"] != null)
            {
                Doctor d = service.GetDoctorById(id);
                return View(d);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdateDoctors(Doctor d)
        {
            if (ModelState.IsValid)
            {
                service.UpdateDoctor(d);
                return RedirectToAction("DisplayDoctors", "Manager");
            }
            return View();
        }
        // Delete patient
        public ActionResult DeleteDoctors(int id)
        {
            if (Session["SId"] != null)
            {
                Doctor p = service.GetDoctorById(id);
                return View(p);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult DeleteDoctors(int id, Patient m)
        {
            service.DeleteDoctor(id);
            return RedirectToAction("DisplayDoctors", "Manager");//Patient list view 
        }

        //Pharmacist
        public ActionResult DisplayPharmasicts()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllPharmacists());
            }
            return RedirectToAction("AdminLogin", "Login");
        }
        // GET:
        public ActionResult CreatePharmasicts()
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        // POST
        [HttpPost]
        public ActionResult CreatePharmasicts(Pharmacist pharmacist)
        {
            service.AddPharmacist(pharmacist);
            return RedirectToAction("DisplayPharmasicts", "Manager");
        }
        [HttpGet]
        public ActionResult UpdatePharmacist(int id)
        {
            if (Session["SId"] != null)
            {
                Pharmacist pharmacist = service.GetPharmacistById(id);
                return View(pharmacist);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdatePharmacist(Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePharmacist(pharmacist);
                return RedirectToAction("DisplayPharmasicts", "Manager");
            }
            return View();
        }
        // Delete Pharmacist
        public ActionResult DeletePharmacist(int id)
        {
            if (Session["SId"] != null)
            {
                Pharmacist pharmacist = service.GetPharmacistById(id);
                return View(pharmacist);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult DeletePharmacist(int id, Patient m)
        {
            service.DeletePharmacist(id);
            return RedirectToAction("DisplayPharmasicts", "Manager");
        }
        //Front Officer
        public ActionResult Displayfrontofficer()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllFrontOfficer());
            }
            return RedirectToAction("AdminLogin", "Login");
        }
        // GET:
        public ActionResult Createfrontofficer()
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        // POST
        [HttpPost]
        public ActionResult Createfrontofficer(Front_Officer fo)
        {
            service.AddFrontOfficeExecutive(fo);
            return RedirectToAction("Displayfrontofficer", "Manager");
        }
        [HttpGet]
        public ActionResult Updatefrontofficer(int id)
        {
            if (Session["SId"] != null)
            {
                Front_Officer fo = service.GetFrontOfficeExecutiveById(id);
                return View(fo);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult Updatefrontofficer(Front_Officer fo)
        {
            if (ModelState.IsValid)
            {
                service.UpdateFrontOfficeExecutive(fo);
                return RedirectToAction("Displayfrontofficer", "Manager");
            }
            return View();
        }
        // Delete Pharmacist
        public ActionResult Deletefrontofficer(int id)
        {
            if (Session["SId"] != null)
            {
                Front_Officer fo = service.GetFrontOfficeExecutiveById(id);
                return View(fo);            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult Deletefrontofficer(int id, Patient m)
        {
            service.DeleteFrontOfficeExecutive(id);
            return RedirectToAction("Displayfrontofficer", "Manager");
        }
        //update manager

        public ActionResult Updatemanager()
        {
            if (Session["SId"] != null)
            {
                var mang = Session["mngObject"] as Manager;
                return View(mang);
            }
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpPost]
        public ActionResult Updatemanager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                service.UpdateAdmin(manager);
                return RedirectToAction("Index", "Manager");
            }
            return View();
        }

    }
}