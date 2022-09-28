using Microsoft.EntityFrameworkCore;
using Stefanini.Business;
using Stefanini.Infrastructure.Mapping;

namespace Stefanini.Infrastructure
{
    public class SteContext : DbContext
    {
        public SteContext(DbContextOptions<SteContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Cidade> Cidade { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());

            modelBuilder.Entity<Cidade>().HasData(
              new Cidade
              {
                  Id = 1,
                  Nome = "João Pessoa",
                  UF = "PB",

              },
               new Cidade
               {
                   Id = 2,
                   Nome = "Cabedelo",
                   UF = "PB",
               }
             );

            modelBuilder.Entity<Pessoa>().HasData(
               new Pessoa
               {
                   Id = 1,
                   CPF = "02021232445",
                   Nome = "Alex Daywid",
                   Idade = 38,
                   Id_Cidade = 1
               }
              );
        }



    }
}