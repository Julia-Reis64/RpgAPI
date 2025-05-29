using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArmasController : ControllerBase
    {
       private readonly DataContext _context;
       private static List<Armas> armas = new List<Armas>(){
            new Armas() { Id = 1, Nome = "Tíbia (sim o osso da perna)", Dano = 25, Raridade=ArmasEnum.De_boa, Elemento=HabilidadesEnum.Normal },
            new Armas() { Id = 2, Nome = "Machado de Execução", Dano = 40, Raridade=ArmasEnum.Maneira, Elemento=HabilidadesEnum.Normal },
            new Armas() { Id = 3, Nome = "Cajado Candelabro", Dano = 25, Raridade=ArmasEnum.Incrível, Elemento=HabilidadesEnum.Fogo },
            new Armas() { Id = 4, Nome = "Pedaço de Pilar", Dano = 30, Raridade=ArmasEnum.Incrível, Elemento=HabilidadesEnum.Osso },
            new Armas() { Id = 5, Nome = "Pistoleta Trevosa", Dano = 30, Raridade=ArmasEnum.De_boa, Elemento=HabilidadesEnum.Sombra},
            new Armas() { Id = 6, Nome = "Foice", Dano = 35, Raridade=ArmasEnum.Trevosa, Elemento=HabilidadesEnum.Espirito},
            new Armas() { Id = 7, Nome = "Crânio Mágico (sei lá)", Dano = 45, Raridade=ArmasEnum.Trevosa, Elemento=HabilidadesEnum.Osso}
        };
    
        [HttpGet("GetAll")]
        public IActionResult Get(){
            
            return Ok(armas);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id){
            
            return Ok(armas.FirstOrDefault(ar => ar.Id == id));
        }

        [HttpPost]
        public IActionResult AddArma(Armas novaArma){

            if(novaArma.Dano == 0){
                return BadRequest("Esta arma é inútil");
            }
            armas.Add(novaArma);
            return Ok(armas);
        }

        [HttpPost]
         public async Task<IActionResult> Update(Armas novaArma){
            try{
                if (novaArma.Dano < 0){
                   throw new Exception("Esta arma é inútil, sai fora");
                }
                if(novaArma.Dano > 100){
                    throw new Exception("Muito apelão fi calma lá");
                }
                
                _context.TB_ARMAS.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }

            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetExpurgarArma")]
        public IActionResult GetExpurgarArma(){

            Armas aRemove = armas.Find(a => a.Id == a.Id);
            armas.Remove(aRemove);
            return Ok("Arma expurgada com sucesso: " + aRemove.Nome);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {               
                if(novaArma.Dano == 0)
                  throw new Exception("O Dano da arma não pode ser 0");

                Personagem? p = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);
                
                if(p == null)
                    throw new Exception("Não existe personagem com o Id informado.");

                Armas buscaArma = await _context.TB_ARMAS.FirstOrDefaultAsync(a => a.PersonagemId == novaArma.PersonagemId);

                if(buscaArma != null)
                    throw new Exception("O Personagem selecionado já contém uma arma atribuída a ele.");

                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
        
    }
}