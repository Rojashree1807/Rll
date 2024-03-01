using CaptchaMvc.HtmlHelpers;
using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly Service service;
        public LoginController()
        {
            service = new Service();
        }
        
       public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            Session["SId"] = 1;
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Manager manager)
        {
            if (!ModelState.IsValid)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (service.checkAdminLogin(manager))
                    {
                        Manager ad = service.FindAdminByEmail(manager.Email);
                        Session["mngObject"] = ad;

                        return RedirectToAction("Index", "Manager");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }
                }
                
                
            }
            return View();
        }

        public ActionResult DoctorLogin()
        {
            Session["SId"] = 2;
            return View();
        }

        [HttpPost]
        public ActionResult DoctorLogin(Doctor doctor)
        {
            if (doctor.Email != null && doctor.Password != null)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (service.checkDoctorLogin(doctor))
                    {
                        Doctor doc = service.FindDoctorByEmail(doctor.Email);
                        Session["DocObject"] = doc;
                        return RedirectToAction("AppointmentList", "Doctor");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }
                }
                
            }
            return View();
        }
        public ActionResult PatientLogin()
        {
            Session["SId"] = 3;
            return View();
        }

        [HttpPost]
        public ActionResult PatientLogin(Patient patient)
        {
            if (patient.Email != null && patient.Password != null)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (service.checkPatientLogin(patient))
                    {
                        Patient patient1 = service.FindPatientByEmail(patient.Email);
                        Session["PatientObj"] = patient1;
                        return RedirectToAction("GetAllDoc", "Patients");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }
                }
                
            }
            return View();
        }
        public ActionResult FrontOfficeLogin()
        {
            Session["SId"] = 4;
            return View();
        }

        [HttpPost]
        public ActionResult FrontOfficeLogin(Front_Officer frontOffice)
        {
            if (frontOffice.Email != null && frontOffice.Password != null)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (service.checkFrontOfficerLogin(frontOffice))
                    {
                        Front_Officer FE1 = service.FindFrontOfficeByEmail(frontOffice.Email);
                        Session["FOObject"] = FE1;
                        return RedirectToAction("ViewAppointment", "FrontOfficer");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }
                }
                
            }
            return View();
        }
        public ActionResult PharmacistsLogin()
        {
            Session["SId"] = 5;
            return View();
        }

        [HttpPost]
        public ActionResult PharmacistsLogin(Pharmacist pharmacist)
        {
            if (pharmacist.Email != null && pharmacist.Password != null)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    if (service.checkPharmistLogin(pharmacist))
                    {
                        Pharmacist Ph1 = service.FindPharmacistByEmail(pharmacist.Email);
                        Session["PhObject"] = Ph1;
                        return RedirectToAction("Index", "Pharmacist");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Valid Credentials");
                        return View();
                    }
                }

                
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}