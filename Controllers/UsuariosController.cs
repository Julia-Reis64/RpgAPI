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
//using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens; 
using System.Text; 
using System;
using System.IdentityModel.Tokens.Jwt;
using RpgApi.Extensions;



namespace RpgApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
       private readonly DataContext _context;
       private readonly IConfiguration _configuration;

       public UsuariosController(DataContext context, IConfiguration configuration){
        _context = context;
        _configuration = configuration;
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

       [AllowAnonymous]
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
                    usuario.DataAcesso = DateTime.Now;
                    _context.TB_USUARIOS.Update(usuario);
                    await _context.SaveChangesAsync();

                    usuario.PasswordHash = null;
                    usuario.PasswordSalt = null;
                    usuario.Token = CriarToken(usuario);

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

      [HttpPut("AtualizarFoto")]
        public async Task<IActionResult> AtualizarFoto(Usuario u){
            try{
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Foto = u.Foto;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Foto).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

      [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(Usuario u){
            try{
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Email = u.Email;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Email).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

     [HttpPut("AtualizarLocalizacao")]
        public async Task<IActionResult> AtualizarLocalizacao(Usuario u){
            try{
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Id == u.Id);
                usuario.Latitude = u.Latitude;
                usuario.Longitude = u.Longitude;
                var attach = _context.Attach(usuario);
                attach.Property(x => x.Id).IsModified = false;
                attach.Property(x => x.Latitude).IsModified = true;
                attach.Property(x => x.Longitude).IsModified = true;
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

    [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login){
            try{
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Username.ToLower() == login.ToLower());
                return Ok(usuario);
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

     [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId){
            try{
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Id == usuarioId);
                return Ok(usuario);
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }


    [HttpGet("GetByPerfil/{userId}")]
        public async Task<IActionResult> GetByPerfilAsync(int userId){
            try{
                Usuario usuario = await _context.TB_USUARIOS.FirstOrDefaultAsync(x => x.Id == userId);
                List<Personagem> lista = new List<Personagem>();

                if (usuario.Perfil == "Admin")
                    lista = await _context.TB_PERSONAGENS.ToListAsync();
                else
                    lista = await _context.TB_PERSONAGENS.Where(p => p.Usuario.Id == userId).ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

    [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetByUserAsync(int userId){
            try{
                List<Personagem> lista = await _context.TB_PERSONAGENS.Where(u => u.Usuario.Id == userId).ToListAsync();
                return Ok(lista);
                }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
                }
        }
    [HttpGet("GetByPerfil")]
    public async Task<IActionResult> GetByPerfilAsync(){
        try{
            List<Personagem> lista = new List<Personagem>();

            if(User.UsuarioPerfil() == "Admin"){
                lista = await _context.TB_PERSONAGENS.ToListAsync();
            }
            else{
                lista = await _context.TB_PERSONAGENS.Where(p => p.Usuario.Id == User.UsuarioId()).ToListAsync();                
            }
            return Ok(lista);
        }
        catch (System.Exception ex){
            return BadRequest(ex.Message + " - " + ex.InnerException);
        }
    }
    
    private string CriarToken(Usuario usuario){

            List<Claim> claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Username),
            new Claim(ClaimTypes.Role, usuario.Perfil)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }      



    }
}