using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PatientData.Models;

namespace PatientData.Controllers
{
    [EnableCors("*", "*", "GET")]
    [Authorize]
    public class PatientsController : ApiController
    {
        private IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            var cursor = _patients.FindSync(_ => true);
            return cursor.ToList();
        }

        public IHttpActionResult Get(string id)
        {
            var patient = _patients.FindSync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.First());
        }

        [Route("api/patients/{id}/medications")]
        public HttpResponseMessage GetMedications(string id)
        {
            var patient = _patients.FindSync(p => p.Id == id);
            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found");
            }

            return Request.CreateResponse(patient.First().Medications);
        }
    }
}
