using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabilidadesController : Controller
    {
        private readonly DataContext _context;

        private static List<Habilidade> Habilidades = new List<Habilidade>(){
             new Habilidade(){Id=1, Nome="Combustão", Dano= 39, Elemento=HabilidadesEnum.Fogo},
             new Habilidade(){Id=2, Nome="Penumbra", Dano= 41, Elemento=HabilidadesEnum.Sombra},
             new Habilidade(){Id=3, Nome="Dama de Cálcio", Dano = 37, Elemento=HabilidadesEnum.Osso}
        };

        
    }
}