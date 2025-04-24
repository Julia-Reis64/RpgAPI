using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgApi.Utils;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Personagem> TB_PERSONAGENS { get; set; }
        public DbSet<Armas> TB_ARMAS {get; set; }
        public DbSet<Usuario> TB_USUARIOS {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");
            
            modelBuilder.Entity<Personagem>().HasData(
                new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro, UsuarioID =1},
                new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro, UsuarioID =1},
                new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo, UsuarioID =1},
                new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago, UsuarioID =1},
                new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro, UsuarioID =1},
                new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo, UsuarioID =1},
                new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago, UsuarioID =1}
            );

            modelBuilder.Entity<Armas>().ToTable("TB_ARMAS");

            modelBuilder.Entity<Armas>().HasData(
                new Armas() { Id = 1, Nome = "Tíbia (sim o osso da perna)", Dano = 25, Raridade=ArmasEnum.De_boa, PersonagemId = 1},
                new Armas() { Id = 2, Nome = "Machado de Execução", Dano = 40, Raridade=ArmasEnum.Maneira, PersonagemId = 2},
                new Armas() { Id = 3, Nome = "Cajado Candelabro", Dano = 25, Raridade=ArmasEnum.Incrível, PersonagemId = 3},
                new Armas() { Id = 4, Nome = "Pedaço de Pilar", Dano = 30, Raridade=ArmasEnum.Incrível, PersonagemId = 4 },
                new Armas() { Id = 5, Nome = "Pistoleta Trevosa", Dano = 30, Raridade=ArmasEnum.De_boa, PersonagemId = 5 },
                new Armas() { Id = 6, Nome = "Foice", Dano = 35, Raridade=ArmasEnum.Trevosa, PersonagemId = 6 },
                new Armas() { Id = 7, Nome = "Crânio Mágico (sei lá)", Dano = 45, Raridade=ArmasEnum.Trevosa, PersonagemId = 7 }
            );

            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Personagems)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioID)
                .IsRequired(false);
            
            modelBuilder.Entity<Personagem>()
                .HasOne(e => e.Armas)
                .WithOne(e => e.Personagem)
                .HasForeignKey<Armas>(e => e.PersonagemId)
                .IsRequired();

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        
    }
}