using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Loteria.Models.DbModels
{
    public class Pytanie
    {
        [Key]
        public int pytanieId { get; set; }
        public string tresc { get; set; }

        public Pytanie() { }
        public Pytanie(int pytanieid, string tresc)
        {
            this.pytanieId = pytanieid;
            this.tresc = tresc;
        }
    }
}