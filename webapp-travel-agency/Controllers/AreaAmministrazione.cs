using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{
    public class AreaAmministrazione : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
    }
}
