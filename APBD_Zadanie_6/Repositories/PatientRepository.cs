using APBD_Zadanie_6.Abstracts;
using APBD_Zadanie_6.DTOs;
using APBD_Zadanie_6.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Zadanie_6.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PharmacyContext _context;
        public PatientRepository(PharmacyContext context)
        {
            _context = context;
        }

        public async Task<PatientInfoDTO?> GetPatientInfoAsync(int IdPatient, CancellationToken cancellationToken = default)
        {
            var patient = await _context.Patients
                .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.Doctor)
                .Include(p => p.Prescriptions)
                .ThenInclude(pr => pr.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
                .FirstOrDefaultAsync(p => p.IdPatient == IdPatient, cancellationToken);

            return patient != default ? new PatientInfoDTO { 
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName, 
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Prescriptions = patient.Prescriptions.Select(p => new PrescriptionInfoDTO() { 
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = p.Doctor != default ? new DoctorInfoDTO()
                    {
                        IdDoctor = p.Doctor.IdDoctor,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                        Email = p.Doctor.Email
                    } : default,
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentInfoDTO() { 
                        IdMedicament = pm.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Details
                    })
                }).OrderBy(p => p.DueDate)
            } : default;
        }
    }
}
