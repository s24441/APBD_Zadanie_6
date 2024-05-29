using APBD_Zadanie_6.Abstracts;
using APBD_Zadanie_6.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet("{idPatient}")]
        public async Task<ActionResult<PatientInfoDTO>> GetPatientInfo([FromRoute] int idPatient)
        {
            var result = await _patientRepository.GetPatientInfoAsync(idPatient);
            if (result == default) return NotFound();
            return Ok(result);
        }
    }
}
