using APBD_Zadanie_6.Abstracts;
using APBD_Zadanie_6.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        public PrescriptionController(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }
    
        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDTO prescription)
        {
            return Ok(await _prescriptionRepository.AddPrescriptionAsync(prescription));
        }
    }
}
