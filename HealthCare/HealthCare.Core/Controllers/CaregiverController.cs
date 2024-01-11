using HealthCare.Core.Context;
using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.Controllers
{
    [Route("/api/caregiver")]
    public class CaregiverController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public CaregiverController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult CreateCaregiver(string id, string firstName, string lastName, string email)
        {
            Caregiver Caregiver = new()
            {
                CaregiverId = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
            };
            try
            {
                _context.Caregivers.Add(Caregiver);
                _context.SaveChanges();

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                // inner exception
                var innerException = ex.InnerException;

                return NotFound(innerException);
            }
        }

        [HttpGet]
        public ActionResult<Caregiver> GetCaregiver(string id)
        {
            try
            {
                return _context.Caregivers.Single(x => x.CaregiverId == id);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/getall")]
        public ActionResult<List<Caregiver>> GetAll()
        {
            try
            {
                return Ok(_context.Caregivers.ToList());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<Caregiver> EditCaregiver(string id, string firstName, string lastName)
        {
            try
            {
                var caregiver = _context.Caregivers.Single(x => x.CaregiverId == id);
                caregiver.FirstName = firstName;
                caregiver.LastName = lastName;

                _context.SaveChanges();

                return Ok(caregiver);
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException);
            }
        }
    }
}
