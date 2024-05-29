using APBD_Zadanie_6.Abstracts;
using APBD_Zadanie_6.DTOs;
using APBD_Zadanie_6.Exceptions;
using APBD_Zadanie_6.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Zadanie_6.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private const int PRESCRIPTION_MEDICAMENTS_MAX_COUNT = 10;
        private readonly PharmacyContext _context;
        public PrescriptionRepository(PharmacyContext context)
        {
            _context = context;
        }

        public async Task<int> AddPrescriptionAsync(PrescriptionDTO prescription, CancellationToken cancellationToken = default)
        {
            if (prescription.DueDate < prescription.Date)
                throw new PrescriptionDateException($"DueDate {prescription.DueDate} can not be lower than prescription date {prescription.Date}");

            var doctorEntity = await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == prescription.IdDoctor, cancellationToken);
            if (doctorEntity == default)
                throw new MissingDoctorException($"The doctor with id {prescription.IdDoctor} doest not exists in the database");

            var distinctMedicaments = prescription.Medicaments.DistinctBy(m => m.IdMedicament);

            if (distinctMedicaments.Count() > PRESCRIPTION_MEDICAMENTS_MAX_COUNT)
                throw new PrescriptionMedicamentsMaxRangeExceedException($"Prescription can not contain more than {PRESCRIPTION_MEDICAMENTS_MAX_COUNT} medicaments");

            var medicamentsEntities = new Dictionary<int, Medicament>();

            foreach (var m in distinctMedicaments)
            {
                var medicamentEntity = await _context.Medicaments.FirstOrDefaultAsync(e => e.IdMedicament == m.IdMedicament, cancellationToken);
                if (medicamentEntity == default)
                    throw new MissingMedicamentException($"Medicament with id {m.IdMedicament} does not exists in the database");
                medicamentsEntities.Add(medicamentEntity.IdMedicament, medicamentEntity);
            }

            var patientEntity = await _context.Patients
                .FirstOrDefaultAsync(p => p.IdPatient == prescription.Patient.IdPatient, cancellationToken);
            
            if (patientEntity == default)
                patientEntity = new Patient {
                    FirstName = prescription.Patient.FirstName,
                    LastName = prescription.Patient.LastName,
                    BirthDate = prescription.Patient.BirthDate
                };

            _context.Patients.Add(patientEntity);
            await _context.SaveChangesAsync(cancellationToken);

            var prescriptionEntity = new Prescription {
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Patient = patientEntity,
                Doctor = doctorEntity,
                PrescriptionMedicaments = prescription.Medicaments.Select(me => new PrescriptionMedicament() { 
                    Medicament = medicamentsEntities[me.IdMedicament],
                    Dose = me.Dose,
                    Details = me.Description
                }).ToList()
            };

            _context.Prescriptions.Add(prescriptionEntity);
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
