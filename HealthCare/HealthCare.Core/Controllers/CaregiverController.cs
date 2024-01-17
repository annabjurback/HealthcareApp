using HealthCare.Core.Context;
using HealthCare.Core.Models;
using HealthCare.Core.Repositories;
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
        private readonly ICaregiverRepository _caregiverRepository;
        public CaregiverController(ICaregiverRepository caregiverRepository)
        {
            _caregiverRepository = caregiverRepository;
        }

        [HttpPost]
        public ActionResult CreateCaregiver(string id, string firstName, string lastName, string email, string role)
        {
            Caregiver Caregiver = new()
            {
                CaregiverId = id,
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
                Email = email,
                Role = role
            };
            try
            {
                _caregiverRepository.CreateCaregiver(Caregiver);

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
                return _caregiverRepository.GetCaregiver(id);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/api/caregiver/getall")]
        public ActionResult<List<Caregiver>> GetAll()
        {
            try
            {
                return Ok(_caregiverRepository.GetAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<Caregiver> EditCaregiver(string id, string firstName, string lastName, string role)
        {
            try
            {
                return Ok(_caregiverRepository.EditCaregiver(id, firstName, lastName, role));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException);
            }
        }
    }
}
