using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ClinicUI.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly Service service;
        public ResetPasswordController()
        {
            service = new Service();
        }
        public bool Checkpass(string p1, string p2)//logic for pass
        {
            if (p1 == p2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult ResetAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResetAdmin(string email, string pass1, string pass2, int SId)
        {
            if (SId==1)
            {
                if (Checkpass(pass1, pass2))
                {
                    Manager ad = service.FindAdminByEmail(email);
                    if (ad == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    ad.Password = pass1;
                    service.UpdateAdmin(ad);
                    return RedirectToAction("AdminLogin","Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
                }
            }
            return View();
        }
        public ActionResult ResetPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPatient(string email, string pass1, string pass2, int SId)
        {
            if (SId == 3)
            {
                if (Checkpass(pass1, pass2))
                {
                    Patient patient = service.FindPatientByEmail(email);
                    if (patient == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    patient.Password = pass1;
                    service.UpdatePatient(patient);
                    return RedirectToAction("PatientLogin","Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
                }
            }
            return View();
        }
        public ActionResult ResetDoc()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResetDoc(string email, string pass1, string pass2, int SId)
        {
            if (SId == 2)
            {
                if (Checkpass(pass1, pass2))
                {
                    Doctor doc = service.FindDoctorByEmail(email);
                    if (doc == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    doc.Password = pass1;
                    service.UpdateDoctor(doc);
                    return RedirectToAction("DoctorLogin","Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
                }
            }
            return View();
        }
        public ActionResult ResetFO()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetFO(string email, string pass1, string pass2, int SId)
        {
            if (SId == 1)
            {
                if (Checkpass(pass1, pass2))
                {
                    Front_Officer Fo = service.FindFrontOfficeByEmail(email);
                    if (Fo == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    Fo.Password = pass1;
                    service.UpdateFrontOfficeExecutive(Fo);
                    return RedirectToAction("FrontOfficeLogin", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
                }
            }
            return View();
        }
        public ActionResult ResetPhar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResetPhar(string email, string pass1, string pass2, int SId)
        {
            if (SId == 1)
            {
                if (Checkpass(pass1, pass2))
                {
                    Pharmacist ph = service.FindPharmacistByEmail(email);
                    if (ph == null)
                    {
                        ModelState.AddModelError("", "Email is not valid");
                        return View();
                    }
                    ph.Password = pass1;
                    service.UpdatePharmacist(ph);
                    return RedirectToAction("PharmacistsLogin", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Both Password Must Be Same");
                }
            }
            return View();
        }


    }
}