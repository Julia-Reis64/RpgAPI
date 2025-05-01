using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.Models.Enuns;

namespace RpgApi.Models
{
    public class PersonagemHabilidade
    {
        public int PersonagemId {get; set; }
        public Personagem Personagem {get; set; } = null!;
        public int HabilidadeId {get; set; }
        public Habilidade? Habilidade {get; set; } = null!;
        public HabilidadesEnum Elemento {get; set; }
        
    }
}