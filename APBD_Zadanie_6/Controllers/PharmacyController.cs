using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
