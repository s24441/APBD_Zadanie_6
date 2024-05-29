namespace APBD_Zadanie_6.DTOs
{
    public class PatientInfoDTO
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<PrescriptionInfoDTO> Prescriptions { get; set; } = new List<PrescriptionInfoDTO>();
    }
}
