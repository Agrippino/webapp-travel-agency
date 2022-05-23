using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class AreaAmministrazione : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Viaggio> ViaggiADisposizione = new List<Viaggio>();

            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {
                ViaggiADisposizione = DatabaseAgenziaDiViaggi.Viaggi.ToList<Viaggio>();
            }
            return View("HomepageAmministrazione", ViaggiADisposizione);
        }

        
    }
}
