namespace APBD_Zadanie_6.DTOs
{
    public class PrescriptionInfoDTO
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<MedicamentInfoDTO> Medicaments { get; set; } = new List<MedicamentInfoDTO>();
        public DoctorInfoDTO? Doctor { get; set; }
    }
}
