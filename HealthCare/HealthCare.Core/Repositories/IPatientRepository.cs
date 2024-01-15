using HealthCare.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Core.Repositories
{
    public interface IPatientRepository
    {
        Patient GetPatient(string id);
        void SavePatient(Patient patient);
        void UpdatePatient(string id, string firstName, string lastName);
    }
}