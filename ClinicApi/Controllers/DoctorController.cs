using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ClinicApi.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly Service service;//object define
        public DoctorController()
        {
            service = new Service();//object create
        }
        // GET: api/DoctorsApi
        public List<Doctor> GetDoctors()
        {

            return service.GetAllDoctors();
        }

        // GET: api/DoctorsApi/5
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult GetDoctor(int id)
        {
            Doctor doctor = service.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // PUT: api/DoctorsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            service.UpdateDoctor(doctor);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DoctorsApi
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddDoctor(doctor);

            return CreatedAtRoute("DefaultApi", new { id = doctor.DoctorId }, doctor);
        }

        // DELETE: api/DoctorsApi/5
        [ResponseType(typeof(Doctor))]
        public IHttpActionResult DeleteDoctor(int id)
        {
            Doctor doctor = service.GetDoctorById(id);//find doctor ,if found it removes ,otherwise notfound
            if (doctor == null)
            {
                return NotFound();
            }

            service.DeleteDoctor(id);
            return Ok(doctor);
        }

    }
}
