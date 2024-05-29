using APBD_Zadanie_6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_Zadanie_6.Configuration
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");
            builder.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
            builder.Property(e => e.IdPrescription).UseIdentityColumn();

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder
                .HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .HasConstraintName("Doctor_Prescription_FK");
            
            builder
                .HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient)
                .HasConstraintName("Patient_Prescription_FK");

            // adding data

            var prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription
            {
                IdPrescription = 1,
                IdPatient = 1,
                IdDoctor = 3,
                Date = DateTime.Now.AddDays(-7),
                DueDate = DateTime.Now.AddDays(30)
            });

            prescriptions.Add(new Prescription
            {
                IdPrescription = 2,
                IdPatient = 4,
                IdDoctor = 2,
                Date = DateTime.Now.AddDays(-1),
                DueDate = DateTime.Now.AddDays(60)
            });

            prescriptions.Add(new Prescription
            {
                IdPrescription = 3,
                IdPatient = 2,
                IdDoctor = 5,
                Date = DateTime.Now.AddDays(-12),
                DueDate = DateTime.Now.AddDays(30)
            });

            builder.HasData(prescriptions);
        }
    }
}
