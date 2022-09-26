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
        }
    }
}