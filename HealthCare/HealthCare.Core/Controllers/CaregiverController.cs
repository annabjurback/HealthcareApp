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
    [Route("/caregiver")]
    public class CaregiverController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public CaregiverController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet("/caregiverexist")]
        public ActionResult<bool> CaregiverExists(Guid caregiverId)
        {
            if (_context.Caregivers.Single(x => x.CaregiverId == caregiverId) != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        [HttpPost("/savecaregiver")]
        public ActionResult SaveCaregiver(Guid caregiverId, string firstName, string lastName, string email)
        {
            Caregiver Caregiver = new()
            {
                CaregiverId = caregiverId,
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

        [HttpGet("/caregiver")]
        public ActionResult<Caregiver> GetCaregiver(Guid caregiverId)
        {
            return _context.Caregivers.Single(x => x.CaregiverId == caregiverId);
        }

        [HttpPut]
        public ActionResult<Caregiver> EditCaregiver(Guid caregiverId, string firstName, string lastName)
        {
            try
            {
                var caregiver = _context.Caregivers.Single(x => x.CaregiverId == caregiverId);
                caregiver.FirstName = firstName;
                caregiver.LastName = lastName;

                _context.SaveChanges();

                return Ok(caregiver);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
