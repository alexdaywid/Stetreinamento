using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Infrastructure.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa")
                .HasKey(p => p.Id);

            builder.Property(p => p.Nome)
              .HasColumnType("varchar")
              .IsRequired()
              .HasMaxLength(300);

            builder.Property(p => p.CPF)
             .HasColumnType("varchar")
             .IsRequired()
             .HasMaxLength(11);

            builder.Property(p => p.Id_Cidade)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(p => p.Idade)
            .HasColumnType("int")
            .IsRequired();

            builder.HasOne(p => p.Cidade)
                .WithMany(c => c.Pessoa)
                .HasForeignKey(p => p.Id_Cidade);
        }
    }
}
