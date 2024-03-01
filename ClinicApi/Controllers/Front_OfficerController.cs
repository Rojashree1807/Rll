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
    public class Front_OfficerController : ApiController
    {
        private readonly Service service;
        public Front_OfficerController()
        {
            service = new Service();
        }

        // GET: api/FrontOfficeExecutivesApi
        public IEnumerable<Front_Officer> GetFrontOfficeExecutives()
        {
            return service.GetAllFrontOfficer();
        }

        // GET: api/FrontOfficeExecutivesApi/5
        [ResponseType(typeof(Front_Officer))]
        public IHttpActionResult GetFrontOfficeExecutive(int id)
        {
            Front_Officer frontOfficeExecutive = service.GetFrontOfficeExecutiveById(id);
            if (frontOfficeExecutive == null)
            {
                return NotFound();
            }

            return Ok(frontOfficeExecutive);
        }

        // PUT: api/FrontOfficeExecutivesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFrontOfficeExecutive(int id, Front_Officer frontOfficeExecutive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frontOfficeExecutive.Front_OfficerId)
            {
                return BadRequest();
            }

            service.UpdateFrontOfficeExecutive(frontOfficeExecutive);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FrontOfficeExecutivesApi
        [ResponseType(typeof(Front_Officer))]
        public IHttpActionResult PostFrontOfficeExecutive(Front_Officer frontOfficeExecutive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddFrontOfficeExecutive(frontOfficeExecutive);

            return CreatedAtRoute("DefaultApi", new { id = frontOfficeExecutive.Front_OfficerId }, frontOfficeExecutive);
        }

        // DELETE: api/FrontOfficeExecutivesApi/5
        [ResponseType(typeof(Front_Officer))]
        public IHttpActionResult DeleteFrontOfficeExecutive(int id)
        {
            Front_Officer frontOfficeExecutive = service.GetFrontOfficeExecutiveById(id);
            if (frontOfficeExecutive == null)
            {
                return NotFound();
            }

            service.DeleteFrontOfficeExecutive(id);

            return Ok(frontOfficeExecutive);
        }

    }
}
