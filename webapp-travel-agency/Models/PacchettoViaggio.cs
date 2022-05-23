using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models
{
    public class Viaggio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo immagine per il viaggio è obbligatoria")]
        [Url(ErrorMessage = "Non hai inserito un Url valido")]
        public string ImmagineViaggio { get; set; }

        [Required(ErrorMessage ="Il campo titolo è obbligatorio")]
        [StringLength(25, ErrorMessage = "Hai superato il limite di caratteri massimo di 25")]
        public string TitoloViaggio { get; set; }

        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        [StringLength(1000, ErrorMessage = "Hai superato il limite di caratteri massimo di 1000")]
        [Column(TypeName = "Text")]
        public string DescrizioneViaggio { get; set; }

        [Required(ErrorMessage = "Il campo durata del viaggio è obbligatorio")]
        public int DurataViaggio { get; set; }

        [Required(ErrorMessage = "Il campo destinazioni è obbligatorio")]
        //numero di mete da poter visitare
        public int DestinazioniViaggio { get; set; }

        [Required(ErrorMessage = "Il campo prezzo è obbligatorio")]
        public double CostoViaggio { get; set; }


        public Viaggio()
        {

        }

        public Viaggio(string immagineViaggio,string titoloViaggio, string descrizioneViaggio, int durataViaggio, int destinazioneViaggio, double costoViaggio)
        {
            this.ImmagineViaggio = immagineViaggio;
            this.TitoloViaggio = titoloViaggio;
            this.DescrizioneViaggio = descrizioneViaggio;
            this.DurataViaggio = durataViaggio;
            this.DestinazioniViaggio = destinazioneViaggio;
            this.CostoViaggio = costoViaggio;
        }
    }
}
