using System;
using System.Collections.Generic;
using System.Text;

namespace Credentials.Data
{
    public class Kredencijali : Base
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }

        public string Aplikacija { get; set; }
        public string IPAdresa { get; set; }
        public string Uredjaj { get; set; }

    }
}
