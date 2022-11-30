using System.ComponentModel.DataAnnotations;
using System;
namespace Credentials.Web.Models
{
    public class KredencijaliModel
    {
        public int Id { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public DateTime DatumPromene { get; set; }

        [Required(ErrorMessage = "Polje KorisnickoIme je obavezno!"), MaxLength(50, ErrorMessage = "Maksimalan broj karaktera je 50!"), MinLength(3, ErrorMessage = "Minimalan broj karaktera je 3!")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Polje Lozinka je obavezno!"), MaxLength(30, ErrorMessage = "Maksimalan broj karaktera je 30!"), MinLength(5, ErrorMessage = "Minimalan broj karaktera je 5!")]
        public string Lozinka { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Nedozvoljen format email adrese!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje Aplikacija je obavezno!")]
        public string Aplikacija { get; set; }

        [RegularExpression(@"^\d+(\.\d+)*$", ErrorMessage = "Za IP adresu dozoljene su samo cifre i tacke!")]
        public string IPAdresa { get; set; }

        [Required(ErrorMessage = "Polje Uredjaj je obavezno!")]
        public string Uredjaj { get; set; }
    }
}