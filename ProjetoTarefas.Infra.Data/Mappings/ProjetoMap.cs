using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosApp.Infra.Data.Mappings
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("PROJETO");

            builder.HasKey(p  => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            builder.Property(p => p.Categoria)
                .HasColumnName("CATEGORIA")
                .IsRequired();

            builder.Property(p => p.DataInicio)
                .HasColumnName("DATAINICIO")
                .IsRequired();

            builder.Property(p => p.DataEntrega)
                .HasColumnName("DATAENTREGA");

            builder.Property(p => p.Status)
                .HasColumnName("STATUS")
                .IsRequired();

            builder.Property(p => p.UsuarioId)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            #region Relacionamentos

            builder.HasMany(p => p.Usuarios)
                .WithMany(u => u.Projetos);

            #endregion

        }
    }
}
