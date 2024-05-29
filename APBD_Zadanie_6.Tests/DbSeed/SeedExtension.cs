using APBD_Zadanie_6.Models;

namespace APBD_Zadanie_6.Tests.DbSeed
{
    public static class SeedExtension
    {
        public static PharmacyContext TestSeed(this PharmacyContext context) => context
            .SeedDoctors()
            .SeedMedicaments()
            .SeedPatients()
            .SeedPrescriptions()
            .SeedPrescriptionMedicaments();

        private static PharmacyContext SeedDoctors(this PharmacyContext context)
        {
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Sample",
                    LastName = "Doctor",
                    Email = "SampleDoctor@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Jakub",
                    LastName = "Biologist",
                    Email = "JakubBiologist@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Michal",
                    LastName = "Pediatrician",
                    Email = "MichalPediatrician@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 4,
                    FirstName = "Sergio",
                    LastName = "Psychiatrist",
                    Email = "SergioPsychiatrist@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 5,
                    FirstName = "Pablo",
                    LastName = "Anesthesiologist",
                    Email = "PabloAnesthesiologist@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 6,
                    FirstName = "Azucar",
                    LastName = "Diabetes",
                    Email = "AzucarDiabetes@gmail.com"
                }
            };

            if (!doctors.Any(d => context.Doctors.Any(e => e.IdDoctor == d.IdDoctor)))
            {
                context.Doctors.AddRange(doctors);
                context.SaveChanges();
            }

            return context;
        }
        private static PharmacyContext SeedMedicaments(this PharmacyContext context)
        {
            var medicaments = new List<Medicament>
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Ibuprofène",
                    Description = "Painkiller, 200mg 3 times a day.",
                    Type = "Anti inflamatory pills"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Happyness",
                    Description = "From 10 to 1000 times a day.",
                    Type = "Anti sadness pills"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Sadness",
                    Description = "CAN HARM YOUR HEALTH.",
                    Type = "Anti happyness pills"
                }
            };

            if (!medicaments.Any(d => context.Medicaments.Any(e => e.IdMedicament == d.IdMedicament)))
            {
                context.Medicaments.AddRange(medicaments);
                context.SaveChanges();
            }

            return context;
        }
        private static PharmacyContext SeedPatients(this PharmacyContext context)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Jakub",
                    LastName = "Nowak",
                    BirthDate = DateTime.Now.AddYears(-25)
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Michal",
                    LastName = "Kowalski",
                    BirthDate = DateTime.Now.AddYears(-21)
                },
                new Patient
                {
                    IdPatient = 3,
                    FirstName = "Patient",
                    LastName = "Patientowich",
                    BirthDate = DateTime.Now.AddYears(-27)
                },
                new Patient
                {
                    IdPatient = 4,
                    FirstName = "Sergio",
                    LastName = "Kotowich",
                    BirthDate = DateTime.Now.AddYears(-22)
                },
                new Patient
                {
                    IdPatient = 5,
                    FirstName = "Ala",
                    LastName = "Peronska",
                    BirthDate = DateTime.Now.AddYears(-50)
                },
                new Patient
                {
                    IdPatient = 6,
                    FirstName = "Kot",
                    LastName = "Zygmund",
                    BirthDate = DateTime.Now.AddYears(-29)
                },
                new Patient
                {
                    IdPatient = 7,
                    FirstName = "Natiel",
                    LastName = "Patient",
                    BirthDate = DateTime.Now.AddYears(-54)
                },
                new Patient
                {
                    IdPatient = 8,
                    FirstName = "Jas",
                    LastName = "Profase",
                    BirthDate = DateTime.Now.AddYears(-67)
                }
            };

            if (!patients.Any(d => context.Patients.Any(e => e.IdPatient == d.IdPatient)))
            {
                context.Patients.AddRange(patients);
                context.SaveChanges();
            }

            return context;
        }
        private static PharmacyContext SeedPrescriptions(this PharmacyContext context)
        {
            var prescriptions = new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    IdPatient = 1,
                    IdDoctor = 3,
                    Date = DateTime.Now.AddDays(-7),
                    DueDate = DateTime.Now.AddDays(30)
                },
                new Prescription
                {
                    IdPrescription = 2,
                    IdPatient = 4,
                    IdDoctor = 2,
                    Date = DateTime.Now.AddDays(-1),
                    DueDate = DateTime.Now.AddDays(60)
                },
                new Prescription
                {
                    IdPrescription = 3,
                    IdPatient = 2,
                    IdDoctor = 5,
                    Date = DateTime.Now.AddDays(-12),
                    DueDate = DateTime.Now.AddDays(30)
                }
            };

            if (!prescriptions.Any(d => context.Prescriptions.Any(e => e.IdPrescription == d.IdPrescription)))
            {
                context.Prescriptions.AddRange(prescriptions);
                context.SaveChanges();
            }

            return context;
        }
        private static PharmacyContext SeedPrescriptionMedicaments(this PharmacyContext context)
        {
            var prescriptionMedicaments = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 200,
                    Details = "2 pills in am and pm"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 2,
                    IdPrescription = 1,
                    Dose = 250,
                    Details = "2 pills in am and pm"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 250,
                    Details = "2 pills in am and pm"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 3,
                    IdPrescription = 3,
                    Dose = 250,
                    Details = "2 pills in am and pm"
                }
            };

            if (!prescriptionMedicaments.Any(d => context.PrescriptionMedicaments.Any(e => e.IdPrescription == d.IdPrescription && e.IdMedicament == d.IdMedicament)))
            {
                context.PrescriptionMedicaments.AddRange(prescriptionMedicaments);
                context.SaveChanges();
            }

            return context;
        }
    }
}
