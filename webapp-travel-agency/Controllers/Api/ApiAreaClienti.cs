using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAreaClienti : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            // questo controller vede se ci sono corrispondenze per con il titolo o la descrizione
            //se la ricerca è diversa da null e non è vuota, cerca la pizza, altrimenti stampa tutta la lista di pizze.
            List<Viaggio> ViaggioApi = new List<Viaggio>();
            using ( AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
                if (search != null && search != "")
                {
                    ViaggioApi = DatabaseAgenziaDiViaggi.Viaggi.Where(Viaggio =>Viaggio.TitoloViaggio.Contains(search) || Viaggio.DescrizioneViaggio.Contains(search)).ToList<Viaggio>();
                }
                else
                {
                    ViaggioApi = DatabaseAgenziaDiViaggi.Viaggi.Include(Viaggio => Viaggio.Id).ToList<Viaggio>();
                }

            return Ok(ViaggioApi);
        }
    }
}
