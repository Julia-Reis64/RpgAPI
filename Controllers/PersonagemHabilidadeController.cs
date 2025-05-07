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
using Microsoft.Identity.Client;

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
                    .Include(p => p.Armas)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(PathString => PathString.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)
                    throw new System.Exception("Personagem não encontrado para o Id informado");
                
                Habilidade habilidade = await _context.TB_HABILIDADES
                    .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if(habilidade == null)
                    throw new System.Exception("Habilidade não encontrada");
                
                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
                }
                catch (SystemException ex){
                    return BadRequest(ex.Message);
                }
            
       }

       [HttpGet("{id}")]
       public async Task<IActionResult> GetSingle(int id){

        try{
            Personagem p = await _context.TB_PERSONAGENS
                .Include(ar => ar.Armas)
                .Include(ph => ph.PersonagemHabilidades)
                .ThenInclude(h => h.Habilidade)
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
            return Ok(p);
        }
        catch (System.Exception ex){
            return BadRequest(ex.Message);
        }
       }
    }
}