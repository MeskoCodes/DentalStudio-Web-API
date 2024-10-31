using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int patientId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken = default);
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
