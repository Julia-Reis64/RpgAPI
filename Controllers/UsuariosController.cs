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
using RpgApi.Utils;
using Microsoft.VisualBasic;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
       private readonly DataContext _context;
       public UsuariosController(DataContext context){
        _context = context;
       }
       private async Task<bool> UsuarioExistente(string username){
        if(await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == username.ToLower())){
            return true;
        }
        return false;
       }

       [HttpPost("Registrar")]
       public async Task<IActionResult> RegistrarUsuario(Usuario user){
        try{
            if(await UsuarioExistente(user.Username))
                throw new System.Exception("Nome de usuário já existe");
            
            Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            await _context.TB_USUARIOS.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user.Id);
        }
        catch (System.Exception ex){
            return BadRequest(ex.Message);
        }
       }

       public static bool VerificarPassowrdHash(string password, byte[] hash, byte[] salt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512(salt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++){
                    if(computedHash[i] != hash[i]){
                        return false;
                    }
                }
                return true;
            }
       }

       [HttpPost("Autenticar")]
       public async Task<IActionResult> AutenticarUsuario(Usuario credenciais){
            try{
                Usuario? usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if(usuario == null){
                    throw new System.Exception("Usuário não encontrado");
                }
                else if(!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt)){
                    throw new System.Exception("Senha incorreta");
                }
                else{
                    return Ok(usuario);
                }
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
       }

       [HttpPost]
       public async Task<IActionResult> Add(Armas novaArma){
        try{
            if(novaArma.Dano == 0)
                throw new Exception("O dano da arma não pode ser 0");
            Personagem p = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);
            if(p == null)
                throw new Exception("Não existe personagem com o Id informado");
            await _context.TB_ARMAS.AddAsync(novaArma);
            await _context.SaveChangesAsync();

            return Ok(novaArma.Id);
        }
        catch (SystemException ex){
            return BadRequest(ex.Message);
        }
       }

    }
}