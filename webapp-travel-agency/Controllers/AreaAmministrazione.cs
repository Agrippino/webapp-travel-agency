using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class AreaAmministrazione : Controller
    {
        //metodo get-Index che restituirà una pagina con tutti i viaggi 
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

        //metodo get Dettagli per vede i dettagli di un viaggio
        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {
                try
                {
                    // metodo per cercare i viaggi siponibili 
                    Viaggio TrovaViaggio = DatabaseAgenziaDiViaggi.Viaggi.Where(Viaggio => Viaggio.Id == id)
                            .Include(Viaggio => Viaggio.Id)
                            .FirstOrDefault();

                    return View("DettagliViaggio", TrovaViaggio);
                }
                catch (InvalidOperationException)
                {
                    return NotFound("Il viaggio con id" + id + " non è stato trovato");
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }


        [HttpGet]
        public IActionResult CreaNuovoViaggio()
        {
            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {
                List<Viaggio> ViaggiADisposizione = DatabaseAgenziaDiViaggi.Viaggi.ToList();
                Viaggio modelloDaPassare = new Viaggio();
                              
                return View("FormCreaNuovoViaggio", modelloDaPassare);
            } 
        }
    }
}
