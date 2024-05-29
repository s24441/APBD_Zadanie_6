using APBD_Zadanie_6.DTOs;

namespace APBD_Zadanie_6.Abstracts
{
    public interface IPrescriptionRepository
    {
        Task<int> AddPrescriptionAsync(PrescriptionDTO prescription, CancellationToken cancellationToken = default);
    }
}
