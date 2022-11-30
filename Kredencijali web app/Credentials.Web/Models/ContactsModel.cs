using System.ComponentModel.DataAnnotations;

namespace Credentials.Web.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje ime je obavezno!")]
        public string Ime { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Maksimalan broj karaktera je 50!"), MinLength(3, ErrorMessage = "Minimalan broj karaktera je 3!")]
        public string Prezime { get; set; }

        [Display(Name = "Broj Telefona", Prompt = "Broj Telefona")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Za broj telefona dozoljene su samo cifre!")]
        public string BrojTelefona { get; set; }
    }
}