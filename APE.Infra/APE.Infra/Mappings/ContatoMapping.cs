using APE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ProvaDev.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("cd_contato");

            builder.Property(x => x.IdCliente)
                .HasColumnName("cd_cliente");

            builder.Property(x => x.Email)
                .HasColumnName("nm_email");

            builder.Property(x => x.DddTelefone)
                .HasColumnName("nu_ddd");

            builder.Property(x => x.NumeroTelefone)
                .HasColumnName("nu_numero");

            builder.ToTable("contato", "Cliente");
        }
    }
}
