using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using RpgApi.Models.Enuns;

namespace RpgApi.Models
{
    public class Habilidade
    {
        public int Id {get; set; } 
        public string Nome {get; set; } = string.Empty;
        public int Dano {get; set; }
        public HabilidadesEnum Elemento {get; set; }

        public List<PersonagemHabilidade> PersonagemHabilidades {get; set;} = [];
        


    }
}