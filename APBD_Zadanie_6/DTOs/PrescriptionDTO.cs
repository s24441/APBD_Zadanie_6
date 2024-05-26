namespace APBD_Zadanie_6.DTOs
{
    public class PrescriptionDTO
    {
        public List<PatientDTO> Patients { get; set; } = new();
        public List<MedicamentDTO> Medicaments { get; set; } = new();
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
    }
}
