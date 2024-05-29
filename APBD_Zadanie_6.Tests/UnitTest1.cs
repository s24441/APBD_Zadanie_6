using APBD_Zadanie_6.Abstracts;
using APBD_Zadanie_6.DTOs;
using APBD_Zadanie_6.Exceptions;
using APBD_Zadanie_6.Models;
using APBD_Zadanie_6.Repositories;
using APBD_Zadanie_6.Tests.DbSeed;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace APBD_Zadanie_6.Tests
{
    public class UnitTest1
    {
        private IPrescriptionRepository _prescriptionRepository = new PrescriptionRepository(
            new PharmacyContext(new DbContextOptionsBuilder<PharmacyContext>()
                .UseInMemoryDatabase(databaseName: "Database")
                .Options)
            .TestSeed()
            );

        [Fact]
        public async void Should_ThrowException_WhenDoctorNotExist()
        {
            var command = new PrescriptionDTO()
            {
                IdDoctor = 0,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Patient = new PatientDTO()
                {
                    IdPatient = 2
                },
                Medicaments = new List<MedicamentDTO> {
                    new MedicamentDTO() { IdMedicament = 1, Dose = 100, Description = "Smacznego" }
                }
            };

            await Should
                .ThrowAsync<MissingDoctorException>(_prescriptionRepository.AddPrescriptionAsync(command, CancellationToken.None));
        }

        [Fact]
        public async void Should_ThrowException_WhenDueDateLowerThanPrescriptionDate()
        {
            var command = new PrescriptionDTO()
            {
                IdDoctor = 1,
                Date = DateTime.Now.AddDays(30),
                DueDate = DateTime.Now,
                Patient = new PatientDTO()
                {
                    IdPatient = 2
                },
                Medicaments = new List<MedicamentDTO> {
                    new MedicamentDTO() { IdMedicament = 1, Dose = 100, Description = "Smacznego" }
                }
            };

            await Should
                .ThrowAsync<PrescriptionDateException>(_prescriptionRepository.AddPrescriptionAsync(command, CancellationToken.None));
        }

        [Fact]
        public async void Should_ThrowException_WhenMedicamentsCountGreatherThan10()
        {
            var command = new PrescriptionDTO()
            {
                IdDoctor = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Patient = new PatientDTO()
                {
                    IdPatient = 2
                },
                Medicaments = new List<MedicamentDTO> {
                    new MedicamentDTO() { IdMedicament = 1, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 2, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 3, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 4, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 5, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 6, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 7, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 8, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 9, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 10, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 11, Dose = 100, Description = "Smacznego" }
                }
            };

            await Should
                .ThrowAsync<PrescriptionMedicamentsMaxRangeExceedException>(_prescriptionRepository.AddPrescriptionAsync(command, CancellationToken.None));
        }

        [Fact]
        public async void Should_ThrowException_WhenMedicamentNotFound()
        {
            var command = new PrescriptionDTO()
            {
                IdDoctor = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Patient = new PatientDTO()
                {
                    IdPatient = 2
                },
                Medicaments = new List<MedicamentDTO> {
                    new MedicamentDTO() { IdMedicament = 1, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 2, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 3, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 4, Dose = 100, Description = "Smacznego" }
                }
            };

            await Should
                .ThrowAsync<MissingMedicamentException>(_prescriptionRepository.AddPrescriptionAsync(command, CancellationToken.None));
        }

        [Fact]
        public async Task Should_AddPrescriptionWith3Medicaments()
        {
            var command = new PrescriptionDTO()
            {
                IdDoctor = 6,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Patient = new PatientDTO()
                {
                    IdPatient = 2
                },
                Medicaments = new List<MedicamentDTO> {
                    new MedicamentDTO() { IdMedicament = 1, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 2, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 3, Dose = 100, Description = "Smacznego" }
                }
            };

            var result = await _prescriptionRepository.AddPrescriptionAsync(command, CancellationToken.None);

            result.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public async Task Should_AddPatientAndPrescriptionWith3Medicaments()
        {
            var command = new PrescriptionDTO()
            {
                IdDoctor = 6,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Patient = new PatientDTO()
                {
                    FirstName = "Andrzej",
                    LastName = "Michalecki",
                    BirthDate = DateTime.Parse("1989-04-04")
                },
                Medicaments = new List<MedicamentDTO> {
                    new MedicamentDTO() { IdMedicament = 1, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 2, Dose = 100, Description = "Smacznego" },
                    new MedicamentDTO() { IdMedicament = 3, Dose = 100, Description = "Smacznego" }
                }
            };

            var result = await _prescriptionRepository.AddPrescriptionAsync(command, CancellationToken.None);

            result.ShouldBeEquivalentTo(5);
        }
    }
}