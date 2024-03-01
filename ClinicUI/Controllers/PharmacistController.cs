using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicUI.Controllers
{
    public class PharmacistController : Controller
    {
        private readonly Service service;

        public PharmacistController()
        {
            service = new Service();
        }
        public ActionResult Index()
        {
            if (Session["SId"] != null)
            {
                return View(service.GetAllMedicines());
            }
            return RedirectToAction("PharmacistsLogin", "Login");
        }
        // GET:
        public ActionResult Create()
        {
            if (Session["SId"] != null)
            {
                return View();
            }
            return RedirectToAction("PharmacistsLogin", "Login");
        }

        // POST
        [HttpPost]
        public ActionResult Create(Medicine medicine)
        {
            service.AddMedicine(medicine);
            return RedirectToAction("Index", "Pharmacist");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["SId"] != null)
            {
                Medicine medicine = service.GetMedicineById(id);
                return View(medicine);
            }
            return RedirectToAction("PharmacistsLogin", "Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                service.UpdateMedicine(medicine);
                return RedirectToAction("Index","Pharmacist");
            }
            return View(medicine);
        }
        // Delete Medicine
        public ActionResult Delete(int id)
        {
            if (Session["SId"] != null)
            {
                Medicine medicine = service.GetMedicineById(id);
                return View(medicine);
            }
            return RedirectToAction("PharmacistsLogin", "Home");
        }

        [HttpPost]
        public ActionResult Delete(int id,Medicine m)
        {
            service.DeleteMedicine(id);
            return RedirectToAction("Index","Pharmacist");//medicine list view 
        }
        public ActionResult SearchByName(string searchQuery)
        {
                if (string.IsNullOrWhiteSpace(searchQuery))
                {
                    return RedirectToAction(nameof(Index));
                }

                var medicines = service.FindMedicineByName(searchQuery);
              return View("Index", medicines);
        }
        public ActionResult UpdateInfo()
        {
            if (Session["SId"] != null)
            {
                var obj = Session["PhObject"] as Pharmacist;
                return View(obj);
            }
            return RedirectToAction("PharmacistsLogin", "Login");
        }

        [HttpPost]
        public ActionResult UpdateInfo(Pharmacist p)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePharmacist(p);
                return RedirectToAction("Index", "Pharmacist");
            }
            return View();
        }


    }
}

