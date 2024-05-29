using APBD_Zadanie_6.DTOs;

namespace APBD_Zadanie_6.Abstracts
{
    public interface IPatientRepository
    {
        Task<PatientInfoDTO?> GetPatientInfoAsync(int IdPatient, CancellationToken cancellationToken = default);
    }
}
