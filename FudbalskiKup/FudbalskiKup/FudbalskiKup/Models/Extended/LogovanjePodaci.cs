using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FudbalskiKup.Models.Extended
{
    public class LogovanjePodaci
    {
        [Required(ErrorMessage = "Polje mora biti popunjeno")]
        [DisplayName("Korisnicko Ime")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Polje mora biti popunjeno")]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
    }
}