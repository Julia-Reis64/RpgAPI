using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.Models.Enuns;

namespace RpgApi.Models
{
    public class Armas
    {
        public int Id {get; set; }
        public string Nome {get; set; }
        public int Dano {get; set; }
        public ArmasEnum Raridade {get; set; }

    }
}