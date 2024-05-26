using APBD_Zadanie_6.DTOs;

namespace APBD_Zadanie_6.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<int> AddPrescription(PrescriptionDTO prescription);
    }
    public class PrescriptionRepository : IPrescriptionRepository
    {
        public Task<int> AddPrescription(PrescriptionDTO prescription)
        {
            throw new NotImplementedException();
        }
    }
}
