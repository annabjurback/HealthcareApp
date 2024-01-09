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
        public bool CaregiverExists(Guid caregiverId)
        {
            if (_context.Caregivers.Single(x => x.CaregiverId == caregiverId) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost("/savecaregiver")]
        public void SaveCaregiver(Guid caregiverId, string firstName, string lastName, string email)
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
            }
            catch (DbUpdateException ex)
            {
                // inner exception
                var innerException = ex.InnerException;
            }
        }

        [HttpGet("/caregiver")]
        public Caregiver GetCaregiver(Guid caregiverId)
        {
            return _context.Caregivers.Single(x => x.CaregiverId == caregiverId);
        }
    }
}
