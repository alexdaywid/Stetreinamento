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
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidade")
                .HasKey(c=> c.Id);

            builder.Property(c => c.Nome)
              .HasColumnType("varchar")
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(c => c.UF)
             .HasColumnType("varchar")
             .IsRequired()
             .HasMaxLength(2);

        }
    }
}
