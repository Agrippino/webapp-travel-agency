using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class AreaAmministrazioneController : Controller
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

        //metodo crea nuovo viaggio
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaNuovoViaggio(Viaggio DatiViaggio)
        {
            if (!ModelState.IsValid)
            {
                using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
                {
                    List<Viaggio> ViaggiADisposizione = DatabaseAgenziaDiViaggi.Viaggi.ToList();
                }
                return View("FormCreaNuovoViaggio", DatiViaggio);
            }
            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {
                Viaggio NuovoViaggioDaAggiungere = new Viaggio();
                NuovoViaggioDaAggiungere.ImmagineViaggio = DatiViaggio.ImmagineViaggio;
                NuovoViaggioDaAggiungere.TitoloViaggio = DatiViaggio.TitoloViaggio;
                NuovoViaggioDaAggiungere.DescrizioneViaggio = DatiViaggio.DescrizioneViaggio;
                NuovoViaggioDaAggiungere.DurataViaggio = DatiViaggio.DurataViaggio;
                NuovoViaggioDaAggiungere.DestinazioniViaggio = DatiViaggio.DestinazioniViaggio;
                NuovoViaggioDaAggiungere.CostoViaggio = DatiViaggio.CostoViaggio;
                DatabaseAgenziaDiViaggi.Add(DatiViaggio);
                DatabaseAgenziaDiViaggi.SaveChanges();
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult ModificaViaggio(int id)
        {
            Viaggio ModificaViaggio = null;
            List<Viaggio> ViaggiADisposizione = new List<Viaggio>();

            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {

                ModificaViaggio = DatabaseAgenziaDiViaggi.Viaggi
                 .Where(Viaggio => Viaggio.Id == id)
                 .FirstOrDefault();
                ViaggiADisposizione = DatabaseAgenziaDiViaggi.Viaggi.ToList<Viaggio>();
            }
            if (ModificaViaggio == null)
            {
                return NotFound();
            }
            else
            {   //In questa sappaimo che il viaggio esiste e possiamo modificarlo
                Viaggio modelloViaggioModificato = new Viaggio();
                return View("ModificaViaggi", modelloViaggioModificato);
            }
        }
        [HttpPost]
        public IActionResult ModificaViaggio(int id, Viaggio modelloDaPassare)
        {
            if (!ModelState.IsValid)
            {
                using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
                {
                    List<Viaggio> ViaggiADisposizione = DatabaseAgenziaDiViaggi.Viaggi.ToList();
                }
                return View("ModificaViaggi", modelloDaPassare);
            }

            Viaggio ViaggioDaModificare = null;
            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {
                ViaggioDaModificare = DatabaseAgenziaDiViaggi.Viaggi
                    .Where(Viaggio => Viaggio.Id == id)
                    .FirstOrDefault();

                if (ViaggioDaModificare != null)
                {
                    ViaggioDaModificare.ImmagineViaggio = modelloDaPassare.ImmagineViaggio;
                    ViaggioDaModificare.TitoloViaggio = modelloDaPassare.TitoloViaggio;
                    ViaggioDaModificare.DescrizioneViaggio = modelloDaPassare.DescrizioneViaggio;
                    ViaggioDaModificare.DurataViaggio = modelloDaPassare.DurataViaggio;
                    ViaggioDaModificare.DestinazioniViaggio = modelloDaPassare.DestinazioniViaggio;
                    ViaggioDaModificare.CostoViaggio = modelloDaPassare.CostoViaggio;
                    DatabaseAgenziaDiViaggi.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost]
        public IActionResult CancellaViaggio(int id)
        {

            using (AgenziaViaggioContext DatabaseAgenziaDiViaggi = new AgenziaViaggioContext())
            {
                Viaggio ViaggioDaCancellare = DatabaseAgenziaDiViaggi.Viaggi
                   .Where(Viaggio => Viaggio.Id == id)
                   .First();

                if (ViaggioDaCancellare != null)
                {
                    DatabaseAgenziaDiViaggi.Viaggi.Remove(ViaggioDaCancellare);
                    DatabaseAgenziaDiViaggi.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

        }
    }
}
