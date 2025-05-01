using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadeController : ControllerBase
    {
        private readonly DataContext _context;
       public PersonagemHabilidadeController(DataContext context){
        _context = context;
       }

       [HttpPost]
       public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade){
            try{
                Personagem personagem = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(PathString => PathString.Habilidade)
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
       }
    }
}