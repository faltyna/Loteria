using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Loteria.Models.DbModels
{
    public class Uczestnik
    {
        [Key]
        public int uczestnikId { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string pseudonim { get; set; }

        public virtual List<Nagroda> Nagrody { get; set; } = new List<Nagroda>();
        public Uczestnik() { }

        public Uczestnik(int uczestnikid, string imie, string nazwisko, string pseudonim)
        {
            this.uczestnikId = uczestnikid;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pseudonim = pseudonim;
        }
    }
}